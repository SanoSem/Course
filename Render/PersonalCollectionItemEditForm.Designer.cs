
namespace PaintingGuide
{
    partial class PersonalCollectionItemEditForm
    {

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // ... існуюча ініціалізація компонентів ...

            this.lblPurchaseDate = new System.Windows.Forms.Label();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.txtPurchasePrice = new System.Windows.Forms.TextBox();
            this.lblPurchaseLocation = new System.Windows.Forms.Label();
            this.txtPurchaseLocation = new System.Windows.Forms.TextBox();
            this.lblCurrentValue = new System.Windows.Forms.Label();
            this.txtCurrentValue = new System.Windows.Forms.TextBox();
            this.lblStorageLocation = new System.Windows.Forms.Label();
            this.txtStorageLocation = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();

            // ... інші елементи та їх властивості ...

            // Додайте ці контролі до форми (Controls.Add)
            this.Controls.Add(this.lblPurchaseDate);
            this.Controls.Add(this.dtpPurchaseDate);
            this.Controls.Add(this.lblPurchasePrice);
            this.Controls.Add(this.txtPurchasePrice);
            this.Controls.Add(this.lblPurchaseLocation);
            this.Controls.Add(this.txtPurchaseLocation);
            this.Controls.Add(this.lblCurrentValue);
            this.Controls.Add(this.txtCurrentValue);
            this.Controls.Add(this.lblStorageLocation);
            this.Controls.Add(this.txtStorageLocation);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtNotes);
            // ...
        }

        #endregion

        private System.Windows.Forms.Label lblPainting;
        private System.Windows.Forms.ComboBox cmbPainting;
        private System.Windows.Forms.CheckBox chkIsOriginal;
        private System.Windows.Forms.Label lblPurchaseDate; 
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.TextBox txtPurchasePrice;
        private System.Windows.Forms.Label lblPurchaseLocation;
        private System.Windows.Forms.TextBox txtPurchaseLocation;
        private System.Windows.Forms.Label lblCurrentValue;
        private System.Windows.Forms.TextBox txtCurrentValue;
        private System.Windows.Forms.Label lblCondition;
        private System.Windows.Forms.TextBox txtCondition;
        private System.Windows.Forms.Label lblStorageLocation;
        private System.Windows.Forms.TextBox txtStorageLocation;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}