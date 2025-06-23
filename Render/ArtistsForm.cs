using System.ComponentModel;
using Сursova.Models;
using Сursova.Services;

namespace PaintingGuide;

public partial class ArtistsForm : Form
{
    private readonly DataService _dataService;
    private BindingList<Artist> _artists;

    public ArtistsForm(DataService dataService)
    {
        _dataService = dataService;
        InitializeComponent(); 
        LoadArtists();
        SetupGrid();
        SetupEventHandlers();
    }

    private void LoadArtists()
    {
        _artists = new BindingList<Artist>(_dataService.GetAllArtists());
        dataGridViewArtists.DataSource = _artists;
        UpdateButtonsState();
    }

    private void SetupGrid()
    {
        dataGridViewArtists.AutoGenerateColumns = false;
        dataGridViewArtists.Columns.Clear();
        dataGridViewArtists.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FirstName", HeaderText = "Ім'я", DataPropertyName = "FirstName", Visible = false });
        dataGridViewArtists.Columns.Add(new DataGridViewTextBoxColumn() { Name = "LastName", HeaderText = "Прізвище", DataPropertyName = "LastName" });
        dataGridViewArtists.Columns.Add(new DataGridViewTextBoxColumn() { Name = "FullName", HeaderText = "Повне ім'я", DataPropertyName = "FullName", ReadOnly = true, Visible = false }); 
        dataGridViewArtists.Columns.Add(new DataGridViewTextBoxColumn() { Name = "BirthDate", HeaderText = "Дата народження", DataPropertyName = "BirthDate", DefaultCellStyle = { Format = "dd.MM.yyyy" } });
        dataGridViewArtists.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DeathDate", HeaderText = "Дата смерті", DataPropertyName = "DeathDate", DefaultCellStyle = { Format = "dd.MM.yyyy" } });
        dataGridViewArtists.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "IsAlive", HeaderText = "Живий", DataPropertyName = "IsAlive", ReadOnly = true }); 
        dataGridViewArtists.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Nationality", HeaderText = "Національність", DataPropertyName = "Nationality" });
        dataGridViewArtists.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Biography", HeaderText = "Біографія", DataPropertyName = "Biography", Visible = false }); 
        dataGridViewArtists.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Styles", HeaderText = "Стилі", DataPropertyName = "StylesString", ReadOnly = true });
        dataGridViewArtists.Columns.Add(new DataGridViewTextBoxColumn() { Name = "PhotoPath", HeaderText = "Шлях до фото", DataPropertyName = "PhotoPath", Visible = false }); 

        // Приклад налаштування ширини колонок
        dataGridViewArtists.Columns["FirstName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dataGridViewArtists.Columns["LastName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dataGridViewArtists.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dataGridViewArtists.Columns["Nationality"].Width = 120;
        dataGridViewArtists.Columns["BirthDate"].Width = 100;
        dataGridViewArtists.Columns["DeathDate"].Width = 100;
        dataGridViewArtists.Columns["IsAlive"].Width = 60;

        dataGridViewArtists.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridViewArtists.MultiSelect = false;
    }

    private void SetupEventHandlers()
    {
        btnAdd.Click += btnAdd_Click;
        btnEdit.Click += btnEdit_Click;
        btnDelete.Click += btnDelete_Click;
        btnViewPaintings.Click += btnViewPaintings_Click;
        dataGridViewArtists.CellDoubleClick += dataGridViewArtists_CellDoubleClick;
        dataGridViewArtists.SelectionChanged += dataGridViewArtists_SelectionChanged;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        using (var form = new ArtistEditForm(new Artist() )) 
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
                _dataService.SaveArtist(form.Artist); 
                LoadArtists(); 
            }
        }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (dataGridViewArtists.SelectedRows.Count > 0)
        {
            var selectedArtist = (Artist)dataGridViewArtists.SelectedRows[0].DataBoundItem;

            using (var form = new ArtistEditForm(selectedArtist))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _dataService.SaveArtist(form.Artist);
                    LoadArtists(); 
                }
            }
        }
        else
        {
            MessageBox.Show("Оберіть художника для редагування.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dataGridViewArtists.SelectedRows.Count > 0)
        {
            var selectedArtist = (Artist)dataGridViewArtists.SelectedRows[0].DataBoundItem;
            var result = MessageBox.Show(
                $"Ви дійсно бажаєте видалити художника '{selectedArtist.FullName}'? Це також видалить усі його картини.",
                "Підтвердження видалення",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _dataService.DeleteArtist(selectedArtist.Id);
                LoadArtists(); 
            }
        }
        else
        {
            MessageBox.Show("Оберіть художника для видалення.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void btnViewPaintings_Click(object sender, EventArgs e)
    {
        if (dataGridViewArtists.SelectedRows.Count > 0)
        {
            var selectedArtist = (Artist)dataGridViewArtists.SelectedRows[0].DataBoundItem;
            using (var paintingsForm = new PaintingsForm(_dataService))
            {
                paintingsForm.ShowDialog();
            }
        }
        else
        {
            MessageBox.Show("Оберіть художника для перегляду його картин", "Увага");
        }
    }

    private void dataGridViewArtists_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            btnEdit_Click(sender, e);
        }
    }

    private void dataGridViewArtists_SelectionChanged(object sender, EventArgs e)
    {
        UpdateButtonsState();
    }

    private void UpdateButtonsState()
    {
        bool hasSelection = dataGridViewArtists.SelectedRows.Count > 0;
        btnEdit.Enabled = hasSelection;
        btnDelete.Enabled = hasSelection;
        btnViewPaintings.Enabled = hasSelection;
    }
}