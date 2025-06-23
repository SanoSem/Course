using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Сursova.Models;
using Сursova.Services;

namespace Сursova.Render
{
    public partial class PersonalCollectionForm : Form
    {
        private readonly DataService _dataService;
        private BindingList<PersonalCollectionItem> _personalCollection;

        private DataGridView dataGridViewCollection;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnViewDetails;

        public PersonalCollectionForm(DataService dataService)
        {
            _dataService = dataService;
            InitializeComponent();
            SetupForm();
            LoadPersonalCollection();
            SetupGrid();
        }

        private void InitializeComponent()
        {
            // Ініціалізація елементів керування, якщо вони не генеруються дизайнером
            dataGridViewCollection = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnViewDetails = new Button();

            // Налаштування DataGridView
            dataGridViewCollection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCollection.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCollection.Location = new Point(12, 12);
            dataGridViewCollection.Name = "dataGridViewCollection";
            dataGridViewCollection.RowHeadersWidth = 51;
            dataGridViewCollection.RowTemplate.Height = 24;
            dataGridViewCollection.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCollection.Size = new Size(760, 320);
            dataGridViewCollection.TabIndex = 0;
            dataGridViewCollection.CellDoubleClick += new DataGridViewCellEventHandler(dataGridViewCollection_CellDoubleClick);
            dataGridViewCollection.SelectionChanged += new EventHandler(dataGridViewCollection_SelectionChanged);

            // Налаштування кнопок
            int buttonWidth = 100;
            int buttonHeight = 30;
            int margin = 10;
            int startY = dataGridViewCollection.Bottom + margin;

            btnAdd.Text = "Додати";
            btnAdd.Size = new Size(buttonWidth, buttonHeight);
            btnAdd.Location = new Point(12, startY);
            btnAdd.Click += new EventHandler(btnAdd_Click);

            btnEdit.Text = "Редагувати";
            btnEdit.Size = new Size(buttonWidth, buttonHeight);
            btnEdit.Location = new Point(btnAdd.Right + margin, startY);
            btnEdit.Click += new EventHandler(btnEdit_Click);

            btnDelete.Text = "Видалити";
            btnDelete.Size = new Size(buttonWidth, buttonHeight);
            btnDelete.Location = new Point(btnEdit.Right + margin, startY);
            btnDelete.Click += new EventHandler(btnDelete_Click);

            btnViewDetails.Text = "Деталі";
            btnViewDetails.Size = new Size(buttonWidth, buttonHeight);
            btnViewDetails.Location = new Point(btnDelete.Right + margin, startY);
            btnViewDetails.Click += new EventHandler(btnViewDetails_Click);


            // Додавання елементів управління на форму
            Controls.Add(dataGridViewCollection);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnViewDetails);

            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461); 
            Text = "Особиста колекція";
            Load += new EventHandler(PersonalCollectionForm_Load);

            ((ISupportInitialize)dataGridViewCollection).EndInit();
            ResumeLayout(false);
        }

        private void SetupForm()
        {
        }

        private void LoadPersonalCollection()
        {
            _personalCollection = new BindingList<PersonalCollectionItem>(_dataService.GetAllPersonalCollectionItems()); 
            dataGridViewCollection.DataSource = _personalCollection;
            UpdateButtonsState();
        }

        private void SetupGrid()
        {
            dataGridViewCollection.AutoGenerateColumns = false;
            dataGridViewCollection.Columns.Clear();

            dataGridViewCollection.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Назва картини", DataPropertyName = "PaintingTitle", ReadOnly = true });
            dataGridViewCollection.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Художник", DataPropertyName = "ArtistFullName", ReadOnly = true });
            dataGridViewCollection.Columns.Add(new DataGridViewCheckBoxColumn() { HeaderText = "Оригінал", DataPropertyName = "IsOriginal" });
            dataGridViewCollection.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Ціна придбання", DataPropertyName = "PurchasePrice", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dataGridViewCollection.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Дата придбання", DataPropertyName = "PurchaseDate", DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" } });
            dataGridViewCollection.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Місце придбання", DataPropertyName = "PurchaseLocation" });
            dataGridViewCollection.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Поточна вартість", DataPropertyName = "CurrentValue", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dataGridViewCollection.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Стан", DataPropertyName = "Condition" });
            dataGridViewCollection.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Примітки", DataPropertyName = "Notes" });
        }

        private void PersonalCollectionForm_Load(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Додавання елемента колекції буде реалізовано пізніше.", "Інформація");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewCollection.SelectedRows.Count > 0)
            {
                var selectedItem = (PersonalCollectionItem)dataGridViewCollection.SelectedRows[0].DataBoundItem; 
                MessageBox.Show($"Редагування елемента колекції '{selectedItem.Painting?.Title ?? "Без назви"}' буде реалізовано пізніше.", "Інформація");
            }
            else
            {
                MessageBox.Show("Оберіть елемент колекції для редагування.", "Увага");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCollection.SelectedRows.Count > 0)
            {
                var selectedItem = (PersonalCollectionItem)dataGridViewCollection.SelectedRows[0].DataBoundItem; // Changed to PersonalCollectionItem
                var result = MessageBox.Show($"Видалити елемент колекції '{selectedItem.Painting?.Title ?? "Без назви"}'?",
                    "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _dataService.DeletePersonalCollectionItem(selectedItem.Id);
                    LoadPersonalCollection();
                }
            }
            else
            {
                MessageBox.Show("Оберіть елемент колекції для видалення.", "Увага");
            }
        }

        private void dataGridViewCollection_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }

        private void dataGridViewCollection_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            bool hasSelection = dataGridViewCollection.SelectedRows.Count > 0;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
            btnViewDetails.Enabled = hasSelection;
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dataGridViewCollection.SelectedRows.Count > 0)
            {
                var selectedItem = (PersonalCollectionItem)dataGridViewCollection.SelectedRows[0].DataBoundItem;
                MessageBox.Show($"Деталі елемента колекції:\n" +
                                $"Назва картини: {selectedItem.Painting?.Title ?? "N/A"}\n" +
                                $"Художник: {selectedItem.Painting?.Artist?.FullName ?? "N/A"}\n" +
                                $"Жанр: {selectedItem.Painting?.Genre ?? "N/A"}\n" +
                                $"Техніка: {selectedItem.Painting?.Technique ?? "N/A"}\n" +
                                $"Оригінал: {(selectedItem.IsOriginal ? "Так" : "Ні")}\n" +
                                $"Дата придбання: {selectedItem.PurchaseDate.ToShortDateString()}\n" +
                                $"Ціна придбання: {selectedItem.PurchasePrice?.ToString("C2") ?? "N/A"}\n" +
                                $"Стан: {selectedItem.Condition}\n" +
                                $"Примітки: {selectedItem.Notes}",
                                "Деталі елемента колекції", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Оберіть елемент колекції для перегляду деталей", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}