using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using Сursova.Models;

namespace Сursova.Render
{
    public partial class CollectorEditForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Collector PrivateCollector { get; private set; }

        private TextBox txtName;
        private TextBox txtContactInfo;
        private TextBox txtAddress;
        private ComboBox cmbCollectorType;
        private Button btnSave;
        private Button btnCancel;

        public CollectorEditForm(Collector collector = null)
        {
            PrivateCollector = collector ?? new Collector();
            InitializeComponent();
            LoadCollectorData();
            SetupEnumComboBox();
        }

        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtContactInfo = new TextBox();
            txtAddress = new TextBox();
            cmbCollectorType = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();

            SuspendLayout();

            Text = PrivateCollector.Id == 0 ? "Додати Колекціонера" : "Редагувати Колекціонера";
            ClientSize = new Size(400, 300);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;

            // txtName
            txtName.Location = new Point(150, 30);
            txtName.Size = new Size(200, 22);
            txtName.Name = "txtName";
            txtName.TabIndex = 0;

            // txtContactInfo
            txtContactInfo.Location = new Point(150, 70);
            txtContactInfo.Size = new Size(200, 22);
            txtContactInfo.Name = "txtContactInfo";
            txtContactInfo.TabIndex = 1;

            // txtAddress
            txtAddress.Location = new Point(150, 110);
            txtAddress.Size = new Size(200, 22);
            txtAddress.Name = "txtAddress";
            txtAddress.TabIndex = 2;

            // cmbCollectorType
            cmbCollectorType.Location = new Point(150, 150);
            cmbCollectorType.Size = new Size(200, 24);
            cmbCollectorType.Name = "cmbCollectorType";
            cmbCollectorType.DropDownStyle = ComboBoxStyle.DropDownList; 
            cmbCollectorType.TabIndex = 3;

            // btnSave
            btnSave.Location = new Point(150, 200);
            btnSave.Size = new Size(90, 30);
            btnSave.Text = "Зберегти";
            btnSave.Name = "btnSave";
            btnSave.TabIndex = 4;
            btnSave.Click += new EventHandler(btnSave_Click);

            // btnCancel
            btnCancel.Location = new Point(260, 200);
            btnCancel.Size = new Size(90, 30);
            btnCancel.Text = "Скасувати";
            btnCancel.Name = "btnCancel";
            btnCancel.TabIndex = 5;
            btnCancel.Click += new EventHandler(btnCancel_Click);

            // Labels
            var lblName = new Label { Text = "Назва:", Location = new Point(30, 30), AutoSize = true };
            var lblContactInfo = new Label { Text = "Контактна інформація:", Location = new Point(30, 70), AutoSize = true };
            var lblAddress = new Label { Text = "Адреса:", Location = new Point(30, 110), AutoSize = true };
            var lblCollectorType = new Label { Text = "Тип колекціонера:", Location = new Point(30, 150), AutoSize = true };

            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblContactInfo);
            Controls.Add(txtContactInfo);
            Controls.Add(lblAddress);
            Controls.Add(txtAddress);
            Controls.Add(lblCollectorType);
            Controls.Add(cmbCollectorType);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            ResumeLayout(false);
            PerformLayout();
        }

        private void SetupEnumComboBox()
        {
            var collectorTypes = Enum.GetValues(typeof(CollectorType))
                                     .Cast<CollectorType>()
                                     .Select(type => new { Value = type, Display = GetEnumDescription(type) })
                                     .ToList();

            cmbCollectorType.DataSource = collectorTypes;
            cmbCollectorType.DisplayMember = "Display";
            cmbCollectorType.ValueMember = "Value";
            cmbCollectorType.SelectedValue = PrivateCollector.Type;
        }

        private string GetEnumDescription(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        private void LoadCollectorData()
        {
            txtName.Text = PrivateCollector.Name;
            txtContactInfo.Text = PrivateCollector.ContactInfo;
            txtAddress.Text = PrivateCollector.Address;
        }

        private void SaveCollectorData()
        {
            PrivateCollector.Name = txtName.Text.Trim();
            PrivateCollector.ContactInfo = txtContactInfo.Text.Trim();
            PrivateCollector.Address = txtAddress.Text.Trim();
            PrivateCollector.Type = (CollectorType)cmbCollectorType.SelectedValue;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введіть назву колекціонера/музею.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SaveCollectorData();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}