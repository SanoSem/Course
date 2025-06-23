namespace PaintingGuide
{
    partial class AuctionLotEditForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbPainting = new System.Windows.Forms.ComboBox();
            this.txtLotNumber = new System.Windows.Forms.TextBox();
            this.txtStartingPrice = new System.Windows.Forms.TextBox();
            this.txtFinalPrice = new System.Windows.Forms.TextBox();
            this.chkIsSold = new System.Windows.Forms.CheckBox();
            this.txtBuyerInfo = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPainting = new System.Windows.Forms.Label();
            this.lblLotNumber = new System.Windows.Forms.Label();
            this.lblStartingPrice = new System.Windows.Forms.Label();
            this.lblFinalPrice = new System.Windows.Forms.Label();
            this.lblBuyerInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // cmbPainting
            //
            this.cmbPainting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPainting.FormattingEnabled = true;
            this.cmbPainting.Location = new System.Drawing.Point(140, 20);
            this.cmbPainting.Name = "cmbPainting";
            this.cmbPainting.Size = new System.Drawing.Size(250, 24);
            this.cmbPainting.TabIndex = 0;
            //
            // txtLotNumber
            //
            this.txtLotNumber.Location = new System.Drawing.Point(140, 60);
            this.txtLotNumber.Name = "txtLotNumber";
            this.txtLotNumber.Size = new System.Drawing.Size(100, 22);
            this.txtLotNumber.TabIndex = 1;
            this.txtLotNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotNumber_KeyPress);
            //
            // txtStartingPrice
            //
            this.txtStartingPrice.Location = new System.Drawing.Point(140, 100);
            this.txtStartingPrice.Name = "txtStartingPrice";
            this.txtStartingPrice.Size = new System.Drawing.Size(150, 22);
            this.txtStartingPrice.TabIndex = 2;
            this.txtStartingPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            //
            // txtFinalPrice
            //
            this.txtFinalPrice.Location = new System.Drawing.Point(140, 140);
            this.txtFinalPrice.Name = "txtFinalPrice";
            this.txtFinalPrice.Size = new System.Drawing.Size(150, 22);
            this.txtFinalPrice.TabIndex = 3;
            this.txtFinalPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            //
            // chkIsSold
            //
            this.chkIsSold.AutoSize = true;
            this.chkIsSold.Location = new System.Drawing.Point(300, 142);
            this.chkIsSold.Name = "chkIsSold";
            this.chkIsSold.Size = new System.Drawing.Size(78, 20);
            this.chkIsSold.TabIndex = 4;
            this.chkIsSold.Text = "Продано";
            this.chkIsSold.UseVisualStyleBackColor = true;
            this.chkIsSold.CheckedChanged += new System.EventHandler(this.chkIsSold_CheckedChanged);
            //
            // txtBuyerInfo
            //
            this.txtBuyerInfo.Location = new System.Drawing.Point(140, 180);
            this.txtBuyerInfo.Name = "txtBuyerInfo";
            this.txtBuyerInfo.Size = new System.Drawing.Size(250, 22);
            this.txtBuyerInfo.TabIndex = 5;
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(140, 230);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Зберегти";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(260, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Відміна";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // lblPainting
            //
            this.lblPainting.AutoSize = true;
            this.lblPainting.Location = new System.Drawing.Point(20, 23);
            this.lblPainting.Name = "lblPainting";
            this.lblPainting.Size = new System.Drawing.Size(59, 16);
            this.lblPainting.TabIndex = 8;
            this.lblPainting.Text = "Картина:";
            //
            // lblLotNumber
            //
            this.lblLotNumber.AutoSize = true;
            this.lblLotNumber.Location = new System.Drawing.Point(20, 63);
            this.lblLotNumber.Name = "lblLotNumber";
            this.lblLotNumber.Size = new System.Drawing.Size(51, 16);
            this.lblLotNumber.TabIndex = 9;
            this.lblLotNumber.Text = "№ лота:";
            //
            // lblStartingPrice
            //
            this.lblStartingPrice.AutoSize = true;
            this.lblStartingPrice.Location = new System.Drawing.Point(20, 103);
            this.lblStartingPrice.Name = "lblStartingPrice";
            this.lblStartingPrice.Size = new System.Drawing.Size(117, 16);
            this.lblStartingPrice.TabIndex = 10;
            this.lblStartingPrice.Text = "Початкова ціна:";
            //
            // lblFinalPrice
            //
            this.lblFinalPrice.AutoSize = true;
            this.lblFinalPrice.Location = new System.Drawing.Point(20, 143);
            this.lblFinalPrice.Name = "lblFinalPrice";
            this.lblFinalPrice.Size = new System.Drawing.Size(95, 16);
            this.lblFinalPrice.TabIndex = 11;
            this.lblFinalPrice.Text = "Кінцева ціна:";
            //
            // lblBuyerInfo
            //
            this.lblBuyerInfo.AutoSize = true;
            this.lblBuyerInfo.Location = new System.Drawing.Point(20, 183);
            this.lblBuyerInfo.Name = "lblBuyerInfo";
            this.lblBuyerInfo.Size = new System.Drawing.Size(71, 16);
            this.lblBuyerInfo.TabIndex = 12;
            this.lblBuyerInfo.Text = "Покупець:";
            //
            // AuctionLotEditForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 280);
            this.Controls.Add(this.lblBuyerInfo);
            this.Controls.Add(this.lblFinalPrice);
            this.Controls.Add(this.lblStartingPrice);
            this.Controls.Add(this.lblLotNumber);
            this.Controls.Add(this.lblPainting);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBuyerInfo);
            this.Controls.Add(this.chkIsSold);
            this.Controls.Add(this.txtFinalPrice);
            this.Controls.Add(this.txtStartingPrice);
            this.Controls.Add(this.txtLotNumber);
            this.Controls.Add(this.cmbPainting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuctionLotEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редагувати лот аукціону";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPainting;
        private System.Windows.Forms.TextBox txtLotNumber;
        private System.Windows.Forms.TextBox txtStartingPrice;
        private System.Windows.Forms.TextBox txtFinalPrice;
        private System.Windows.Forms.CheckBox chkIsSold;
        private System.Windows.Forms.TextBox txtBuyerInfo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPainting;
        private System.Windows.Forms.Label lblLotNumber;
        private System.Windows.Forms.Label lblStartingPrice;
        private System.Windows.Forms.Label lblFinalPrice;
        private System.Windows.Forms.Label lblBuyerInfo;
    }
}