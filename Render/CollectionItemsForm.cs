using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using PaintingGuide;
using Сursova.Models;
using Сursova.Services;

namespace Сursova.Render
{
    public partial class CollectionItemsForm : Form
    {
        private readonly DataService _dataService;
        private readonly Collector _currentCollector;
        private BindingList<PersonalCollectionItem> _collectionItems;

        private DataGridView dataGridViewCollectionItems;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;

        public CollectionItemsForm(DataService dataService, Collector collector)
        {
            _dataService = dataService;
            _currentCollector = collector;
            InitializeComponent();
            SetupForm(); 
            LoadCollectionItems();
            SetupGrid();
        }

        private void InitializeComponent()
        {
            // Код ініціалізації компонентів з Designer.cs
            dataGridViewCollectionItems = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();

            ((ISupportInitialize)dataGridViewCollectionItems).BeginInit();
            SuspendLayout();

            // dataGridViewCollectionItems
            dataGridViewCollectionItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCollectionItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCollectionItems.Location = new Point(12, 12);
            dataGridViewCollectionItems.Name = "dataGridViewCollectionItems";
            dataGridViewCollectionItems.RowHeadersWidth = 51;
            dataGridViewCollectionItems.RowTemplate.Height = 24;
            dataGridViewCollectionItems.Size = new Size(760, 350);
            dataGridViewCollectionItems.TabIndex = 0;
            dataGridViewCollectionItems.SelectionChanged += new EventHandler(dataGridViewCollectionItems_SelectionChanged);


            // btnAdd
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAdd.Location = new Point(12, 370);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 30);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Додати";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += new EventHandler(btnAdd_Click);


            // btnEdit
            btnEdit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEdit.Location = new Point(118, 370);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 30);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Редагувати";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += new EventHandler(btnEdit_Click);


            // btnDelete
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Location = new Point(224, 370);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 30);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Видалити";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += new EventHandler(btnDelete_Click);


            // CollectionItemsForm
            ClientSize = new Size(784, 412);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dataGridViewCollectionItems);
            Name = "CollectionItemsForm";
            Text = "Елементи колекції"; 
            ((ISupportInitialize)dataGridViewCollectionItems).EndInit();
            ResumeLayout(false);
        }

        private void SetupForm()
        {
            // Зміна заголовка форми залежно від типу колекціонера
            switch (_currentCollector.Type)
            {
                case CollectorType.PrivateCollector:
                    Text = $"Особиста колекція: {_currentCollector.Name}";
                    break;
                case CollectorType.Gallery:
                    Text = $"Колекція галереї: {_currentCollector.Name}";
                    break;
                case CollectorType.Museum:
                    Text = $"Колекція музею: {_currentCollector.Name}";
                    break;
                case CollectorType.ConsignmentShop:
                    Text = $"Картини на комісії: {_currentCollector.Name}";
                    break;
                default:
                    Text = $"Колекція: {_currentCollector.Name}";
                    break;
            }
        }

        private void LoadCollectionItems()
        {
            _collectionItems = new BindingList<PersonalCollectionItem>(_dataService.GetPersonalCollectionItemsByCollectorId(_currentCollector.Id));
            dataGridViewCollectionItems.DataSource = _collectionItems;
            UpdateButtonsState();
        }

        private void SetupGrid()
        {
            dataGridViewCollectionItems.AutoGenerateColumns = false;
            dataGridViewCollectionItems.Columns.Clear();

            // Додав стовпці
            dataGridViewCollectionItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", ReadOnly = true, Visible = false }); // Прихований ID
            dataGridViewCollectionItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Painting.Title", HeaderText = "Назва Картини", ReadOnly = true });
            dataGridViewCollectionItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Painting.Artist.FullName", HeaderText = "Художник", ReadOnly = true });
            dataGridViewCollectionItems.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "IsOriginal", HeaderText = "Оригінал", ReadOnly = true });

            // Адаптація заголовків стовпців для комісійних магазинів
            if (_currentCollector.Type == CollectorType.ConsignmentShop)
            {
                dataGridViewCollectionItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PurchaseDate", HeaderText = "Дата Надходження", ReadOnly = true, DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" } });
                dataGridViewCollectionItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PurchasePrice", HeaderText = "Оціночна Вартість", ReadOnly = true, DefaultCellStyle = new DataGridViewCellStyle { Format = "C", NullValue = "N/A" } });
                dataGridViewCollectionItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CurrentValue", HeaderText = "Ціна Продажу", ReadOnly = true, DefaultCellStyle = new DataGridViewCellStyle { Format = "C", NullValue = "N/A" } });
                dataGridViewCollectionItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PurchaseLocation", HeaderText = "Джерело", ReadOnly = true });
                dataGridViewCollectionItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StorageLocation", HeaderText = "Розташування в Магазині", ReadOnly = true });
            }
            else // Для інших типів колекціонерів
            {
                dataGridViewCollectionItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PurchaseDate", HeaderText = "Дата Придбання", ReadOnly = true, DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" } });
                dataGridViewCollectionItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PurchasePrice", HeaderText = "Ціна Придбання", ReadOnly = true, DefaultCellStyle = new DataGridViewCellStyle { Format = "C", NullValue = "N/A" } });
                dataGridViewCollectionItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CurrentValue", HeaderText = "Поточна Оцінка", ReadOnly = true, DefaultCellStyle = new DataGridViewCellStyle { Format = "C", NullValue = "N/A" } });
                dataGridViewCollectionItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PurchaseLocation", HeaderText = "Місце Придбання", ReadOnly = true });
                dataGridViewCollectionItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "StorageLocation", HeaderText = "Місце Зберігання", ReadOnly = true });
            }

            dataGridViewCollectionItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Condition", HeaderText = "Стан", ReadOnly = true });
            dataGridViewCollectionItems.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Notes", HeaderText = "Примітки", ReadOnly = true });
        }

        private void UpdateButtonsState()
        {
            bool hasSelection = dataGridViewCollectionItems.SelectedRows.Count > 0;
            btnAdd.Enabled = true;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new PersonalCollectionItemEditForm(_dataService, _currentCollector.Id))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Використано SavePersonalCollectionItem для додавання нового елемента
                    _dataService.SavePersonalCollectionItem(form.CollectionItem);
                    LoadCollectionItems(); // Перезавантажую список
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewCollectionItems.SelectedRows.Count > 0)
            {
                var selectedItem = (PersonalCollectionItem)dataGridViewCollectionItems.SelectedRows[0].DataBoundItem;
                using (var form = new PersonalCollectionItemEditForm(_dataService, _currentCollector.Id, selectedItem))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _dataService.SavePersonalCollectionItem(form.CollectionItem);
                        LoadCollectionItems();
                    }
                }
            }
            else
            {
                MessageBox.Show("Оберіть елемент колекції для редагування.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCollectionItems.SelectedRows.Count > 0)
            {
                var selectedItem = (PersonalCollectionItem)dataGridViewCollectionItems.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show(
                    $"Ви дійсно бажаєте видалити запис про картину '{selectedItem.Painting?.Title ?? "N/A"}' з колекції?",
                    "Підтвердження видалення",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _dataService.DeletePersonalCollectionItem(selectedItem.Id);
                    LoadCollectionItems(); // Перезавантажуємо список
                }
            }
            else
            {
                MessageBox.Show("Оберіть елемент колекції для видалення.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewCollectionItems_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }
    }
}