namespace PaintingGuide
{
    partial class PaintingEditForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblArtist = new System.Windows.Forms.Label();
            this.cmbArtist = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.lblTechnique = new System.Windows.Forms.Label();
            this.txtTechnique = new System.Windows.Forms.TextBox();
            this.lblDimensions = new System.Windows.Forms.Label();
            this.txtDimensions = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.lblImagePath = new System.Windows.Forms.Label();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.picPaintingImage = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPaintingImage)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(47, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Назва:";
            //
            // txtTitle
            //
            this.txtTitle.Location = new System.Drawing.Point(130, 20);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(220, 22);
            this.txtTitle.TabIndex = 1;
            //
            // lblArtist
            //
            this.lblArtist.AutoSize = true;
            this.lblArtist.Location = new System.Drawing.Point(20, 53);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(65, 16);
            this.lblArtist.TabIndex = 2;
            this.lblArtist.Text = "Художник:";
            //
            // cmbArtist
            //
            this.cmbArtist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArtist.FormattingEnabled = true;
            this.cmbArtist.Location = new System.Drawing.Point(130, 50);
            this.cmbArtist.Name = "cmbArtist";
            this.cmbArtist.Size = new System.Drawing.Size(220, 24);
            this.cmbArtist.TabIndex = 3;
            //
            // lblYear
            //
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(20, 83);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(30, 16);
            this.lblYear.TabIndex = 4;
            this.lblYear.Text = "Рік:";
            //
            // txtYear
            //
            this.txtYear.Location = new System.Drawing.Point(130, 80);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(100, 22);
            this.txtYear.TabIndex = 5;
            this.txtYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYear_KeyPress);
            //
            // lblGenre
            //
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(20, 113);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(43, 16);
            this.lblGenre.TabIndex = 6;
            this.lblGenre.Text = "Жанр:";
            //
            // txtGenre
            //
            this.txtGenre.Location = new System.Drawing.Point(130, 110);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(220, 22);
            this.txtGenre.TabIndex = 7;
            //
            // lblTechnique
            //
            this.lblTechnique.AutoSize = true;
            this.lblTechnique.Location = new System.Drawing.Point(20, 143);
            this.lblTechnique.Name = "lblTechnique";
            this.lblTechnique.Size = new System.Drawing.Size(61, 16);
            this.lblTechnique.TabIndex = 8;
            this.lblTechnique.Text = "Техніка:";
            //
            // txtTechnique
            //
            this.txtTechnique.Location = new System.Drawing.Point(130, 140);
            this.txtTechnique.Name = "txtTechnique";
            this.txtTechnique.Size = new System.Drawing.Size(220, 22);
            this.txtTechnique.TabIndex = 9;
            //
            // lblDimensions
            //
            this.lblDimensions.AutoSize = true;
            this.lblDimensions.Location = new System.Drawing.Point(20, 173);
            this.lblDimensions.Name = "lblDimensions";
            this.lblDimensions.Size = new System.Drawing.Size(73, 16);
            this.lblDimensions.TabIndex = 10;
            this.lblDimensions.Text = "Розміри:";
            //
            // txtDimensions
            //
            this.txtDimensions.Location = new System.Drawing.Point(130, 170);
            this.txtDimensions.Name = "txtDimensions";
            this.txtDimensions.Size = new System.Drawing.Size(220, 22);
            this.txtDimensions.TabIndex = 11;
            //
            // lblDescription
            //
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 203);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(43, 16);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Опис:";
            //
            // txtDescription
            //
            this.txtDescription.Location = new System.Drawing.Point(130, 200);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(220, 80);
            this.txtDescription.TabIndex = 13;
            this.txtDescription.Text = "";
            //
            // lblImagePath
            //
            this.lblImagePath.AutoSize = true;
            this.lblImagePath.Location = new System.Drawing.Point(20, 293);
            this.lblImagePath.Name = "lblImagePath";
            this.lblImagePath.Size = new System.Drawing.Size(95, 16);
            this.lblImagePath.TabIndex = 14;
            this.lblImagePath.Text = "Шлях до фото:";
            //
            // txtImagePath
            //
            this.txtImagePath.Location = new System.Drawing.Point(130, 290);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.ReadOnly = true;
            this.txtImagePath.Size = new System.Drawing.Size(220, 22);
            this.txtImagePath.TabIndex = 15;
            //
            // btnBrowseImage
            //
            this.btnBrowseImage.Location = new System.Drawing.Point(370, 287);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(100, 28);
            this.btnBrowseImage.TabIndex = 16;
            this.btnBrowseImage.Text = "Огляд...";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            //
            // picPaintingImage
            //
            this.picPaintingImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPaintingImage.Location = new System.Drawing.Point(370, 20);
            this.picPaintingImage.Name = "picPaintingImage";
            this.picPaintingImage.Size = new System.Drawing.Size(120, 80);
            this.picPaintingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPaintingImage.TabIndex = 17;
            this.picPaintingImage.TabStop = false;
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(130, 380);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Зберегти";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(250, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Відміна";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // PaintingEditForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 435);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.picPaintingImage);
            this.Controls.Add(this.btnBrowseImage);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.lblImagePath);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDimensions);
            this.Controls.Add(this.lblDimensions);
            this.Controls.Add(this.txtTechnique);
            this.Controls.Add(this.lblTechnique);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cmbArtist);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaintingEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редагувати картину";
            ((System.ComponentModel.ISupportInitialize)(this.picPaintingImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.ComboBox cmbArtist;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.Label lblTechnique;
        private System.Windows.Forms.TextBox txtTechnique;
        private System.Windows.Forms.Label lblDimensions;
        private System.Windows.Forms.TextBox txtDimensions;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label lblImagePath;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.PictureBox picPaintingImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}