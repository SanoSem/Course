namespace PaintingGuide
{
    partial class AuctionsForm
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
            this.dataGridViewAuctions = new System.Windows.Forms.DataGridView();
            this.btnAddAuction = new System.Windows.Forms.Button();
            this.btnEditAuction = new System.Windows.Forms.Button();
            this.btnDeleteAuction = new System.Windows.Forms.Button();
            this.dataGridViewLots = new System.Windows.Forms.DataGridView();
            this.btnAddLot = new System.Windows.Forms.Button();
            this.btnEditLot = new System.Windows.Forms.Button();
            this.btnDeleteLot = new System.Windows.Forms.Button();
            this.lblAuctions = new System.Windows.Forms.Label();
            this.lblLots = new System.Windows.Forms.Label();
            this.groupBoxAuctionDetails = new System.Windows.Forms.GroupBox();
            this.btnCancelAuction = new System.Windows.Forms.Button();
            this.btnSaveAuction = new System.Windows.Forms.Button();
            this.txtAuctionHouse = new System.Windows.Forms.TextBox();
            this.lblAuctionHouse = new System.Windows.Forms.Label();
            this.txtAuctionLocation = new System.Windows.Forms.TextBox();
            this.lblAuctionLocation = new System.Windows.Forms.Label();
            this.dtpAuctionDate = new System.Windows.Forms.DateTimePicker();
            this.lblAuctionDate = new System.Windows.Forms.Label();
            this.txtAuctionName = new System.Windows.Forms.TextBox();
            this.lblAuctionName = new System.Windows.Forms.Label();
            this.btnViewPriceHistory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuctions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLots)).BeginInit();
            this.groupBoxAuctionDetails.SuspendLayout();
            this.SuspendLayout();
            //
            // dataGridViewAuctions
            //
            this.dataGridViewAuctions.AllowUserToAddRows = false;
            this.dataGridViewAuctions.AllowUserToDeleteRows = false;
            this.dataGridViewAuctions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAuctions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAuctions.Location = new System.Drawing.Point(12, 38);
            this.dataGridViewAuctions.MultiSelect = false;
            this.dataGridViewAuctions.Name = "dataGridViewAuctions";
            this.dataGridViewAuctions.ReadOnly = true;
            this.dataGridViewAuctions.RowHeadersWidth = 51;
            this.dataGridViewAuctions.RowTemplate.Height = 24;
            this.dataGridViewAuctions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAuctions.Size = new System.Drawing.Size(650, 200);
            this.dataGridViewAuctions.TabIndex = 0;
            this.dataGridViewAuctions.SelectionChanged += new System.EventHandler(this.dataGridViewAuctions_SelectionChanged);
            this.dataGridViewAuctions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAuctions_CellDoubleClick);
            //
            // btnAddAuction
            //
            this.btnAddAuction.Location = new System.Drawing.Point(12, 244);
            this.btnAddAuction.Name = "btnAddAuction";
            this.btnAddAuction.Size = new System.Drawing.Size(120, 35);
            this.btnAddAuction.TabIndex = 1;
            this.btnAddAuction.Text = "Додати аукціон";
            this.btnAddAuction.UseVisualStyleBackColor = true;
            this.btnAddAuction.Click += new System.EventHandler(this.btnAddAuction_Click);
            //
            // btnEditAuction
            //
            this.btnEditAuction.Location = new System.Drawing.Point(138, 244);
            this.btnEditAuction.Name = "btnEditAuction";
            this.btnEditAuction.Size = new System.Drawing.Size(120, 35);
            this.btnEditAuction.TabIndex = 2;
            this.btnEditAuction.Text = "Редагувати аукціон";
            this.btnEditAuction.UseVisualStyleBackColor = true;
            this.btnEditAuction.Click += new System.EventHandler(this.btnEditAuction_Click);
            //
            // btnDeleteAuction
            //
            this.btnDeleteAuction.Location = new System.Drawing.Point(264, 244);
            this.btnDeleteAuction.Name = "btnDeleteAuction";
            this.btnDeleteAuction.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteAuction.TabIndex = 3;
            this.btnDeleteAuction.Text = "Видалити аукціон";
            this.btnDeleteAuction.UseVisualStyleBackColor = true;
            this.btnDeleteAuction.Click += new System.EventHandler(this.btnDeleteAuction_Click);
            //
            // dataGridViewLots
            //
            this.dataGridViewLots.AllowUserToAddRows = false;
            this.dataGridViewLots.AllowUserToDeleteRows = false;
            this.dataGridViewLots.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLots.Location = new System.Drawing.Point(12, 328);
            this.dataGridViewLots.MultiSelect = false;
            this.dataGridViewLots.Name = "dataGridViewLots";
            this.dataGridViewLots.ReadOnly = true;
            this.dataGridViewLots.RowHeadersWidth = 51;
            this.dataGridViewLots.RowTemplate.Height = 24;
            this.dataGridViewLots.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLots.Size = new System.Drawing.Size(1160, 300);
            this.dataGridViewLots.TabIndex = 4;
            this.dataGridViewLots.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLots_CellDoubleClick);
            this.dataGridViewLots.SelectionChanged += new System.EventHandler(this.dataGridViewLots_SelectionChanged);
            //
            // btnAddLot
            //
            this.btnAddLot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddLot.Location = new System.Drawing.Point(12, 644);
            this.btnAddLot.Name = "btnAddLot";
            this.btnAddLot.Size = new System.Drawing.Size(120, 35);
            this.btnAddLot.TabIndex = 5;
            this.btnAddLot.Text = "Додати лот";
            this.btnAddLot.UseVisualStyleBackColor = true;
            this.btnAddLot.Click += new System.EventHandler(this.btnAddLot_Click);
            //
            // btnEditLot
            //
            this.btnEditLot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditLot.Location = new System.Drawing.Point(138, 644);
            this.btnEditLot.Name = "btnEditLot";
            this.btnEditLot.Size = new System.Drawing.Size(120, 35);
            this.btnEditLot.TabIndex = 6;
            this.btnEditLot.Text = "Редагувати лот";
            this.btnEditLot.UseVisualStyleBackColor = true;
            this.btnEditLot.Click += new System.EventHandler(this.btnEditLot_Click);
            //
            // btnDeleteLot
            //
            this.btnDeleteLot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteLot.Location = new System.Drawing.Point(264, 644);
            this.btnDeleteLot.Name = "btnDeleteLot";
            this.btnDeleteLot.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteLot.TabIndex = 7;
            this.btnDeleteLot.Text = "Видалити лот";
            this.btnDeleteLot.UseVisualStyleBackColor = true;
            this.btnDeleteLot.Click += new System.EventHandler(this.btnDeleteLot_Click);
            //
            // lblAuctions
            //
            this.lblAuctions.AutoSize = true;
            this.lblAuctions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAuctions.Location = new System.Drawing.Point(12, 9);
            this.lblAuctions.Name = "lblAuctions";
            this.lblAuctions.Size = new System.Drawing.Size(91, 20);
            this.lblAuctions.TabIndex = 8;
            this.lblAuctions.Text = "Аукціони";
            //
            // lblLots
            //
            this.lblLots.AutoSize = true;
            this.lblLots.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLots.Location = new System.Drawing.Point(12, 299);
            this.lblLots.Name = "lblLots";
            this.lblLots.Size = new System.Drawing.Size(130, 20);
            this.lblLots.TabIndex = 9;
            this.lblLots.Text = "Лоти аукціону";
            //
            // groupBoxAuctionDetails
            //
            this.groupBoxAuctionDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAuctionDetails.Controls.Add(this.btnCancelAuction);
            this.groupBoxAuctionDetails.Controls.Add(this.btnSaveAuction);
            this.groupBoxAuctionDetails.Controls.Add(this.txtAuctionHouse);
            this.groupBoxAuctionDetails.Controls.Add(this.lblAuctionHouse);
            this.groupBoxAuctionDetails.Controls.Add(this.txtAuctionLocation);
            this.groupBoxAuctionDetails.Controls.Add(this.lblAuctionLocation);
            this.groupBoxAuctionDetails.Controls.Add(this.dtpAuctionDate);
            this.groupBoxAuctionDetails.Controls.Add(this.lblAuctionDate);
            this.groupBoxAuctionDetails.Controls.Add(this.txtAuctionName);
            this.groupBoxAuctionDetails.Controls.Add(this.lblAuctionName);
            this.groupBoxAuctionDetails.Location = new System.Drawing.Point(680, 12);
            this.groupBoxAuctionDetails.Name = "groupBoxAuctionDetails";
            this.groupBoxAuctionDetails.Size = new System.Drawing.Size(492, 267);
            this.groupBoxAuctionDetails.TabIndex = 10;
            this.groupBoxAuctionDetails.TabStop = false;
            this.groupBoxAuctionDetails.Text = "Деталі аукціону";
            //
            // btnCancelAuction
            //
            this.btnCancelAuction.Location = new System.Drawing.Point(250, 215);
            this.btnCancelAuction.Name = "btnCancelAuction";
            this.btnCancelAuction.Size = new System.Drawing.Size(120, 35);
            this.btnCancelAuction.TabIndex = 9;
            this.btnCancelAuction.Text = "Відміна";
            this.btnCancelAuction.UseVisualStyleBackColor = true;
            this.btnCancelAuction.Click += new System.EventHandler(this.btnCancelAuction_Click);
            //
            // btnSaveAuction
            //
            this.btnSaveAuction.Location = new System.Drawing.Point(120, 215);
            this.btnSaveAuction.Name = "btnSaveAuction";
            this.btnSaveAuction.Size = new System.Drawing.Size(120, 35);
            this.btnSaveAuction.TabIndex = 8;
            this.btnSaveAuction.Text = "Зберегти";
            this.btnSaveAuction.UseVisualStyleBackColor = true;
            this.btnSaveAuction.Click += new System.EventHandler(this.btnSaveAuction_Click);
            //
            // txtAuctionHouse
            //
            this.txtAuctionHouse.Location = new System.Drawing.Point(120, 150);
            this.txtAuctionHouse.Name = "txtAuctionHouse";
            this.txtAuctionHouse.Size = new System.Drawing.Size(350, 22);
            this.txtAuctionHouse.TabIndex = 7;
            //
            // lblAuctionHouse
            //
            this.lblAuctionHouse.AutoSize = true;
            this.lblAuctionHouse.Location = new System.Drawing.Point(20, 153);
            this.lblAuctionHouse.Name = "lblAuctionHouse";
            this.lblAuctionHouse.Size = new System.Drawing.Size(94, 16);
            this.lblAuctionHouse.TabIndex = 6;
            this.lblAuctionHouse.Text = "Аукціонний дім:";
            //
            // txtAuctionLocation
            //
            this.txtAuctionLocation.Location = new System.Drawing.Point(120, 110);
            this.txtAuctionLocation.Name = "txtAuctionLocation";
            this.txtAuctionLocation.Size = new System.Drawing.Size(350, 22);
            this.txtAuctionLocation.TabIndex = 5;
            //
            // lblAuctionLocation
            //
            this.lblAuctionLocation.AutoSize = true;
            this.lblAuctionLocation.Location = new System.Drawing.Point(20, 113);
            this.lblAuctionLocation.Name = "lblAuctionLocation";
            this.lblAuctionLocation.Size = new System.Drawing.Size(73, 16);
            this.lblAuctionLocation.TabIndex = 4;
            this.lblAuctionLocation.Text = "Локація:";
            //
            // dtpAuctionDate
            //
            this.dtpAuctionDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpAuctionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAuctionDate.Location = new System.Drawing.Point(120, 70);
            this.dtpAuctionDate.Name = "dtpAuctionDate";
            this.dtpAuctionDate.Size = new System.Drawing.Size(180, 22);
            this.dtpAuctionDate.TabIndex = 3;
            //
            // lblAuctionDate
            //
            this.lblAuctionDate.AutoSize = true;
            this.lblAuctionDate.Location = new System.Drawing.Point(20, 73);
            this.lblAuctionDate.Name = "lblAuctionDate";
            this.lblAuctionDate.Size = new System.Drawing.Size(43, 16);
            this.lblAuctionDate.TabIndex = 2;
            this.lblAuctionDate.Text = "Дата:";
            //
            // txtAuctionName
            //
            this.txtAuctionName.Location = new System.Drawing.Point(120, 30);
            this.txtAuctionName.Name = "txtAuctionName";
            this.txtAuctionName.Size = new System.Drawing.Size(350, 22);
            this.txtAuctionName.TabIndex = 1;
            //
            // lblAuctionName
            //
            this.lblAuctionName.AutoSize = true;
            this.lblAuctionName.Location = new System.Drawing.Point(20, 33);
            this.lblAuctionName.Name = "lblAuctionName";
            this.lblAuctionName.Size = new System.Drawing.Size(50, 16);
            this.lblAuctionName.TabIndex = 0;
            this.lblAuctionName.Text = "Назва:";
            //
            // btnViewPriceHistory
            //
            this.btnViewPriceHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewPriceHistory.Location = new System.Drawing.Point(1002, 644);
            this.btnViewPriceHistory.Name = "btnViewPriceHistory";
            this.btnViewPriceHistory.Size = new System.Drawing.Size(170, 35);
            this.btnViewPriceHistory.TabIndex = 11;
            this.btnViewPriceHistory.Text = "Історія цін картини";
            this.btnViewPriceHistory.UseVisualStyleBackColor = true;
            this.btnViewPriceHistory.Click += new System.EventHandler(this.btnViewPriceHistory_Click);
            //
            // AuctionsForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 691);
            this.Controls.Add(this.btnViewPriceHistory);
            this.Controls.Add(this.groupBoxAuctionDetails);
            this.Controls.Add(this.lblLots);
            this.Controls.Add(this.lblAuctions);
            this.Controls.Add(this.btnDeleteLot);
            this.Controls.Add(this.btnEditLot);
            this.Controls.Add(this.btnAddLot);
            this.Controls.Add(this.dataGridViewLots);
            this.Controls.Add(this.btnDeleteAuction);
            this.Controls.Add(this.btnEditAuction);
            this.Controls.Add(this.btnAddAuction);
            this.Controls.Add(this.dataGridViewAuctions);
            this.Name = "AuctionsForm";
            this.Text = "Аукціони";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuctions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLots)).EndInit();
            this.groupBoxAuctionDetails.ResumeLayout(false);
            this.groupBoxAuctionDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAuctions;
        private System.Windows.Forms.Button btnAddAuction;
        private System.Windows.Forms.Button btnEditAuction;
        private System.Windows.Forms.Button btnDeleteAuction;
        private System.Windows.Forms.DataGridView dataGridViewLots;
        private System.Windows.Forms.Button btnAddLot;
        private System.Windows.Forms.Button btnEditLot;
        private System.Windows.Forms.Button btnDeleteLot;
        private System.Windows.Forms.Label lblAuctions;
        private System.Windows.Forms.Label lblLots;
        private System.Windows.Forms.GroupBox groupBoxAuctionDetails;
        private System.Windows.Forms.Button btnCancelAuction;
        private System.Windows.Forms.Button btnSaveAuction;
        private System.Windows.Forms.TextBox txtAuctionHouse;
        private System.Windows.Forms.Label lblAuctionHouse;
        private System.Windows.Forms.TextBox txtAuctionLocation;
        private System.Windows.Forms.Label lblAuctionLocation;
        private System.Windows.Forms.DateTimePicker dtpAuctionDate;
        private System.Windows.Forms.Label lblAuctionDate;
        private System.Windows.Forms.TextBox txtAuctionName;
        private System.Windows.Forms.Label lblAuctionName;
        private System.Windows.Forms.Button btnViewPriceHistory;
    }
}