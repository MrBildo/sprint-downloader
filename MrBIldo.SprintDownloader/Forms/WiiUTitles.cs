using System.ComponentModel;

namespace MrBildo.SprintDownloader.Forms
{
    public partial class WiiUTitles : Form
    {
        private BindingList<WiiUTitle> _titles = Array.Empty<WiiUTitle>().ToSortableBindingList();
        private readonly BindingList<WiiUTitle> _queuedTitles = Array.Empty<WiiUTitle>().ToSortableBindingList();

        public WiiUTitles()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        public async Task LoadTitlesAsync(string fileName)
        {
            var service = new WiiUTitleLoader();

            var titles = new List<WiiUTitle>();

            await Task.Run(async () =>
            {
                await foreach (var title in service.LoadTitlesAsync(fileName))
                {
                    titles.Add(title);
                }
            });

            dataGridTitles.SuspendLayout();

            dataGridTitles.EnableHeadersVisualStyles = false;

            dataGridTitles.ColumnHeadersDefaultCellStyle.SelectionBackColor = dataGridTitles.ColumnHeadersDefaultCellStyle.BackColor;

            _titles = titles.ToSortableBindingList();

            dataGridTitles.DataSource = _titles;

            foreach (var column in dataGridTitles.Columns)
            {
                if (column is DataGridViewTextBoxColumn textColumn)
                {
                    textColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }

            ApplyFilter();

            dataGridTitles.Sort(dataGridTitles.Columns[nameof(WiiUTitle.Name)], ListSortDirection.Ascending);

            dataGridTitles.ResumeLayout();
        }

        public IEnumerable<WiiUTitle> GetQueuedTitles() => _queuedTitles;

        private void dataGridWiiUTitles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridTitles.Columns[e.ColumnIndex].Name == "Category")
            {
                if (e.Value is WiiUCategories category)
                {
                    e.Value = category.ToString();
                }
            }

            if (dataGridTitles.Columns[e.ColumnIndex].Name == "Region")
            {
                if (e.Value is WiiURegions region)
                {
                    e.Value = e.Value is WiiURegions.USA_Europe ? "USA/Europe" : (object)region.ToString();
                }
            }
        }

        private void OnApplyFilter(object Sender, EventArgs e) => ApplyFilter();

        private void ApplyFilter()
        {
            if (_titles is null)
            {
                return;
            }

            var usaChecked = checkBoxUSA.Checked;
            var europeChecked = checkBoxEurope.Checked;
            var japanChecked = checkBoxJapan.Checked;
            var gamesChecked = checkBoxGames.Checked;
            var dlcChecked = checkBoxDLC.Checked;
            var updatesChecked = checkBoxUpdates.Checked;
            var demosChecked = checkBoxDemos.Checked;
            var otherChecked = checkBoxOther.Checked;

            var anyRegionChecked = usaChecked || europeChecked || japanChecked;
            var anyCategoryChecked = gamesChecked || dlcChecked || updatesChecked || demosChecked || otherChecked;

            Func<WiiUTitle, bool> regionPredicate = x => (usaChecked && (x.Region.HasFlag(WiiURegions.USA) || x.Region.HasFlag(WiiURegions.USA_Europe))) ||
                                                                   (europeChecked && (x.Region.HasFlag(WiiURegions.Europe) || x.Region.HasFlag(WiiURegions.USA_Europe))) ||
                                                                   (japanChecked && x.Region.HasFlag(WiiURegions.Japan));

            Func<WiiUTitle, bool> categoryPredicate = x => (gamesChecked && x.Category == WiiUCategories.Game) ||
                                                                     (dlcChecked && x.Category == WiiUCategories.DLC) ||
                                                                     (updatesChecked && x.Category == WiiUCategories.Update) ||
                                                                     (demosChecked && x.Category == WiiUCategories.Demo) ||
                                                                     (otherChecked && !Enum.IsDefined(typeof(WiiUCategories), x.Category));

            var filter = _titles.AsQueryable();

            if (anyRegionChecked && anyCategoryChecked)
            {
                filter = filter.Where(x => x.Region != WiiURegions.Unknown && regionPredicate(x) && categoryPredicate(x));
            }
            else
            {
                filter = Enumerable.Empty<WiiUTitle>().AsQueryable(); // if no region or category is checked, don't show anything
            }

            var textFilter = textBoxFilter.Text.Trim().ToLower();

            if (!string.IsNullOrEmpty(textFilter))
            {
                filter = filter.Where(x => x.Name.Contains(textFilter, StringComparison.CurrentCultureIgnoreCase));
            }

            dataGridTitles.DataSource = filter.ToSortableBindingList();

            ApplySorting(dataGridTitles);
        }

