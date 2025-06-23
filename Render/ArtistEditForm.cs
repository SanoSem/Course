using System.ComponentModel;
using Сursova.Models;
using Сursova.Services;

namespace PaintingGuide;

public partial class ArtistEditForm : Form
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Artist Artist { get; set; }
    private readonly ImageService _imageService;

    public ArtistEditForm(Artist artist)
    {
        InitializeComponent();
        Artist = artist;
        _imageService = new ImageService();
        LoadArtistData();
        dtpDeathDate.Enabled = !chkIsAlive.Checked;
    }

    private void LoadArtistData()
    {
        txtFirstName.Text = Artist.FirstName;
        txtLastName.Text = Artist.LastName;

        // Обробка BirthDate
        if (Artist.BirthDate.HasValue)
        {
            dtpBirthDate.Value = Artist.BirthDate.Value;
            dtpBirthDate.Checked = true;
        }
        else
        {
            dtpBirthDate.Value = DateTime.Now; 
            dtpBirthDate.Checked = false;
        }

        // Обробка DeathDate та IsAlive
        chkIsAlive.Checked = Artist.IsAlive;
        if (Artist.DeathDate.HasValue)
        {
            dtpDeathDate.Value = Artist.DeathDate.Value;
            dtpDeathDate.Checked = true;
            dtpDeathDate.Enabled = true; // Якщо є дата смерті, поле активне
        }
        else
        {
            dtpDeathDate.Value = DateTime.Now; 
            dtpDeathDate.Checked = false;
            dtpDeathDate.Enabled = false; // Якщо живий, поле неактивне
        }

        txtNationality.Text = Artist.Nationality;
        txtBiography.Text = Artist.Biography;
        txtStyles.Text = string.Join(", ", Artist.Styles); 

        if (!string.IsNullOrEmpty(Artist.PhotoPath))
        {
            txtPhotoPath.Text = Artist.PhotoPath;
            try
            {
                picArtistPhoto.Image = _imageService.LoadArtistPhoto(Artist.PhotoPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не вдалося завантажити фото: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                picArtistPhoto.Image = null;
            }
        }
        else
        {
            txtPhotoPath.Text = string.Empty;
            picArtistPhoto.Image = null;
        }
    }

    private void SaveArtistData()
    {
        Artist.FirstName = txtFirstName.Text.Trim();
        Artist.LastName = txtLastName.Text.Trim();

        // Зберігаємо BirthDate
        Artist.BirthDate = dtpBirthDate.Checked ? (DateTime?)dtpBirthDate.Value.Date : null;

        // Зберігаємо DeathDate
        if (chkIsAlive.Checked)
        {
            Artist.DeathDate = null; // Якщо живий, дата смерті відсутня
        }
        else
        {
            Artist.DeathDate = dtpDeathDate.Checked ? (DateTime?)dtpDeathDate.Value.Date : null;
        }

        Artist.Nationality = txtNationality.Text.Trim();
        Artist.Biography = txtBiography.Text.Trim();
        Artist.Styles = txtStyles.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(s => s.Trim()).ToList();

        if (Artist.PhotoPath != txtPhotoPath.Text)
        {
            if (!string.IsNullOrEmpty(Artist.PhotoPath))
            {
                _imageService.DeleteArtistPhoto(Artist.PhotoPath);
            }
            if (!string.IsNullOrEmpty(txtPhotoPath.Text) && picArtistPhoto.Image != null)
            {
                Artist.PhotoPath = txtPhotoPath.Text;
            }
            else
            {
                Artist.PhotoPath = string.Empty;
            }
        }
    }


    private bool ValidateForm()
    {
        if (string.IsNullOrWhiteSpace(txtFirstName.Text))
        {
            MessageBox.Show("Будь ласка, введіть ім'я художника.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtFirstName.Focus();
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtLastName.Text))
        {
            MessageBox.Show("Будь ласка, введіть прізвище художника.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtLastName.Focus();
            return false;
        }

        if (dtpBirthDate.Checked && dtpDeathDate.Checked && dtpDeathDate.Value.Date < dtpBirthDate.Value.Date)
        {
            MessageBox.Show("Дата смерті не може бути раніше дати народження.", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Error);
            dtpDeathDate.Focus();
            return false;
        }

        return true;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (ValidateForm())
        {
            SaveArtistData();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void chkIsAlive_CheckedChanged(object sender, EventArgs e)
    {
        dtpDeathDate.Enabled = !chkIsAlive.Checked;
        if (chkIsAlive.Checked)
        {
            dtpDeathDate.Checked = false;
        }
    }

    private void btnBrowsePhoto_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image originalImage = Image.FromFile(openFileDialog.FileName);

                    picArtistPhoto.Image = ImageHelper.ResizeImage(originalImage, picArtistPhoto.Width, picArtistPhoto.Height);

                    string savedPath = _imageService.SaveArtistPhoto(originalImage, Path.GetFileName(openFileDialog.FileName));
                    txtPhotoPath.Text = savedPath; 

                    originalImage.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка завантаження або збереження зображення: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}