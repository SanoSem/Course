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

namespace PaintingGuide
{
    public partial class PersonalCollectionItemEditForm : Form
    {
        private readonly DataService _dataService;
        private PersonalCollectionItem _collectionItem;
        private int _collectorId;
        private CollectorType _collectorType; 
        public PersonalCollectionItem CollectionItem
        {
            get { return _collectionItem; }
        }
        public PersonalCollectionItemEditForm(DataService dataService, int collectorId)
        {
            InitializeComponent();
            _dataService = dataService;
            _collectorId = collectorId;
            _collectionItem = new PersonalCollectionItem { CollectorId = _collectorId, PurchaseDate = DateTime.Today };

            Collector collector = _dataService.GetCollectorById(_collectorId);
            _collectorType = collector.Type;

            SetupFormForNewItem();
            LoadPaintingsIntoComboBox();
            LoadCollectionItemData();
            SetupFormLabels(); 
        }

        public PersonalCollectionItemEditForm(DataService dataService, int collectorId, PersonalCollectionItem item)
        {
            InitializeComponent();
            _dataService = dataService;
            _collectorId = collectorId;
            _collectionItem = item; 
            Collector collector = _dataService.GetCollectorById(_collectorId);
            _collectorType = collector.Type;

            LoadPaintingsIntoComboBox();
            LoadCollectionItemData();
            SetupFormLabels(); 
        }

        private void SetupFormForNewItem()
        {
            this.Text = "Додати елемент до колекції";
            // Всі інші початкові налаштування для нового елемента
        }

        private void LoadPaintingsIntoComboBox()
        {
            var paintings = _dataService.GetAllPaintings();
            cmbPainting.DataSource = paintings;
            cmbPainting.DisplayMember = "Title";
            cmbPainting.ValueMember = "Id";

            if (_collectionItem.PaintingId > 0)
            {
                cmbPainting.SelectedValue = _collectionItem.PaintingId;
            }
        }

        private void LoadCollectionItemData()
        {
            // Перевіряє , чи _collectionItem.Painting не є null перед використанням
            if (_collectionItem.PaintingId > 0)
            {
                var painting = _dataService.GetPaintingById(_collectionItem.PaintingId);
                if (painting != null)
                {
                    _collectionItem.Painting = painting;
                    cmbPainting.SelectedValue = painting.Id;
                }
            }

            chkIsOriginal.Checked = _collectionItem.IsOriginal;
            dtpPurchaseDate.Value = _collectionItem.PurchaseDate;
            txtPurchasePrice.Text = _collectionItem.PurchasePrice?.ToString();
            txtPurchaseLocation.Text = _collectionItem.PurchaseLocation;
            txtCurrentValue.Text = _collectionItem.CurrentValue?.ToString();
            txtCondition.Text = _collectionItem.Condition;
            txtStorageLocation.Text = _collectionItem.StorageLocation;
            txtNotes.Text = _collectionItem.Notes;

            this.Text = _collectionItem.Id == 0 ? "Додати елемент до колекції" : $"Редагувати елемент колекції: {_collectionItem.Painting?.Title ?? "Без назви"}";
        }

        //  Налаштування міток форми залежно від типу колекціонера
        private void SetupFormLabels()
        {
            if (_collectorType == CollectorType.ConsignmentShop)
            {
                this.Text = _collectionItem.Id == 0 ? "Додати картину на комісію" : $"Редагувати картину на комісії: {_collectionItem.Painting?.Title ?? "Без назви"}";
                lblPurchaseDate.Text = "Дата Надходження:";
                lblPurchasePrice.Text = "Оціночна Вартість:";
                lblCurrentValue.Text = "Ціна Продажу:";
                lblPurchaseLocation.Text = "Джерело:";
                lblStorageLocation.Text = "Розташування в Магазині:";
            }
            else // Для PrivateCollector, Gallery, Museum
            {
                this.Text = _collectionItem.Id == 0 ? "Додати елемент до колекції" : $"Редагувати елемент колекції: {_collectionItem.Painting?.Title ?? "Без назви"}";
                lblPurchaseDate.Text = "Дата Придбання:";
                lblPurchasePrice.Text = "Ціна Придбання:";
                lblCurrentValue.Text = "Поточна Оцінка:";
                lblPurchaseLocation.Text = "Місце Придбання:";
                lblStorageLocation.Text = "Місце Зберігання:";
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проста валідація
            if (cmbPainting.SelectedValue == null || (int)cmbPainting.SelectedValue == 0)
            {
                MessageBox.Show("Будь ласка, оберіть картину.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _collectionItem.PaintingId = (int)cmbPainting.SelectedValue;
            _collectionItem.IsOriginal = chkIsOriginal.Checked;
            _collectionItem.PurchaseDate = dtpPurchaseDate.Value;

            // Обробка числових полів, які можуть бути null
            if (decimal.TryParse(txtPurchasePrice.Text.Replace('.', ','), out decimal purchasePrice))
            {
                _collectionItem.PurchasePrice = purchasePrice;
            }
            else
            {
                _collectionItem.PurchasePrice = null;
            }

            _collectionItem.PurchaseLocation = txtPurchaseLocation.Text.Trim();

            if (decimal.TryParse(txtCurrentValue.Text.Replace('.', ','), out decimal currentValue))
            {
                _collectionItem.CurrentValue = currentValue;
            }
            else
            {
                _collectionItem.CurrentValue = null;
            }

            _collectionItem.Condition = txtCondition.Text.Trim();
            _collectionItem.StorageLocation = txtStorageLocation.Text.Trim();
            _collectionItem.Notes = txtNotes.Text.Trim();

            DialogResult = DialogResult.OK; // Вказуємо, що форма закривається успішно
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // Вказуємо, що форма закривається без збереження
            this.Close();
        }

        // Дозволяє вводити лише цифри, кому/крапку та керуючі клавіші (backspace, delete)
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // Дозволити лише одну десяткову крапку/кому
            if ((e.KeyChar == '.' || e.KeyChar == ',') && ((sender as TextBox).Text.Contains(".") || (sender as TextBox).Text.Contains(",")))
            {
                e.Handled = true;
            }
        }
    }
}