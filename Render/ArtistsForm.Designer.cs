namespace PaintingGuide
{
    partial class ArtistsForm
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
        private void InitializeComponent() // <<-- ВСТАВТЕ ВИРІЗАНИЙ КОД СЮДИ
        {
            this.dataGridViewArtists = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnViewPaintings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArtists)).BeginInit();
            this.SuspendLayout();
            //
            // dataGridViewArtists
            //
            this.dataGridViewArtists.AllowUserToAddRows = false;
            this.dataGridViewArtists.AllowUserToDeleteRows = false;
            this.dataGridViewArtists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewArtists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArtists.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewArtists.MultiSelect = false;
            this.dataGridViewArtists.Name = "dataGridViewArtists";
            this.dataGridViewArtists.ReadOnly = true;
            this.dataGridViewArtists.RowHeadersWidth = 51;
            this.dataGridViewArtists.RowTemplate.Height = 24;
            this.dataGridViewArtists.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewArtists.Size = new System.Drawing.Size(760, 350);
            this.dataGridViewArtists.TabIndex = 0;
            this.dataGridViewArtists.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewArtists_CellDoubleClick);
            this.dataGridViewArtists.SelectionChanged += new System.EventHandler(this.dataGridViewArtists_SelectionChanged);
            //
            // btnAdd
            //
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(12, 377);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 38);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnEdit
            //
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(138, 377);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 38);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Редагувати";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            //
            // btnDelete
            //
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(264, 377);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 38);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnViewPaintings
            //
            this.btnViewPaintings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewPaintings.Location = new System.Drawing.Point(600, 377);
            this.btnViewPaintings.Name = "btnViewPaintings";
            this.btnViewPaintings.Size = new System.Drawing.Size(172, 38);
            this.btnViewPaintings.TabIndex = 4;
            this.btnViewPaintings.Text = "Переглянути Картини";
            this.btnViewPaintings.UseVisualStyleBackColor = true;
            this.btnViewPaintings.Click += new System.EventHandler(this.btnViewPaintings_Click);
            //
            // ArtistsForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 427);
            this.Controls.Add(this.btnViewPaintings);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridViewArtists);
            this.Name = "ArtistsForm";
            this.Text = "Художники";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArtists)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewArtists;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnViewPaintings;
    }
}