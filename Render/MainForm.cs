using Сursova.Render;
using Сursova.Services; 
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Сursova.Models;
using Сursova.Forms;

namespace PaintingGuide;

public partial class MainForm : Form
{
    private readonly DataService _dataService;
    private StatusStrip statusStrip;
    private ToolStrip toolStrip; 
    private DataGridView dgvSearchResults; 
    private Panel pnlMainContent;

    public MainForm()
    {
        InitializeComponent();
        _dataService = new DataService();
        SetupForm();
    }

    private void SetupForm()
    {
        Text = "Довідник любителя живопису";
        StartPosition = FormStartPosition.CenterScreen;

        CreateMenuStrip();
        CreateStatusStrip();
        CreateMainContentPanel();
        CreateSearchDataGridView();

        UpdateStatusStrip();
    }

    private void CreateMenuStrip()
    {
        var menuStrip = new MenuStrip();

        var catalogsMenu = new ToolStripMenuItem("Довідники");
        catalogsMenu.DropDownItems.Add("Художники", null, (s, e) => OpenArtistsForm());
        catalogsMenu.DropDownItems.Add("Картини", null, (s, e) => OpenPaintingsForm());
        catalogsMenu.DropDownItems.Add("Особиста колекція", null, (s, e) => OpenPersonalCollectionForm());
        catalogsMenu.DropDownItems.Add("Колекціонери", null, (s, e) => OpenCollectorsForm());
        catalogsMenu.DropDownItems.Add("Аукціони", null, (s, e) => OpenAuctionsForm());
        catalogsMenu.DropDownItems.Add("Комісійні магазини", null, (s, e) => OpenCommissionShopsForm());
        menuStrip.Items.Add(catalogsMenu);

        var searchMenu = new ToolStripMenuItem("Пошук");
        searchMenu.DropDownItems.Add("Пошук картин/художників", null, (s, e) => OpenSearchForm());
        menuStrip.Items.Add(searchMenu);

        var helpMenu = new ToolStripMenuItem("Допомога");
        helpMenu.DropDownItems.Add("Про програму", null, (s, e) => ShowAboutBox());
        menuStrip.Items.Add(helpMenu);

        menuStrip.Items.Add(new ToolStripButton("Колекція", null, (s, e) => OpenPersonalCollectionForm()) { DisplayStyle = ToolStripItemDisplayStyle.Text });

        MainMenuStrip = menuStrip;
        Controls.Add(menuStrip);
    }

    private void CreateStatusStrip()
    {
        statusStrip = new StatusStrip();
        Controls.Add(statusStrip);
    }

    private void CreateMainContentPanel()
    {
        pnlMainContent = new Panel
        {
            Dock = DockStyle.Fill, // Заповнює весь простір
            Padding = new Padding(10) 
        };
        Controls.Add(pnlMainContent);
        pnlMainContent.SendToBack(); // Відправляємо на задній план, щоб не перекривав меню
    }


    private void CreateSearchDataGridView()
    {
        dgvSearchResults = new DataGridView
        {
            Dock = DockStyle.Fill, // Заповнює панель
            Visible = false, // Спочатку прихований
            ReadOnly = true, // Тільки для читання
            AllowUserToAddRows = false, // Забороняє додавати рядки
            SelectionMode = DataGridViewSelectionMode.FullRowSelect, // Виділення цілого рядка
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill // Автоматично підлаштовує ширину колонок
        };
        pnlMainContent.Controls.Add(dgvSearchResults); // Додає до панелі
    }

    public void UpdateStatusStrip()
    {
        var stats = _dataService.GetDatabaseStatistics();
        statusStrip.Items.Clear();
        statusStrip.Items.Add($"Художників: {stats.ArtistsCount}");
        statusStrip.Items.Add($"Картин: {stats.PaintingsCount}");
        statusStrip.Items.Add($"В колекції: {stats.CollectionItemsCount}");
        statusStrip.Items.Add($"Колекціонерів: {stats.CollectorsCount}");
        statusStrip.Items.Add($"Аукціонів: {stats.AuctionsCount}");
        statusStrip.Items.Add($"Лотів: {stats.AuctionLotsCount}");
        statusStrip.Items.Add($"Магазинів: {stats.CommissionShopsCount}");
        statusStrip.Items.Add($"Предметів в магазинах: {stats.CommissionShopItemsCount}");
    }

    private void OpenArtistsForm()
    {
        HideAllContent(); // Приховує dgvSearchResults перед відкриттям нової форми
        var artistsForm = new ArtistsForm(_dataService);
        artistsForm.ShowDialog();
        UpdateStatusStrip();
    }

    private void OpenPaintingsForm()
    {
        HideAllContent();
        var paintingsForm = new PaintingsForm(_dataService);
        paintingsForm.ShowDialog();
        UpdateStatusStrip();
    }

    private void OpenPersonalCollectionForm()
    {
        HideAllContent();
        var personalCollectionForm = new PersonalCollectionForm(_dataService);
        personalCollectionForm.ShowDialog();
        UpdateStatusStrip();
    }

    private void OpenCollectorsForm()
    {
        HideAllContent();
        var collectorsForm = new CollectorsForm(_dataService);
        collectorsForm.ShowDialog();
        UpdateStatusStrip();
    }

    private void OpenAuctionsForm()
    {
        HideAllContent();
        var auctionsForm = new AuctionsForm(_dataService);
        auctionsForm.ShowDialog();
        UpdateStatusStrip();
    }

    private void OpenCommissionShopsForm() 
    {
        HideAllContent();
        var commissionShopsForm = new CommissionShopsForm(_dataService);
        commissionShopsForm.ShowDialog(this); // Передає поточну форму як власника
        UpdateStatusStrip();
    }

    private void OpenSearchForm()
    {
        HideAllContent();

        string searchTerm = Interaction.InputBox("Введіть назву картини або ім'я художника для пошуку:", "Пошук", "");

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var searchResults = _dataService.SearchPaintingsAndArtists(searchTerm).ToList();

            if (searchResults != null && searchResults.Any())
            {
                dgvSearchResults.DataSource = searchResults;
                dgvSearchResults.Visible = true;
                dgvSearchResults.BringToFront(); 
            }
            else
            {
                MessageBox.Show("За вашим запитом нічого не знайдено.", "Результати пошуку");
                dgvSearchResults.Visible = false;
            }
        }
        else
        {
            dgvSearchResults.Visible = false; // Приховує DataGridView, якщо пошуковий запит порожній
        }
    }

    private void HideAllContent()
    {
        foreach (Control control in pnlMainContent.Controls)
        {
            control.Visible = false;
        }
    }

    private void ShowAboutBox()
    {
        HideAllContent();
        MessageBox.Show("Painting Guide v1.0\n\nРозроблено для курсової роботи.", "Про програму");
    }
}