using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Сursova.Models;
using Сursova.Services;

namespace PaintingGuide
{
    public partial class PaintingsForm : Form
    {
        private readonly DataService _dataService;
        private BindingList<Painting> _paintings;

        public PaintingsForm(DataService dataService)
        {
            _dataService = dataService;
            InitializeComponent();
            SetupEventHandlers();
            LoadPaintings();
            SetupGrid();
        }
        private void LoadPaintings()
        {
            _paintings = new BindingList<Painting>(_dataService.GetAllPaintings());
            dataGridViewPaintings.DataSource = _paintings;
            UpdateButtonsState();
        }

        private void SetupGrid()
        {
            dataGridViewPaintings.AutoGenerateColumns = false;
            dataGridViewPaintings.Columns.Clear();

            dataGridViewPaintings.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Title", HeaderText = "Назва", Width = 150 });
            dataGridViewPaintings.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ArtistFullName", HeaderText = "Художник", Width = 150 });
            dataGridViewPaintings.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Year", HeaderText = "Рік", Width = 70 });
            dataGridViewPaintings.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Genre", HeaderText = "Жанр", Width = 100 });
            dataGridViewPaintings.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Technique", HeaderText = "Техніка", Width = 100 });
            dataGridViewPaintings.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Dimensions", HeaderText = "Розміри", Width = 100 });
            dataGridViewPaintings.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Description", HeaderText = "Опис", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        private void SetupEventHandlers()
        {
            btnAddPainting.Click += btnAddPainting_Click;
            btnEditPainting.Click += btnEditPainting_Click;
            btnDeletePainting.Click += btnDeletePainting_Click;
            dataGridViewPaintings.CellDoubleClick += dataGridViewPaintings_CellDoubleClick;
            dataGridViewPaintings.SelectionChanged += dataGridViewPaintings_SelectionChanged;
        }

        private void btnAddPainting_Click(object sender, EventArgs e)
        {
            var newPainting = new Painting();
            using (var form = new PaintingEditForm(newPainting, _dataService))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _dataService.SavePainting(newPainting);
                    LoadPaintings();
                }
            }
        }

        private void btnEditPainting_Click(object sender, EventArgs e)
        {
            if (dataGridViewPaintings.SelectedRows.Count > 0)
            {
                var selectedPainting = (Painting)dataGridViewPaintings.SelectedRows[0].DataBoundItem;
                // Створює копію картини, щоб не змінювати дані в гриді, якщо користувач скасує зміни
                var paintingCopy = new Painting
                {
                    Id = selectedPainting.Id,
                    Title = selectedPainting.Title,
                    ArtistId = selectedPainting.ArtistId,
                    Year = selectedPainting.Year,
                    Genre = selectedPainting.Genre,
                    Technique = selectedPainting.Technique,
                    Dimensions = selectedPainting.Dimensions,
                    Description = selectedPainting.Description,
                    ImagePath = selectedPainting.ImagePath,
                    Artist = selectedPainting.Artist 
                };

                using (var form = new PaintingEditForm(paintingCopy, _dataService))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // Оновлює оригінальний об'єкт у _paintings
                        selectedPainting.Title = paintingCopy.Title;
                        selectedPainting.ArtistId = paintingCopy.ArtistId;
                        selectedPainting.Year = paintingCopy.Year;
                        selectedPainting.Genre = paintingCopy.Genre;
                        selectedPainting.Technique = paintingCopy.Technique;
                        selectedPainting.Dimensions = paintingCopy.Dimensions;
                        selectedPainting.Description = paintingCopy.Description;
                        selectedPainting.ImagePath = paintingCopy.ImagePath;
                        selectedPainting.Artist = paintingCopy.Artist;

                        _dataService.SavePainting(selectedPainting);
                        _paintings.ResetItem(_paintings.IndexOf(selectedPainting));
                    }
                }
            }
            else
            {
                MessageBox.Show("Оберіть картину для редагування", "Увага");
            }
        }

        private void btnDeletePainting_Click(object sender, EventArgs e)
        {
            if (dataGridViewPaintings.SelectedRows.Count > 0)
            {
                var selectedPainting = (Painting)dataGridViewPaintings.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"Видалити картину '{selectedPainting.Title}'?",
                    "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _dataService.DeletePainting(selectedPainting.Id);
                    LoadPaintings();
                }
            }
            else
            {
                MessageBox.Show("Оберіть картину для видалення", "Увага");
            }
        }

        private void dataGridViewPaintings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEditPainting_Click(sender, e);
            }
        }

        private void dataGridViewPaintings_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            bool hasSelection = dataGridViewPaintings.SelectedRows.Count > 0;
            btnEditPainting.Enabled = hasSelection;
            btnDeletePainting.Enabled = hasSelection;
        }
    }
}