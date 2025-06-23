using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using Сursova.Models;
using Сursova.Services;
using System.ComponentModel;

namespace PaintingGuide
{
    public partial class PaintingEditForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Painting Painting { get; private set; }
        private readonly DataService _dataService;
        private readonly ImageService _imageService;
        private List<Artist> _artists; 

        public PaintingEditForm(Painting painting, DataService dataService)
        {
            InitializeComponent();
            Painting = painting;
            _dataService = dataService;
            _imageService = new ImageService();
            LoadArtistsIntoComboBox();
            LoadPaintingData();
        }

        private void LoadArtistsIntoComboBox()
        {
            _artists = _dataService.GetAllArtists();
            cmbArtist.DataSource = _artists;
            cmbArtist.DisplayMember = "FullName"; // Відображає повне ім'я
            cmbArtist.ValueMember = "Id"; // Значення - ID художника
            cmbArtist.SelectedValue = Painting.ArtistId; // Вибирає поточного художника картини
        }

        private void LoadPaintingData()
        {
            txtTitle.Text = Painting.Title;
            cmbArtist.SelectedValue = Painting.ArtistId;
            txtYear.Text = Painting.Year?.ToString() ?? string.Empty;
            txtGenre.Text = Painting.Genre;
            txtTechnique.Text = Painting.Technique;
            txtDimensions.Text = Painting.Dimensions;
            txtDescription.Text = Painting.Description;

            if (!string.IsNullOrEmpty(Painting.ImagePath))
            {
                txtImagePath.Text = Painting.ImagePath;
                try
                {
                    picPaintingImage.Image = _imageService.LoadPaintingImage(Painting.ImagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не вдалося завантажити зображення: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    picPaintingImage.Image = null;
                }
            }
            else
            {
                txtImagePath.Text = string.Empty;
                picPaintingImage.Image = null;
            }
        }

        private void SavePaintingData()
        {
            Painting.Title = txtTitle.Text.Trim();
            // Перевіряє, чи є обраний елемент в ComboBox, перш ніж отримувати SelectedValue
            if (cmbArtist.SelectedValue != null)
            {
                Painting.ArtistId = (int)cmbArtist.SelectedValue;
                // Оновлює також навігаційну властивість Artist
                Painting.Artist = _artists.FirstOrDefault(a => a.Id == Painting.ArtistId);
            }
            else
            {
                Painting.ArtistId = 0; 
                Painting.Artist = null;
            }

            if (int.TryParse(txtYear.Text, out int year))
            {
                Painting.Year = year;
            }
            else
            {
                Painting.Year = null;
            }
            Painting.Genre = txtGenre.Text.Trim();
            Painting.Technique = txtTechnique.Text.Trim();
            Painting.Dimensions = txtDimensions.Text.Trim();
            Painting.Description = txtDescription.Text.Trim();

            // Зберігає шлях до зображення
            if (Painting.ImagePath != txtImagePath.Text)
            {
                if (!string.IsNullOrEmpty(Painting.ImagePath))
                {
                    _imageService.DeletePaintingImage(Painting.ImagePath);
                }

                if (!string.IsNullOrEmpty(txtImagePath.Text) && picPaintingImage.Image != null)
                {
                    Painting.ImagePath = txtImagePath.Text;
                }
                else
                {
                    Painting.ImagePath = string.Empty;
                }
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Будь ласка, введіть назву картини.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitle.Focus();
                return false;
            }

            if (cmbArtist.SelectedValue == null || (int)cmbArtist.SelectedValue == 0)
            {
                MessageBox.Show("Будь ласка, оберіть художника.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbArtist.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(txtYear.Text) && !int.TryParse(txtYear.Text, out int year))
            {
                MessageBox.Show("Рік має бути числом.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtYear.Focus();
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SavePaintingData();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image originalImage = Image.FromFile(openFileDialog.FileName);
                        picPaintingImage.Image = ImageHelper.ResizeImage(originalImage, picPaintingImage.Width, picPaintingImage.Height);

                        string savedPath = _imageService.SavePaintingImage(originalImage, Path.GetFileName(openFileDialog.FileName));
                        txtImagePath.Text = savedPath;

                        originalImage.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка завантаження або збереження зображення: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Дозволяє вводити лише цифри та керуючі клавіші 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}