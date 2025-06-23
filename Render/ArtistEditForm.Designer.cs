namespace PaintingGuide
{
    partial class ArtistEditForm
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
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.dtpDeathDate = new System.Windows.Forms.DateTimePicker();
            this.chkIsAlive = new System.Windows.Forms.CheckBox();
            this.txtNationality = new System.Windows.Forms.TextBox();
            this.txtBiography = new System.Windows.Forms.RichTextBox();
            this.txtStyles = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblDeathDate = new System.Windows.Forms.Label();
            this.lblNationality = new System.Windows.Forms.Label();
            this.lblBiography = new System.Windows.Forms.Label();
            this.lblStyles = new System.Windows.Forms.Label();
            this.lblPhotoPath = new System.Windows.Forms.Label();
            this.txtPhotoPath = new System.Windows.Forms.TextBox();
            this.btnBrowsePhoto = new System.Windows.Forms.Button();
            this.picArtistPhoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picArtistPhoto)).BeginInit();
            this.SuspendLayout();
            //
            // txtFirstName
            //
            this.txtFirstName.Location = new System.Drawing.Point(130, 20);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(220, 22);
            this.txtFirstName.TabIndex = 0;
            //
            // txtLastName
            //
            this.txtLastName.Location = new System.Drawing.Point(130, 50);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(220, 22);
            this.txtLastName.TabIndex = 1;
            //
            // dtpBirthDate
            //
            this.dtpBirthDate.Checked = false;
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(130, 80);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.ShowCheckBox = true;
            this.dtpBirthDate.Size = new System.Drawing.Size(220, 22);
            this.dtpBirthDate.TabIndex = 2;
            //
            // dtpDeathDate
            //
            this.dtpDeathDate.Checked = false;
            this.dtpDeathDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeathDate.Location = new System.Drawing.Point(130, 110);
            this.dtpDeathDate.Name = "dtpDeathDate";
            this.dtpDeathDate.ShowCheckBox = true;
            this.dtpDeathDate.Size = new System.Drawing.Size(220, 22);
            this.dtpDeathDate.TabIndex = 3;
            //
            // chkIsAlive
            //
            this.chkIsAlive.AutoSize = true;
            this.chkIsAlive.Location = new System.Drawing.Point(370, 112);
            this.chkIsAlive.Name = "chkIsAlive";
            this.chkIsAlive.Size = new System.Drawing.Size(65, 20);
            this.chkIsAlive.TabIndex = 4;
            this.chkIsAlive.Text = "Живий";
            this.chkIsAlive.UseVisualStyleBackColor = true;
            this.chkIsAlive.CheckedChanged += new System.EventHandler(this.chkIsAlive_CheckedChanged);
            //
            // txtNationality
            //
            this.txtNationality.Location = new System.Drawing.Point(130, 140);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(220, 22);
            this.txtNationality.TabIndex = 5;
            //
            // txtBiography
            //
            this.txtBiography.Location = new System.Drawing.Point(130, 170);
            this.txtBiography.Name = "txtBiography";
            this.txtBiography.Size = new System.Drawing.Size(220, 80);
            this.txtBiography.TabIndex = 6;
            this.txtBiography.Text = "";
            //
            // txtStyles
            //
            this.txtStyles.Location = new System.Drawing.Point(130, 260);
            this.txtStyles.Name = "txtStyles";
            this.txtStyles.Size = new System.Drawing.Size(220, 22);
            this.txtStyles.TabIndex = 7;
            //
            // lblFirstName
            //
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(20, 23);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(33, 16);
            this.lblFirstName.TabIndex = 8;
            this.lblFirstName.Text = "Ім\'я:";
            //
            // lblLastName
            //
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(20, 53);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(73, 16);
            this.lblLastName.TabIndex = 9;
            this.lblLastName.Text = "Прізвище:";
            //
            // lblBirthDate
            //
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(20, 83);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(107, 16);
            this.lblBirthDate.TabIndex = 10;
            this.lblBirthDate.Text = "Дата народж.:";
            //
            // lblDeathDate
            //
            this.lblDeathDate.AutoSize = true;
            this.lblDeathDate.Location = new System.Drawing.Point(20, 113);
            this.lblDeathDate.Name = "lblDeathDate";
            this.lblDeathDate.Size = new System.Drawing.Size(89, 16);
            this.lblDeathDate.TabIndex = 11;
            this.lblDeathDate.Text = "Дата смерті:";
            //
            // lblNationality
            //
            this.lblNationality.AutoSize = true;
            this.lblNationality.Location = new System.Drawing.Point(20, 143);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(104, 16);
            this.lblNationality.TabIndex = 12;
            this.lblNationality.Text = "Національність:";
            //
            // lblBiography
            //
            this.lblBiography.AutoSize = true;
            this.lblBiography.Location = new System.Drawing.Point(20, 173);
            this.lblBiography.Name = "lblBiography";
            this.lblBiography.Size = new System.Drawing.Size(77, 16);
            this.lblBiography.TabIndex = 13;
            this.lblBiography.Text = "Біографія:";
            //
            // lblStyles
            //
            this.lblStyles.AutoSize = true;
            this.lblStyles.Location = new System.Drawing.Point(20, 263);
            this.lblStyles.Name = "lblStyles";
            this.lblStyles.Size = new System.Drawing.Size(46, 16);
            this.lblStyles.TabIndex = 14;
            this.lblStyles.Text = "Стилі:";
            //
            // lblPhotoPath
            //
            this.lblPhotoPath.AutoSize = true;
            this.lblPhotoPath.Location = new System.Drawing.Point(20, 293);
            this.lblPhotoPath.Name = "lblPhotoPath";
            this.lblPhotoPath.Size = new System.Drawing.Size(95, 16);
            this.lblPhotoPath.TabIndex = 15;
            this.lblPhotoPath.Text = "Шлях до фото:";
            //
            // txtPhotoPath
            //
            this.txtPhotoPath.Location = new System.Drawing.Point(130, 290);
            this.txtPhotoPath.Name = "txtPhotoPath";
            this.txtPhotoPath.ReadOnly = true;
            this.txtPhotoPath.Size = new System.Drawing.Size(220, 22);
            this.txtPhotoPath.TabIndex = 16;
            //
            // btnBrowsePhoto
            //
            this.btnBrowsePhoto.Location = new System.Drawing.Point(370, 287);
            this.btnBrowsePhoto.Name = "btnBrowsePhoto";
            this.btnBrowsePhoto.Size = new System.Drawing.Size(100, 28);
            this.btnBrowsePhoto.TabIndex = 17;
            this.btnBrowsePhoto.Text = "Огляд...";
            this.btnBrowsePhoto.UseVisualStyleBackColor = true;
            this.btnBrowsePhoto.Click += new System.EventHandler(this.btnBrowsePhoto_Click);
            //
            // picArtistPhoto
            //
            this.picArtistPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picArtistPhoto.Location = new System.Drawing.Point(370, 20);
            this.picArtistPhoto.Name = "picArtistPhoto";
            this.picArtistPhoto.Size = new System.Drawing.Size(120, 80);
            this.picArtistPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picArtistPhoto.TabIndex = 18;
            this.picArtistPhoto.TabStop = false;
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(130, 380);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Зберегти";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(250, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Відміна";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // ArtistEditForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 435);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.picArtistPhoto);
            this.Controls.Add(this.btnBrowsePhoto);
            this.Controls.Add(this.txtPhotoPath);
            this.Controls.Add(this.lblPhotoPath);
            this.Controls.Add(this.lblStyles);
            this.Controls.Add(this.lblBiography);
            this.Controls.Add(this.lblNationality);
            this.Controls.Add(this.lblDeathDate);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtStyles);
            this.Controls.Add(this.txtBiography);
            this.Controls.Add(this.txtNationality);
            this.Controls.Add(this.chkIsAlive);
            this.Controls.Add(this.dtpDeathDate);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ArtistEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редагувати художника";
            ((System.ComponentModel.ISupportInitialize)(this.picArtistPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.DateTimePicker dtpDeathDate;
        private System.Windows.Forms.CheckBox chkIsAlive;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.RichTextBox txtBiography;
        private System.Windows.Forms.TextBox txtStyles;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblDeathDate;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.Label lblBiography;
        private System.Windows.Forms.Label lblStyles;
        private System.Windows.Forms.Label lblPhotoPath;
        private System.Windows.Forms.TextBox txtPhotoPath;
        private System.Windows.Forms.Button btnBrowsePhoto;
        private System.Windows.Forms.PictureBox picArtistPhoto;
    }
}