using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Сursova.Models;
using Сursova.Services;
using System.ComponentModel;

namespace Сursova.Render
{
    public partial class CollectionItemEditForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public CollectionItem CollectionItem { get; private set; }
        private readonly DataService _dataService;

        private ComboBox cmbPainting;
        private CheckBox chkIsOriginal;
        private DateTimePicker dtpAcquisitionDate;
        private TextBox txtAcquisitionPrice;
        private TextBox txtCondition;
        private RichTextBox txtNotes;
        private Button btnSave;
        private Button btnCancel;

        // Конструктор для додавання нового елемента
        public CollectionItemEditForm(DataService dataService)
        {
            _dataService = dataService;
            CollectionItem = new CollectionItem { AcquisitionDate = DateTime.Today, IsOriginal = true }; // Початкові значення
            InitializeComponent();
            LoadPaintingsIntoComboBox();
            LoadCollectionItemData();
        }

        // Конструктор для редагування існуючого елемента
        public CollectionItemEditForm(DataService dataService, CollectionItem item)
        {
            _dataService = dataService;
            CollectionItem = item; // Передавання існуючого елемента для редагування
            InitializeComponent();
            LoadPaintingsIntoComboBox();
            LoadCollectionItemData();
        }

        private void InitializeComponent()
        {
            cmbPainting = new ComboBox();
            chkIsOriginal = new CheckBox();
            dtpAcquisitionDate = new DateTimePicker();
            txtAcquisitionPrice = new TextBox();
            txtCondition = new TextBox();
            txtNotes = new RichTextBox();
            btnSave = new Button();
            btnCancel = new Button();

            SuspendLayout();

            // Labels
            var lblPainting = new Label() { Text = "Картина:", Location = new Point(12, 15), Size = new Size(120, 23) };
            var lblIsOriginal = new Label() { Text = "Оригінал:", Location = new Point(12, 45), Size = new Size(120, 23) };
            var lblAcquisitionDate = new Label() { Text = "Дата придбання:", Location = new Point(12, 75), Size = new Size(120, 23) };
            var lblAcquisitionPrice = new Label() { Text = "Ціна придбання:", Location = new Point(12, 105), Size = new Size(120, 23) };
            var lblCondition = new Label() { Text = "Стан:", Location = new Point(12, 135), Size = new Size(120, 23) };
            var lblNotes = new Label() { Text = "Примітки:", Location = new Point(12, 165), Size = new Size(120, 23) };

            // ComboBox для картин
            cmbPainting.Location = new Point(140, 12);
            cmbPainting.Size = new Size(250, 24);
            cmbPainting.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPainting.Name = "cmbPainting";
            cmbPainting.DisplayMember = "Title";
            cmbPainting.ValueMember = "Id";

            // CheckBox для оригінальності
            chkIsOriginal.Location = new Point(140, 45);
            chkIsOriginal.Size = new Size(80, 23);
            chkIsOriginal.Name = "chkIsOriginal";
            chkIsOriginal.Text = "";

            // DateTimePicker для дати придбання
            dtpAcquisitionDate.Location = new Point(140, 75);
            dtpAcquisitionDate.Size = new Size(250, 22);
            dtpAcquisitionDate.Format = DateTimePickerFormat.Short;
            dtpAcquisitionDate.Name = "dtpAcquisitionDate";

            // TextBox для ціни придбання
            txtAcquisitionPrice.Location = new Point(140, 105);
            txtAcquisitionPrice.Size = new Size(250, 22);
            txtAcquisitionPrice.Name = "txtAcquisitionPrice";
            txtAcquisitionPrice.KeyPress += new KeyPressEventHandler(txtAcquisitionPrice_KeyPress); // Для валідації вводу

            // TextBox для стану
            txtCondition.Location = new Point(140, 135);
            txtCondition.Size = new Size(250, 22);
            txtCondition.Name = "txtCondition";

            // RichTextBox для приміток
            txtNotes.Location = new Point(140, 165);
            txtNotes.Size = new Size(250, 100);
            txtNotes.Name = "txtNotes";

            // Buttons
            btnSave.Text = "Зберегти";
            btnSave.Location = new Point(140, 280);
            btnSave.Size = new Size(100, 30);
            btnSave.Name = "btnSave";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += new EventHandler(btnSave_Click);

            btnCancel.Text = "Скасувати";
            btnCancel.Location = new Point(250, 280);
            btnCancel.Size = new Size(100, 30);
            btnCancel.Name = "btnCancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += new EventHandler(btnCancel_Click);

            // Додаємо елементи керування на форму
            Controls.Add(lblPainting);
            Controls.Add(lblIsOriginal);
            Controls.Add(lblAcquisitionDate);
            Controls.Add(lblAcquisitionPrice);
            Controls.Add(lblCondition);
            Controls.Add(lblNotes);

            Controls.Add(cmbPainting);
            Controls.Add(chkIsOriginal);
            Controls.Add(dtpAcquisitionDate);
            Controls.Add(txtAcquisitionPrice);
            Controls.Add(txtCondition);
            Controls.Add(txtNotes);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            // Налаштування форми
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 330);
            Text = "Редагувати елемент колекції";
            Name = "CollectionItemEditForm";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;

