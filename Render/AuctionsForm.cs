using System.ComponentModel;
using Сursova.Models;
using Сursova.Services;

namespace PaintingGuide;

public partial class AuctionsForm : Form
{
    private readonly DataService _dataService;
    private BindingList<Auction> _auctions;
    private BindingList<AuctionLot> _currentAuctionLots;
    public AuctionsForm(DataService dataService)
    {
        _dataService = dataService;
        InitializeComponent();
        SetupForm();
        LoadAuctions();
        SetupAuctionsGrid();
        SetupLotsGrid();
        UpdateAuctionDetailsVisibility(false); 
        UpdateButtonsState();
    }

    private void SetupForm()
    {
        this.Text = "Управління аукціонами";
    }

    private void LoadAuctions()
    {
        _auctions = new BindingList<Auction>(_dataService.GetAllAuctions());
        dataGridViewAuctions.DataSource = _auctions;
    }

    private void SetupAuctionsGrid()
    {
        dataGridViewAuctions.AutoGenerateColumns = false;
        dataGridViewAuctions.Columns.Clear();

        dataGridViewAuctions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Назва аукціону", Width = 200 });
        dataGridViewAuctions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Date", HeaderText = "Дата", Width = 150, DefaultCellStyle = { Format = "yyyy-MM-dd HH:mm" } });
        dataGridViewAuctions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Location", HeaderText = "Місце проведення", Width = 150 });
        dataGridViewAuctions.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "AuctionHouse", HeaderText = "Аукціонний дім", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
    }