        private static void ApplySorting(DataGridView dataGridView)
        {
            var sortedColumnIndex = dataGridView.SortedColumn?.Index;
            var sortDirection = dataGridView.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;

            if (sortedColumnIndex is not null)
            {
                dataGridView.Sort(dataGridView.Columns[sortedColumnIndex.Value], sortDirection);
            }
        }

        private void OnMoveSelectedTitles(object sender, EventArgs e)
        {

            var titles = dataGridTitles
                .SelectedRows.Cast<DataGridViewRow>()
                    .Select(x => x.DataBoundItem as WiiUTitle)
                        .Select(x => x!.Id)
                            .ToArray();

            MoveTitles(titles);
        }

        private void OnMoveAllTitles(object sender, EventArgs e)
        {
            var titles = dataGridTitles
                .Rows.Cast<DataGridViewRow>()
                    .Select(x => x.DataBoundItem as WiiUTitle)
                        .Select(x => x!.Id)
                            .ToArray();

            MoveTitles(titles);
        }

        private void OnMoveSelectedQueuedTitle(object sender, EventArgs e)
        {
            var titles = dataGridQueued
                .SelectedRows.Cast<DataGridViewRow>()
                    .Select(x => x.DataBoundItem as WiiUTitle)
                        .Select(x => x!.Id)
                            .ToArray();

            MoveQueuedTitles(titles);
        }

        private void OnMoveAllQueuedTitles(object sender, EventArgs e)
        {
            var titles = dataGridQueued
                .Rows.Cast<DataGridViewRow>()
                    .Select(x => x.DataBoundItem as WiiUTitle)
                        .Select(x => x!.Id)
                            .ToArray();

            MoveQueuedTitles(titles);
        }

        private void MoveTitles(string[] titleIds)
        {
            dataGridTitles.SuspendLayout();
            dataGridQueued.SuspendLayout();

            foreach (var id in titleIds)
            {
                var titleToMove = _titles?.FirstOrDefault(title => title.Id == id);

                if (titleToMove != null)
                {
                    _queuedTitles.Add(titleToMove);
                    dataGridQueued.DataSource = _queuedTitles;

                    _titles?.Remove(titleToMove);
                    dataGridTitles.DataSource = _titles;
                }
            }

            ApplyFilter();
            ApplySorting(dataGridQueued);

            dataGridTitles.Refresh();
            dataGridQueued.Refresh();

            dataGridTitles.ResumeLayout();
            dataGridQueued.ResumeLayout();
        }

        private void MoveQueuedTitles(string[] titleIds)
        {
            dataGridTitles.SuspendLayout();
            dataGridQueued.SuspendLayout();

            foreach (var id in titleIds)
            {
                var titleToMove = _queuedTitles.FirstOrDefault(title => title.Id == id);

                if (titleToMove != null)
                {
                    _titles?.Add(titleToMove);
                    dataGridQueued.DataSource = _titles;

                    _queuedTitles.Remove(titleToMove);
                    dataGridQueued.DataSource = _queuedTitles;
                }
            }

            ApplyFilter();
            ApplySorting(dataGridQueued);

            dataGridTitles.Refresh();
            dataGridQueued.Refresh();

            dataGridTitles.ResumeLayout();
            dataGridQueued.ResumeLayout();
        }

        private void dataGridTitles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridTitles.Rows.Count)
            {
                var row = dataGridTitles.Rows[e.RowIndex];

                if (row is DataGridViewRow dataRow)
                {
                    MoveTitles([dataRow.Cells[nameof(WiiUTitle.Id)].Value.ToString()!]);
                }
            }
        }

        private void dataGridQueued_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridQueued.Rows.Count)
            {
                var row = dataGridQueued.Rows[e.RowIndex];

                if (row is DataGridViewRow dataRow)
                {
                    MoveQueuedTitles([dataRow.Cells[nameof(WiiUTitle.Id)].Value.ToString()!]);
                }
            }
        }
    }
}
