namespace PaintingGuide
{
    partial class PaintingsForm
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
            this.dataGridViewPaintings = new System.Windows.Forms.DataGridView();
            this.btnAddPainting = new System.Windows.Forms.Button();
            this.btnEditPainting = new System.Windows.Forms.Button();
            this.btnDeletePainting = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPaintings)).BeginInit();
            this.SuspendLayout();
            //
            // dataGridViewPaintings
            //
            this.dataGridViewPaintings.AllowUserToAddRows = false;
            this.dataGridViewPaintings.AllowUserToDeleteRows = false;
            this.dataGridViewPaintings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPaintings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPaintings.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewPaintings.MultiSelect = false;
            this.dataGridViewPaintings.Name = "dataGridViewPaintings";
            this.dataGridViewPaintings.ReadOnly = true;
            this.dataGridViewPaintings.RowHeadersWidth = 51;
            this.dataGridViewPaintings.RowTemplate.Height = 24;
            this.dataGridViewPaintings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPaintings.Size = new System.Drawing.Size(760, 350);
            this.dataGridViewPaintings.TabIndex = 0;
            this.dataGridViewPaintings.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPaintings_CellDoubleClick);
            this.dataGridViewPaintings.SelectionChanged += new System.EventHandler(this.dataGridViewPaintings_SelectionChanged);
            //
            // btnAddPainting
            //
            this.btnAddPainting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddPainting.Location = new System.Drawing.Point(12, 377);
            this.btnAddPainting.Name = "btnAddPainting";
            this.btnAddPainting.Size = new System.Drawing.Size(120, 38);
            this.btnAddPainting.TabIndex = 1;
            this.btnAddPainting.Text = "Додати";
            this.btnAddPainting.UseVisualStyleBackColor = true;
            this.btnAddPainting.Click += new System.EventHandler(this.btnAddPainting_Click);
            //
            // btnEditPainting
            //
            this.btnEditPainting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditPainting.Location = new System.Drawing.Point(138, 377);
            this.btnEditPainting.Name = "btnEditPainting";
            this.btnEditPainting.Size = new System.Drawing.Size(120, 38);
            this.btnEditPainting.TabIndex = 2;
            this.btnEditPainting.Text = "Редагувати";
            this.btnEditPainting.UseVisualStyleBackColor = true;
            this.btnEditPainting.Click += new System.EventHandler(this.btnEditPainting_Click);
            //
            // btnDeletePainting
            //
            this.btnDeletePainting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeletePainting.Location = new System.Drawing.Point(264, 377);
            this.btnDeletePainting.Name = "btnDeletePainting";
            this.btnDeletePainting.Size = new System.Drawing.Size(120, 38);
            this.btnDeletePainting.TabIndex = 3;
            this.btnDeletePainting.Text = "Видалити";
            this.btnDeletePainting.UseVisualStyleBackColor = true;
            this.btnDeletePainting.Click += new System.EventHandler(this.btnDeletePainting_Click);
            //
            // PaintingsForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 427);
            this.Controls.Add(this.btnDeletePainting);
            this.Controls.Add(this.btnEditPainting);
            this.Controls.Add(this.btnAddPainting);
            this.Controls.Add(this.dataGridViewPaintings);
            this.Name = "PaintingsForm";
            this.Text = "Картини";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPaintings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPaintings;
        private System.Windows.Forms.Button btnAddPainting;
        private System.Windows.Forms.Button btnEditPainting;
        private System.Windows.Forms.Button btnDeletePainting;
    }
}