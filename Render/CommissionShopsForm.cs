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
    public partial class CommissionShopsForm : Form
    {
        private readonly DataService _dataService;
        private DataGridView dgvCommissionShops;
        private Button btnAddShop;
        private Button btnEditShop;
        private Button btnDeleteShop;
        private Button btnViewItems;

        public CommissionShopsForm(DataService dataService)
        {
            _dataService = dataService;
            InitializeComponent();
            SetupForm();
            LoadCommissionShops();
        }

        private void SetupForm()
        {
            Text = "Комісійні магазини";
            Size = new Size(800, 600);
            StartPosition = FormStartPosition.CenterParent;

            // DataGridView для відображення магазинів
            dgvCommissionShops = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 400,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            Controls.Add(dgvCommissionShops);

            // Кнопки
            btnAddShop = new Button { Text = "Додати магазин", Dock = DockStyle.Left, Width = 150 };
            btnAddShop.Click += BtnAddShop_Click;
            Controls.Add(btnAddShop);

            btnEditShop = new Button { Text = "Редагувати магазин", Dock = DockStyle.Left, Width = 150 };
            btnEditShop.Click += BtnEditShop_Click;
            Controls.Add(btnEditShop);

            btnDeleteShop = new Button { Text = "Видалити магазин", Dock = DockStyle.Left, Width = 150 };
            btnDeleteShop.Click += BtnDeleteShop_Click;
            Controls.Add(btnDeleteShop);

            btnViewItems = new Button { Text = "Переглянути предмети", Dock = DockStyle.Left, Width = 150 };
            btnViewItems.Click += BtnViewItems_Click;
            Controls.Add(btnViewItems);

            // Панель для кнопок
            Panel panelButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50
            };
            panelButtons.Controls.Add(btnViewItems);
            panelButtons.Controls.Add(btnDeleteShop);
            panelButtons.Controls.Add(btnEditShop);
            panelButtons.Controls.Add(btnAddShop);
            Controls.Add(panelButtons);

            // Оновлюю порядок кнопок, щоб вони йшли справа наліво
            btnAddShop.BringToFront();
            btnEditShop.BringToFront();
            btnDeleteShop.BringToFront();
            btnViewItems.BringToFront();
        }

        private void LoadCommissionShops()
        {
            var shops = _dataService.GetAllCommissionShops();
            dgvCommissionShops.DataSource = shops;

            // Приховуємо стовпець "Items"
            if (dgvCommissionShops.Columns.Contains("Items"))
            {
                dgvCommissionShops.Columns["Items"].Visible = false;
            }
        }

        private void BtnAddShop_Click(object sender, EventArgs e)
        {
            string shopName = Microsoft.VisualBasic.Interaction.InputBox("Введіть назву комісійного магазину:", "Додати магазин", "");
            if (!string.IsNullOrWhiteSpace(shopName))
            {
                string address = Microsoft.VisualBasic.Interaction.InputBox("Введіть адресу:", "Додати магазин", "");
                string contactInfo = Microsoft.VisualBasic.Interaction.InputBox("Введіть контактну інформацію:", "Додати магазин", "");
                string notes = Microsoft.VisualBasic.Interaction.InputBox("Додаткові примітки:", "Додати магазин", "");

                var newShop = new CommissionShop
                {
                    Name = shopName,
                    Address = address,
                    ContactInfo = contactInfo,
                    Notes = notes
                };
                _dataService.SaveCommissionShop(newShop);
                LoadCommissionShops();
                ((MainForm)this.Owner)?.UpdateStatusStrip(); 
            }
        }

        private void BtnEditShop_Click(object sender, EventArgs e)
        {
            if (dgvCommissionShops.SelectedRows.Count > 0)
            {
                var selectedShop = (CommissionShop)dgvCommissionShops.SelectedRows[0].DataBoundItem;

                string newName = Microsoft.VisualBasic.Interaction.InputBox("Редагувати назву магазину:", "Редагувати", selectedShop.Name);
                if (newName == selectedShop.Name) newName = selectedShop.Name; 

                string newAddress = Microsoft.VisualBasic.Interaction.InputBox("Редагувати адресу:", "Редагувати", selectedShop.Address);
                if (newAddress == selectedShop.Address) newAddress = selectedShop.Address;

                string newContactInfo = Microsoft.VisualBasic.Interaction.InputBox("Редагувати контактну інформацію:", "Редагувати", selectedShop.ContactInfo);
                if (newContactInfo == selectedShop.ContactInfo) newContactInfo = selectedShop.ContactInfo;

                string newNotes = Microsoft.VisualBasic.Interaction.InputBox("Редагувати примітки:", "Редагувати", selectedShop.Notes);
                if (newNotes == selectedShop.Notes) newNotes = selectedShop.Notes;


                selectedShop.Name = newName;
                selectedShop.Address = newAddress;
                selectedShop.ContactInfo = newContactInfo;
                selectedShop.Notes = newNotes;

                _dataService.SaveCommissionShop(selectedShop); 
                LoadCommissionShops();
                ((MainForm)this.Owner)?.UpdateStatusStrip();
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть магазин для редагування.", "Помилка");
            }
        }

        private void BtnDeleteShop_Click(object sender, EventArgs e)
        {
            if (dgvCommissionShops.SelectedRows.Count > 0)
            {
                var selectedShop = (CommissionShop)dgvCommissionShops.SelectedRows[0].DataBoundItem;

                if (MessageBox.Show($"Ви впевнені, що хочете видалити магазин '{selectedShop.Name}' та всі пов'язані з ним предмети?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _dataService.DeleteCommissionShop(selectedShop.Id);
                    LoadCommissionShops();
                    ((MainForm)this.Owner)?.UpdateStatusStrip();
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть магазин для видалення.", "Помилка");
            }
        }

        private void BtnViewItems_Click(object sender, EventArgs e)
        {
            if (dgvCommissionShops.SelectedRows.Count > 0)
            {
                var selectedShop = (CommissionShop)dgvCommissionShops.SelectedRows[0].DataBoundItem;
                // Відкриває нову форму для керування предметами в цьому магазині
                var itemsForm = new CommissionShopItemsForm(_dataService, selectedShop.Id);
                itemsForm.ShowDialog();
                ((MainForm)this.Owner)?.UpdateStatusStrip();
                LoadCommissionShops(); // Оновлює список магазинів після можливих змін предметів
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть магазин, щоб переглянути його предмети.", "Помилка");
            }
        }
    }
}