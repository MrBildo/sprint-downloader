namespace MrBildo.SprintDownloader.Services
{
    public interface IDownload
    {
        Guid Id { get; }

        string Name { get; }
    }

    public sealed class DownloadManager
    {
        private sealed record DownloadItem(IDownload Download, IDownloadStrategy Strategy);

        public const int DefaultMaxConcurrentDownloads = 5;

        private readonly IDownloadStrategyFactory _strategyFactory;

        private readonly List<DownloadItem> _downloadItems = [];
        private readonly object _downloadItemsLock = new();

        private int _maxConcurrentDownloads = DefaultMaxConcurrentDownloads;

        public DownloadManager(IDownloadStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }

        public bool IsInitialized { get; private set; } = false;

        public void Intialize(int maxConcurrentDownloads = DefaultMaxConcurrentDownloads)
        {
            if (IsInitialized)
            {
                throw new InvalidOperationException("DownloadManager is already initialized");
            }

            _maxConcurrentDownloads = maxConcurrentDownloads;

            IsInitialized = true;
        }

        public void ChangeMaxConcurrentDownloads(int maxConcurrentDownloads)
        {
            CheckInitialized();

            _maxConcurrentDownloads = maxConcurrentDownloads;
        }

        private void CheckInitialized()
        {
            if (!IsInitialized)
            {
                throw new InvalidOperationException("DownloadManager is not initialized");
            }
        }

        public void Add(IDownload downloadItem, Guid strategyId, bool autoStart = false)
        {
            CheckInitialized();

            var strategy = _strategyFactory.Create(strategyId) ?? throw new ArgumentException($"No strategy found with ID {strategyId}", nameof(strategyId));

            strategy.StatusChanged += Strategy_StatusChanged;

            strategy.Download(downloadItem);

            lock (_downloadItemsLock)
            {
                _downloadItems.Add(new(downloadItem, strategy));
            }

            if (autoStart)
            {
                Start(downloadItem);
            }
        }

        public void Start(IDownload downloadItem)
        {
            CheckInitialized();

            if (!CanStart())
            {
                return;
            }

            DownloadItem queueItem;

            lock (_downloadItemsLock)
            {
                queueItem = _downloadItems.Single(x => x.Download.Id == downloadItem.Id);
            }

            Task.Run(async () =>
            {
                try
                {
                    await queueItem.Strategy.StartAsync();
                }
                catch (Exception)
                {
                    // TODO: logging or something
                }
            });
        }

        public void Stop(IDownload downloadItem)
        {
            CheckInitialized();

            DownloadItem queueItem;

            lock (_downloadItemsLock)
            {
                queueItem = _downloadItems.Single(x => x.Download.Id == downloadItem.Id);
            }

            Task.Run(async () =>
            {
                try
                {
                    await queueItem.Strategy.StopAsync();
                }
                catch (Exception)
                {
                    // TODO: logging or something
                }
            });

            ResolveQueue();
        }

        public void Remove(IDownload downloadItem)
        {
            CheckInitialized();

            DownloadItem queueItem;

            lock (_downloadItemsLock)
            {
                queueItem = _downloadItems.Single(x => x.Download.Id == downloadItem.Id);
            }

            Task.Run(async () =>
            {
                try
                {
                    await queueItem.Strategy.StopAsync();
                }
                catch (Exception)
                {
                    // TODO: logging or something
                }
            });

            lock (_downloadItemsLock)
            {
                _downloadItems.Remove(queueItem);
            }
        }

        public void Move(IDownload downloadItem, int newIndex)
        {
            // TODO: whenever this is called we need to re-evaluate if
            // A. the new item is now within the concurrent download windows and should start
            // B. if the "bottom" download falls outside the concurrent download window and should be paused or stopped
        }

        private bool CanStart() => GetActiveCount() < _maxConcurrentDownloads;

        private int GetActiveCount()
        {
            lock (_downloadItemsLock)
            {
                return _downloadItems.Count(item => item.Strategy.Status.HasFlag(DownloadStatus.Active));
            }
        }

        private void ResolveQueue()
        {
            var itemsToStart = new List<DownloadItem>();

            lock (_downloadItemsLock)
            {
                foreach (var item in _downloadItems)
                {
                    if (item.Strategy.Status.HasFlag(DownloadStatus.Active))
                    {
                        continue;
                    }

                    if (item.Strategy.Status.HasFlag(DownloadStatus.Idle))
                    {
                        itemsToStart.Add(item);
                    }
                }
            }

            var totalToAdd = _maxConcurrentDownloads - GetActiveCount();

            if (totalToAdd == 0)
            {
                return;
            }

            for (var i = 0; i < totalToAdd; i++)
            {
                Start(itemsToStart[i].Download);
            }
        }

        private void Strategy_StatusChanged(object? sender, DownloadStatusChangedEventArgs e) => ResolveQueue();
    }
}
