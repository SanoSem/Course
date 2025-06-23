using PaintingGuide;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Сursova.Models;
using Сursova.Services;

namespace Сursova.Forms
{
    public partial class CommissionShopItemsForm : Form
    {
        private readonly DataService _dataService;
        private readonly int _commissionShopId;
        private DataGridView dgvCommissionShopItems;
        private Button btnAddItem;
        private Button btnEditItem;
        private Button btnDeleteItem;
        private Label lblShopName;

        public CommissionShopItemsForm(DataService dataService, int commissionShopId)
        {
            _dataService = dataService;
            _commissionShopId = commissionShopId;
            InitializeComponent();
            SetupForm();
            LoadCommissionShopItems();
        }

        private void SetupForm()
        {
            var shop = _dataService.GetCommissionShopById(_commissionShopId);
            Text = $"Предмети в магазині: {shop?.Name ?? "Невідомий магазин"}";
            Size = new Size(900, 600);
            StartPosition = FormStartPosition.CenterParent;

            lblShopName = new Label
            {
                Text = $"Предмети для: {shop?.Name ?? "Невідомий магазин"}",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 30
            };
            Controls.Add(lblShopName);

            dgvCommissionShopItems = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            Controls.Add(dgvCommissionShopItems);

            Panel panelButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50
            };

            btnAddItem = new Button { Text = "Додати предмет", Dock = DockStyle.Left, Width = 150 };
            btnAddItem.Click += BtnAddItem_Click;
            panelButtons.Controls.Add(btnAddItem);

            btnEditItem = new Button { Text = "Редагувати предмет", Dock = DockStyle.Left, Width = 150 };
            btnEditItem.Click += BtnEditItem_Click;
            panelButtons.Controls.Add(btnEditItem);

            btnDeleteItem = new Button { Text = "Видалити предмет", Dock = DockStyle.Left, Width = 150 };
            btnDeleteItem.Click += BtnDeleteItem_Click;
            panelButtons.Controls.Add(btnDeleteItem);

            Controls.Add(panelButtons);

            // Оновлюю порядок кнопок, щоб вони йшли справа наліво
            btnAddItem.BringToFront();
            btnEditItem.BringToFront();
            btnDeleteItem.BringToFront();
        }

