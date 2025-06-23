using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Сursova.Models;
using Сursova.Services;

namespace Сursova.Render
{
    public partial class CollectorsForm : Form
    {
        private readonly DataService _dataService;
        private BindingList<Collector> _collectors;
        private DataGridView dataGridViewCollectors;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnViewCollection;

        public CollectorsForm(DataService dataService)
        {
            _dataService = dataService;
            InitializeComponent();
            LoadCollectors();
            SetupGrid();
        }

        private void InitializeComponent()
        {
            dataGridViewCollectors = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnViewCollection = new Button(); 

            ((ISupportInitialize)dataGridViewCollectors).BeginInit();
            SuspendLayout();

            // dataGridViewCollectors
            dataGridViewCollectors.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCollectors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCollectors.Location = new Point(12, 12);
            dataGridViewCollectors.Name = "dataGridViewCollectors";
            dataGridViewCollectors.RowHeadersWidth = 51;
            dataGridViewCollectors.RowTemplate.Height = 24;
            dataGridViewCollectors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCollectors.Size = new Size(760, 320);
            dataGridViewCollectors.TabIndex = 0;
            dataGridViewCollectors.SelectionChanged += new EventHandler(dataGridViewCollectors_SelectionChanged);
            dataGridViewCollectors.CellDoubleClick += new DataGridViewCellEventHandler(dataGridViewCollectors_CellDoubleClick);

            // Налаштування кнопок
            int buttonWidth = 120;
            int buttonHeight = 30;
            int margin = 10;
            int startY = dataGridViewCollectors.Bottom + margin;

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

            btnViewCollection.Text = "Переглянути колекцію";
            btnViewCollection.Size = new Size(buttonWidth + 40, buttonHeight);
            btnViewCollection.Location = new Point(btnDelete.Right + margin, startY);
            btnViewCollection.Click += new EventHandler(btnViewCollection_Click);

            // Додавання елементів управління на форму
            Controls.Add(dataGridViewCollectors);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnViewCollection);

            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Text = "Колекціонери";
            ((ISupportInitialize)dataGridViewCollectors).EndInit();
            ResumeLayout(false);
        }

        private void LoadCollectors()
        {
            _collectors = new BindingList<Collector>(_dataService.GetAllCollectors());
            dataGridViewCollectors.DataSource = _collectors;
            UpdateButtonsState(); 
        }

        private void SetupGrid()
        {
            dataGridViewCollectors.AutoGenerateColumns = false;
            dataGridViewCollectors.Columns.Clear();

            dataGridViewCollectors.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "ID", DataPropertyName = "Id", ReadOnly = true });
            dataGridViewCollectors.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Ім'я", DataPropertyName = "Name" });
            dataGridViewCollectors.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Контактна інформація", DataPropertyName = "ContactInfo" });
        }
        private void dataGridViewCollectors_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            bool hasSelection = dataGridViewCollectors.SelectedRows.Count > 0;
            btnEdit.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
            btnViewCollection.Enabled = hasSelection;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Додавання колекціонера буде реалізовано пізніше.", "Інформація");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewCollectors.SelectedRows.Count > 0)
            {
                var selectedCollector = (Collector)dataGridViewCollectors.SelectedRows[0].DataBoundItem;
                MessageBox.Show($"Редагування колекціонера '{selectedCollector.Name}' буде реалізовано пізніше.", "Інформація");
            }
            else
            {
                MessageBox.Show("Оберіть колекціонера для редагування.", "Увага");
            }
        }

        private void dataGridViewCollectors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCollectors.SelectedRows.Count > 0)
            {
                var selectedCollector = (Collector)dataGridViewCollectors.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"Видалити колекціонера '{selectedCollector.Name}'? Це також видалить усі записи про його колекцію.",
                    "Підтвердження видалення",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _dataService.DeleteCollector(selectedCollector.Id);
                    LoadCollectors(); 
                }
            }
            else
            {
                MessageBox.Show("Оберіть колекціонера для видалення.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnViewCollection_Click(object sender, EventArgs e)
        {
            if (dataGridViewCollectors.SelectedRows.Count > 0)
            {
                var selectedCollector = (Collector)dataGridViewCollectors.SelectedRows[0].DataBoundItem;
                using (var form = new CollectionItemsForm(_dataService, selectedCollector))
                {
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Оберіть колекціонера, щоб переглянути його колекцію.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}