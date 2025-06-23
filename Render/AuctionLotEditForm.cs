using System.ComponentModel;
using Сursova.Models;
using Сursova.Services;

namespace PaintingGuide;

public partial class AuctionLotEditForm : Form
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public AuctionLot AuctionLot { get; private set; }
    private readonly DataService _dataService;
    private readonly int _auctionId;
    private List<Painting> _availablePaintings;

    public AuctionLotEditForm(DataService dataService, int auctionId, AuctionLot auctionLot = null)
    {
        _dataService = dataService;
        _auctionId = auctionId;
        AuctionLot = auctionLot ?? new AuctionLot { AuctionId = _auctionId };

        InitializeComponent();
        SetupLayout();
        LoadPaintingsIntoComboBox();
        LoadAuctionLotData();
        SetupEventHandlers();
    }

    private void SetupLayout()
    {
        txtFinalPrice.Enabled = chkIsSold.Checked;
        txtBuyerInfo.Enabled = chkIsSold.Checked;
    }


    private void LoadPaintingsIntoComboBox()
    {
        _availablePaintings = _dataService.GetAllPaintings();
        cmbPainting.DataSource = _availablePaintings;
        cmbPainting.DisplayMember = "Title"; 
        cmbPainting.ValueMember = "Id";

        if (AuctionLot.PaintingId != 0)
        {
            cmbPainting.SelectedValue = AuctionLot.PaintingId;
        }
    }

    private void LoadAuctionLotData()
    {
        txtLotNumber.Text = AuctionLot.LotNumber.ToString();
        txtStartingPrice.Text = AuctionLot.StartingPrice.ToString();
        txtFinalPrice.Text = AuctionLot.FinalPrice?.ToString() ?? string.Empty;
        chkIsSold.Checked = AuctionLot.IsSold;
        txtBuyerInfo.Text = AuctionLot.BuyerInfo;
        txtFinalPrice.Enabled = chkIsSold.Checked;
        txtBuyerInfo.Enabled = chkIsSold.Checked;
    }

    private void SaveAuctionLotData()
    {
        AuctionLot.LotNumber = int.Parse(txtLotNumber.Text);
        AuctionLot.StartingPrice = decimal.Parse(txtStartingPrice.Text);
        AuctionLot.IsSold = chkIsSold.Checked;

        if (chkIsSold.Checked && decimal.TryParse(txtFinalPrice.Text, out decimal finalPrice))
        {
            AuctionLot.FinalPrice = finalPrice;
        }
        else
        {
            AuctionLot.FinalPrice = null;
        }

        AuctionLot.BuyerInfo = txtBuyerInfo.Text.Trim();

        if (cmbPainting.SelectedValue != null)
        {
            AuctionLot.PaintingId = (int)cmbPainting.SelectedValue;
            AuctionLot.Painting = _availablePaintings.FirstOrDefault(p => p.Id == AuctionLot.PaintingId);
        }
        else
        {
            AuctionLot.PaintingId = 0; 
            AuctionLot.Painting = null;
        }
    }

    private void SetupEventHandlers()
    {
        chkIsSold.CheckedChanged += chkIsSold_CheckedChanged;
        btnSave.Click += btnSave_Click;
        btnCancel.Click += btnCancel_Click;
        txtLotNumber.KeyPress += txtLotNumber_KeyPress;
        txtStartingPrice.KeyPress += txtPrice_KeyPress;
        txtFinalPrice.KeyPress += txtPrice_KeyPress;
    }


    private bool ValidateForm()
    {
        if (cmbPainting.SelectedValue == null || (int)cmbPainting.SelectedValue == 0)
        {
            MessageBox.Show("Будь ласка, оберіть картину.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
            cmbPainting.Focus();
            return false;
        }

        if (!int.TryParse(txtLotNumber.Text, out int lotNumber) || lotNumber <= 0)
        {
            MessageBox.Show("Номер лота має бути додатним цілим числом.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtLotNumber.Focus();
            return false;
        }

        if (!decimal.TryParse(txtStartingPrice.Text, out decimal startingPrice) || startingPrice < 0)
        {
            MessageBox.Show("Початкова ціна має бути невід'ємним числом.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtStartingPrice.Focus();
            return false;
        }

        if (chkIsSold.Checked)
        {
            if (!decimal.TryParse(txtFinalPrice.Text, out decimal finalPrice) || finalPrice < 0)
            {
                MessageBox.Show("Кінцева ціна має бути невід'ємним числом, якщо лот продано.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFinalPrice.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtBuyerInfo.Text))
            {
                MessageBox.Show("Будь ласка, введіть інформацію про покупця, якщо лот продано.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBuyerInfo.Focus();
                return false;
            }
        }

        return true;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidateForm())
        {
            SaveAuctionLotData();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void chkIsSold_CheckedChanged(object sender, EventArgs e)
    {
        txtFinalPrice.Enabled = chkIsSold.Checked;
        txtBuyerInfo.Enabled = chkIsSold.Checked;
        if (!chkIsSold.Checked)
        {
            txtFinalPrice.Clear();
            txtBuyerInfo.Clear();
        }
    }
    private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
        {
            e.Handled = true;
        }
        if ((e.KeyChar == '.' || e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1 || (sender as TextBox).Text.IndexOf(',') > -1))
        {
            e.Handled = true;
        }
    }

    private void txtLotNumber_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
        }
    }
}