    private void SetupLotsGrid()
    {
        dataGridViewLots.AutoGenerateColumns = false;
        dataGridViewLots.Columns.Clear();

        dataGridViewLots.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LotNumber", HeaderText = "№ Лота", Width = 70 });
        dataGridViewLots.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaintingTitle", HeaderText = "Назва картини", Width = 200 });
        dataGridViewLots.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ArtistFullName", HeaderText = "Художник", Width = 150 });
        dataGridViewLots.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaintingYear", HeaderText = "Рік", Width = 70 });
        dataGridViewLots.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaintingGenre", HeaderText = "Жанр", Width = 100 });
        dataGridViewLots.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PaintingTechnique", HeaderText = "Техніка", Width = 120 });
        dataGridViewLots.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StartingPrice", HeaderText = "Початкова ціна", Width = 120, DefaultCellStyle = { Format = "C2" } });
        dataGridViewLots.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FinalPrice", HeaderText = "Кінцева ціна", Width = 120, DefaultCellStyle = { Format = "C2" } });
        dataGridViewLots.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "IsSold", HeaderText = "Продано", Width = 70 });
        dataGridViewLots.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BuyerInfo", HeaderText = "Інфо про покупця", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

    }

    private void dataGridViewAuctions_SelectionChanged(object sender, EventArgs e)
    {
        UpdateButtonsState();
        if (dataGridViewAuctions.SelectedRows.Count > 0)
        {
            var selectedAuction = (Auction)dataGridViewAuctions.SelectedRows[0].DataBoundItem;
            LoadLotsForSelectedAuction(selectedAuction.Id);
            DisplayAuctionDetails(selectedAuction);
        }
        else
        {
            _currentAuctionLots = new BindingList<AuctionLot>();
            dataGridViewLots.DataSource = _currentAuctionLots;
            ClearAuctionDetails();
        }
    }

    private void LoadLotsForSelectedAuction(int auctionId)
    {
        _currentAuctionLots = new BindingList<AuctionLot>(_dataService.GetLotsForAuction(auctionId));
        dataGridViewLots.DataSource = _currentAuctionLots;
    }

    private void DisplayAuctionDetails(Auction auction)
    {
        txtAuctionName.Text = auction.Name;
        dtpAuctionDate.Value = auction.Date;
        txtAuctionLocation.Text = auction.Location;
        txtAuctionHouse.Text = auction.AuctionHouse;
        UpdateAuctionDetailsVisibility(true);
    }

    private void ClearAuctionDetails()
    {
        txtAuctionName.Clear();
        dtpAuctionDate.Value = DateTime.Now;
        txtAuctionLocation.Clear();
        txtAuctionHouse.Clear();
        UpdateAuctionDetailsVisibility(false);
    }

    private void UpdateAuctionDetailsVisibility(bool visible)
    {
        groupBoxAuctionDetails.Enabled = visible;
        btnSaveAuction.Visible = visible;
        btnCancelAuction.Visible = visible;
    }

    private void UpdateButtonsState()
    {
        bool hasAuctionSelected = dataGridViewAuctions.SelectedRows.Count > 0;
        btnEditAuction.Enabled = hasAuctionSelected;
        btnDeleteAuction.Enabled = hasAuctionSelected;
        btnAddLot.Enabled = hasAuctionSelected; 

        bool hasLotSelected = dataGridViewLots.SelectedRows.Count > 0;
        btnEditLot.Enabled = hasLotSelected;
        btnDeleteLot.Enabled = hasLotSelected;
        btnViewPriceHistory.Enabled = hasLotSelected;
    }

    private void btnAddAuction_Click(object sender, EventArgs e)
    {
        ClearAuctionDetails();
        UpdateAuctionDetailsVisibility(true);
        dataGridViewAuctions.ClearSelection(); 
    }

    private void btnEditAuction_Click(object sender, EventArgs e)
    {
        if (dataGridViewAuctions.SelectedRows.Count > 0)
        {
            var selectedAuction = (Auction)dataGridViewAuctions.SelectedRows[0].DataBoundItem;
            DisplayAuctionDetails(selectedAuction);
            UpdateAuctionDetailsVisibility(true);
        }
        else
        {
            MessageBox.Show("Будь ласка, оберіть аукціон для редагування.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnSaveAuction_Click(object sender, EventArgs e)
    {
        if (!ValidateAuctionInput())
        {
            return;
        }

        Auction currentAuction;
        if (dataGridViewAuctions.SelectedRows.Count > 0 && groupBoxAuctionDetails.Enabled)
        {
            // Редагування існуючого аукціону
            currentAuction = (Auction)dataGridViewAuctions.SelectedRows[0].DataBoundItem;
        }
        else
        {
            // Додавання нового аукціону
            currentAuction = new Auction();
        }

        currentAuction.Name = txtAuctionName.Text.Trim();
        currentAuction.Date = dtpAuctionDate.Value;
        currentAuction.Location = txtAuctionLocation.Text.Trim();
        currentAuction.AuctionHouse = txtAuctionHouse.Text.Trim();

        _dataService.SaveAuction(currentAuction);
        LoadAuctions(); 
        ClearAuctionDetails();
        UpdateButtonsState();
    }

    private void btnCancelAuction_Click(object sender, EventArgs e)
    {
        ClearAuctionDetails();
        UpdateButtonsState();
    }

    private bool ValidateAuctionInput()
    {
        if (string.IsNullOrWhiteSpace(txtAuctionName.Text))
        {
            MessageBox.Show("Будь ласка, введіть назву аукціону.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtAuctionName.Focus();
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtAuctionLocation.Text))
        {
            MessageBox.Show("Будь ласка, введіть місце проведення аукціону.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtAuctionLocation.Focus();
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtAuctionHouse.Text))
        {
            MessageBox.Show("Будь ласка, введіть назву аукціонного дому.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtAuctionHouse.Focus();
            return false;
        }
        return true;
    }

    private void btnDeleteAuction_Click(object sender, EventArgs e)
    {
        if (dataGridViewAuctions.SelectedRows.Count > 0)
        {
            var selectedAuction = (Auction)dataGridViewAuctions.SelectedRows[0].DataBoundItem;
            var result = MessageBox.Show($"Ви впевнені, що хочете видалити аукціон '{selectedAuction.Name}'? Це також видалить усі пов'язані лоти.",
                                         "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _dataService.DeleteAuction(selectedAuction.Id);
                LoadAuctions(); 
            }
        }
        else
        {
            MessageBox.Show("Будь ласка, оберіть аукціон для видалення.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void dataGridViewAuctions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            btnEditAuction_Click(sender, e);
        }
    }

    private void btnAddLot_Click(object sender, EventArgs e)
    {
        if (dataGridViewAuctions.SelectedRows.Count > 0)
        {
            var selectedAuction = (Auction)dataGridViewAuctions.SelectedRows[0].DataBoundItem;
            var newLot = new AuctionLot { AuctionId = selectedAuction.Id };

            using (var form = new AuctionLotEditForm(_dataService, selectedAuction.Id, newLot))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _dataService.SaveAuctionLot(newLot);
                    LoadLotsForSelectedAuction(selectedAuction.Id); 
                }
            }
        }
        else
        {
            MessageBox.Show("Будь ласка, оберіть аукціон, до якого ви хочете додати лот.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnEditLot_Click(object sender, EventArgs e)
    {
        var selectedLot = GetSelectedLot();
        if (selectedLot != null)
        {
            var lotCopy = new AuctionLot
            {
                Id = selectedLot.Id,
                AuctionId = selectedLot.AuctionId,
                PaintingId = selectedLot.PaintingId,
                LotNumber = selectedLot.LotNumber,
                StartingPrice = selectedLot.StartingPrice,
                FinalPrice = selectedLot.FinalPrice,
                IsSold = selectedLot.IsSold,
                BuyerInfo = selectedLot.BuyerInfo,
                Painting = selectedLot.Painting 
            };

            using (var form = new AuctionLotEditForm(_dataService, selectedLot.AuctionId, lotCopy))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    selectedLot.PaintingId = lotCopy.PaintingId;
                    selectedLot.LotNumber = lotCopy.LotNumber;
                    selectedLot.StartingPrice = lotCopy.StartingPrice;
                    selectedLot.FinalPrice = lotCopy.FinalPrice;
                    selectedLot.IsSold = lotCopy.IsSold;
                    selectedLot.BuyerInfo = lotCopy.BuyerInfo;
                    selectedLot.Painting = lotCopy.Painting;

                    _dataService.SaveAuctionLot(selectedLot);
                    _currentAuctionLots.ResetItem(_currentAuctionLots.IndexOf(selectedLot));
                }
            }
        }
        else
        {
            MessageBox.Show("Будь ласка, оберіть лот для редагування.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnDeleteLot_Click(object sender, EventArgs e)
    {
        var selectedLot = GetSelectedLot();
        if (selectedLot != null)
        {
            var result = MessageBox.Show($"Видалити лот №{selectedLot.LotNumber} з картиною '{selectedLot.Painting?.Title ?? "Без назви"}'?",
                                         "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _dataService.DeleteAuctionLot(selectedLot.Id);
                var selectedAuction = (Auction)dataGridViewAuctions.SelectedRows[0].DataBoundItem;
                LoadLotsForSelectedAuction(selectedAuction.Id);
            }
        }
        else
        {
            MessageBox.Show("Будь ласка, оберіть лот для видалення.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private AuctionLot GetSelectedLot()
    {
        if (dataGridViewLots.SelectedRows.Count > 0)
        {
            return (AuctionLot)dataGridViewLots.SelectedRows[0].DataBoundItem;
        }
        return null;
    }

    private void dataGridViewLots_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            btnEditLot_Click(sender, e);
        }
    }

    private void dataGridViewLots_SelectionChanged(object sender, EventArgs e)
    {
        UpdateButtonsState();
    }

    private void btnViewPriceHistory_Click(object sender, EventArgs e)
    {
        var selectedLot = GetSelectedLot();
        if (selectedLot != null && selectedLot.PaintingId != 0)
        {
            var priceHistory = _dataService.GetPriceHistoryForPainting(selectedLot.PaintingId);

            string historyText = $"Історія цін для картини '{selectedLot.Painting?.Title ?? "Без назви"}':\n\n";
            if (priceHistory.Any())
            {
                foreach (var item in priceHistory.OrderBy(ph => ph.AuctionDate))
                {
                    historyText += $"Аукціон: '{item.AuctionName}' ({item.AuctionDate:yyyy-MM-dd HH:mm})\n" +
                                   $"  Лот №{item.LotNumber}\n" +
                                   $"  Початкова ціна: {item.StartingPrice:C}\n" +
                                   $"  Кінцева ціна: {(item.FinalPrice.HasValue ? item.FinalPrice.Value.ToString("C") : "Не продано")} (Продано: {item.IsSold})\n" +
                                   $"  Покупець: {(string.IsNullOrEmpty(item.BuyerInfo) ? "Не вказано" : item.BuyerInfo)}\n\n";
                }
            }
            else
            {
                historyText += "Історія цін відсутня.";
            }

            MessageBox.Show(historyText, "Історія цін картини", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Оберіть лот, щоб переглянути історію цін картини.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}