        private void LoadCommissionShopItems()
        {
            var items = _dataService.GetAllCommissionShopItems()
                                    .Where(item => item.CommissionShopId == _commissionShopId)
                                    .ToList();

            dgvCommissionShopItems.DataSource = items.Select(item => new
            {
                item.Id,
                НазваКартини = item.Painting?.Title ?? "Невідома картина",
                Художник = item.Painting?.Artist != null ? $"{item.Painting.Artist.FirstName} {item.Painting.Artist.LastName}" : "Невідомий художник",
                ЗапитуванаЦіна = item.AskingPrice,
                ДатаРозміщення = item.ListingDate.ToShortDateString(),
                Продано = item.IsSold ? "Так" : "Ні",
                ЦінаПродажу = item.SalePrice,
                ДатаПродажу = item.SaleDate?.ToShortDateString(),
                Примітки = item.Notes
            }).ToList();

            // Приховую стовпці з ID, оскільки вони не потрібні користувачу
            if (dgvCommissionShopItems.Columns.Contains("Id"))
            {
                dgvCommissionShopItems.Columns["Id"].Visible = false;
            }
            if (dgvCommissionShopItems.Columns.Contains("PaintingId"))
            {
                dgvCommissionShopItems.Columns["PaintingId"].Visible = false;
            }
            if (dgvCommissionShopItems.Columns.Contains("CommissionShopId"))
            {
                dgvCommissionShopItems.Columns["CommissionShopId"].Visible = false;
            }
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        { 
            var paintings = _dataService.GetAllPaintings();
            if (!paintings.Any())
            {
                MessageBox.Show("Немає картин для додавання. Будь ласка, спочатку додайте картини.", "Помилка");
                return;
            }

            // Простий спосіб вибору картини через InputBox 
            string paintingIdStr = Microsoft.VisualBasic.Interaction.InputBox("Введіть ID картини для додавання:", "Додати предмет", "");
            if (int.TryParse(paintingIdStr, out int paintingId))
            {
                var selectedPainting = paintings.FirstOrDefault(p => p.Id == paintingId);
                if (selectedPainting == null)
                {
                    MessageBox.Show("Картину з таким ID не знайдено.", "Помилка");
                    return;
                }

                if (decimal.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Введіть запитувану ціну:", "Додати предмет", ""), out decimal askingPrice))
                {
                    var newItem = new CommissionShopItem
                    {
                        PaintingId = paintingId,
                        CommissionShopId = _commissionShopId,
                        AskingPrice = askingPrice,
                        ListingDate = DateTime.Now,
                        IsSold = false,
                        Notes = Microsoft.VisualBasic.Interaction.InputBox("Додаткові примітки:", "Додати предмет", "")
                    };
                    _dataService.SaveCommissionShopItem(newItem);
                    LoadCommissionShopItems();
                    ((MainForm)this.Owner)?.UpdateStatusStrip();
                }
                else
                {
                    MessageBox.Show("Будь ласка, введіть коректну ціну.", "Помилка");
                }
            }
            else if (!string.IsNullOrWhiteSpace(paintingIdStr))
            {
                MessageBox.Show("Будь ласка, введіть коректний ID картини.", "Помилка");
            }
        }

        private void BtnEditItem_Click(object sender, EventArgs e)
        {
            if (dgvCommissionShopItems.SelectedRows.Count > 0)
            {
                int selectedItemId = (int)dgvCommissionShopItems.SelectedRows[0].Cells["Id"].Value;
                var existingItem = _dataService.GetAllCommissionShopItems().FirstOrDefault(item => item.Id == selectedItemId);

                if (existingItem != null)
                {
                    string newAskingPriceStr = Microsoft.VisualBasic.Interaction.InputBox("Редагувати запитувану ціну:", "Редагувати предмет", existingItem.AskingPrice.ToString());
                    if (decimal.TryParse(newAskingPriceStr, out decimal newAskingPrice))
                    {
                        existingItem.AskingPrice = newAskingPrice;
                    }
                    else if (!string.IsNullOrWhiteSpace(newAskingPriceStr))
                    {
                        MessageBox.Show("Будь ласка, введіть коректну ціну.", "Помилка");
                        return;
                    }

                    string newIsSoldStr = Microsoft.VisualBasic.Interaction.InputBox("Продано? (Так/Ні):", "Редагувати предмет", existingItem.IsSold ? "Так" : "Ні");
                    existingItem.IsSold = newIsSoldStr.Equals("Так", StringComparison.OrdinalIgnoreCase);

                    if (existingItem.IsSold)
                    {
                        string newSalePriceStr = Microsoft.VisualBasic.Interaction.InputBox("Введіть ціну продажу (якщо продано):", "Редагувати предмет", existingItem.SalePrice?.ToString() ?? "");
                        if (decimal.TryParse(newSalePriceStr, out decimal newSalePrice))
                        {
                            existingItem.SalePrice = newSalePrice;
                        }
                        else if (!string.IsNullOrWhiteSpace(newSalePriceStr))
                        {
                            MessageBox.Show("Будь ласка, введіть коректну ціну продажу.", "Помилка");
                            return;
                        }
                        existingItem.SaleDate = DateTime.Now; 
                    }
                    else
                    {
                        existingItem.SalePrice = null;
                        existingItem.SaleDate = null;
                    }

                    existingItem.Notes = Microsoft.VisualBasic.Interaction.InputBox("Редагувати примітки:", "Редагувати предмет", existingItem.Notes);

                    _dataService.SaveCommissionShopItem(existingItem);
                    LoadCommissionShopItems();
                    ((MainForm)this.Owner)?.UpdateStatusStrip();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть предмет для редагування.", "Помилка");
            }
        }

        private void BtnDeleteItem_Click(object sender, EventArgs e)
        {
            if (dgvCommissionShopItems.SelectedRows.Count > 0)
            {
                int selectedItemId = (int)dgvCommissionShopItems.SelectedRows[0].Cells["Id"].Value;
                var selectedItemTitle = dgvCommissionShopItems.SelectedRows[0].Cells["НазваКартини"].Value?.ToString() ?? "обраний предмет";

                if (MessageBox.Show($"Ви впевнені, що хочете видалити '{selectedItemTitle}' з цього магазину?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _dataService.DeleteCommissionShopItem(selectedItemId);
                    LoadCommissionShopItems();
                    ((MainForm)this.Owner)?.UpdateStatusStrip();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть предмет для видалення.", "Помилка");
            }
        }
    }
}