            ResumeLayout(false);
            PerformLayout();
        }

        private void LoadPaintingsIntoComboBox()
        {
            var paintings = _dataService.GetAllPaintings();
            cmbPainting.DataSource = paintings;
            cmbPainting.DisplayMember = "Title"; 
            cmbPainting.ValueMember = "Id";
        }

        private void LoadCollectionItemData()
        {
            if (CollectionItem != null)
            {
                if (CollectionItem.Painting != null)
                {
                    cmbPainting.SelectedValue = CollectionItem.Painting.Id;
                }
                else
                {
                    if (cmbPainting.Items.Count > 0)
                    {
                        cmbPainting.SelectedIndex = 0;
                    }
                }

                chkIsOriginal.Checked = CollectionItem.IsOriginal;
                dtpAcquisitionDate.Value = CollectionItem.AcquisitionDate;
                txtAcquisitionPrice.Text = CollectionItem.AcquisitionPrice?.ToString("0.00");
                txtCondition.Text = CollectionItem.Condition;
                txtNotes.Text = CollectionItem.Notes;

                if (CollectionItem.Id == 0) 
                {
                    Text = "Додати елемент до колекції";
                }
                else
                {
                    Text = "Редагувати елемент колекції";
                }
            }
        }

        private void SaveCollectionItemData()
        {
            if (cmbPainting.SelectedValue != null)
            {
                CollectionItem.PaintingId = (int)cmbPainting.SelectedValue;
            }
            else
            {
                CollectionItem.PaintingId = 0; 
            }

            CollectionItem.IsOriginal = chkIsOriginal.Checked;
            CollectionItem.AcquisitionDate = dtpAcquisitionDate.Value;

            if (decimal.TryParse(txtAcquisitionPrice.Text.Replace('.', ','), out decimal price)) 
            {
                CollectionItem.AcquisitionPrice = price;
            }
            else
            {
                CollectionItem.AcquisitionPrice = null; 
            }

            CollectionItem.Condition = txtCondition.Text.Trim();
            CollectionItem.Notes = txtNotes.Text.Trim();
        }

        private bool ValidateForm()
        {
            if (cmbPainting.SelectedValue == null || (int)cmbPainting.SelectedValue == 0)
            {
                MessageBox.Show("Будь ласка, оберіть картину.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPainting.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCondition.Text))
            {
                MessageBox.Show("Будь ласка, введіть стан картини.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCondition.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtAcquisitionPrice.Text) && !decimal.TryParse(txtAcquisitionPrice.Text.Replace('.', ','), out _))
            {
                MessageBox.Show("Ціна придбання повинна бути числом.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAcquisitionPrice.Focus();
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SaveCollectionItemData();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtAcquisitionPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.' || e.KeyChar == ',') && ((TextBox)sender).Text.IndexOfAny(new char[] { '.', ',' }) > -1)
            {
                e.Handled = true;
            }
        }
    }
}