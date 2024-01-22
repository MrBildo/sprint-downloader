namespace MrBildo.SprintDownloader.Services
{
    [Flags]
    public enum DownloadStatus
    {
        Waiting = 1 << 0, // 1
        Starting = 1 << 1, // 2
        Running = 1 << 2, // 4
        Pausing = 1 << 3, // 8
        Paused = 1 << 4, // 16
        Resuming = 1 << 5, // 32
        Stopping = 1 << 6, // 64
        Stopped = 1 << 7, // 128
        Finished = 1 << 8, // 256
        Errored = 1 << 9, // 512
        Active = Starting | Running | Pausing | Resuming | Stopping,
        Idle = Waiting | Paused,
    }

    public class DownloadEventArgs(IDownload download) : EventArgs
    {
        public IDownload Download { get; } = download;
    }

    public sealed class DownloadStatusChangedEventArgs(IDownload download, DownloadStatus status) : DownloadEventArgs(download)
    {
        public DownloadStatus Status { get; } = status;
    }

    public interface IDownloadStrategy
    {
        event EventHandler<DownloadStatusChangedEventArgs>? StatusChanged;

        event EventHandler<DownloadEventArgs>? Starting;
        event EventHandler<DownloadEventArgs>? Started;
        event EventHandler<DownloadEventArgs>? Pausing;
        event EventHandler<DownloadEventArgs>? Paused;
        event EventHandler<DownloadEventArgs>? Resuming;
        event EventHandler<DownloadEventArgs>? Resumed;
        event EventHandler<DownloadEventArgs>? Stopping;
        event EventHandler<DownloadEventArgs>? Stopped;
        event EventHandler<DownloadEventArgs>? Finished;
        event EventHandler<DownloadEventArgs>? Errored;

        Guid Id { get; }

        string Name { get; }

        DownloadStatus Status { get; }

        bool CanPause { get; }

        void Download(IDownload download);

        ValueTask StartAsync();

        ValueTask PauseAsync();

        ValueTask ResumeAsync();

        ValueTask StopAsync();
    }

    public abstract class DownloadStrategy<TDownload> : IDownloadStrategy
        where TDownload : IDownload
    {

        public event EventHandler<DownloadStatusChangedEventArgs>? StatusChanged;

        public event EventHandler<DownloadEventArgs>? Starting;
        public event EventHandler<DownloadEventArgs>? Started;
        public event EventHandler<DownloadEventArgs>? Pausing;
        public event EventHandler<DownloadEventArgs>? Paused;
        public event EventHandler<DownloadEventArgs>? Resuming;
        public event EventHandler<DownloadEventArgs>? Resumed;
        public event EventHandler<DownloadEventArgs>? Stopping;
        public event EventHandler<DownloadEventArgs>? Stopped;
        public event EventHandler<DownloadEventArgs>? Finished;
        public event EventHandler<DownloadEventArgs>? Errored;

        private bool _canPause = false;

        public abstract Guid Id { get; }

        public abstract string Name { get; }

        public DownloadStatus Status { get; private set; }

        protected abstract void OnDownload(TDownload download);

        protected abstract ValueTask OnStartAsync();

        protected abstract ValueTask OnPauseAsync();

        protected abstract ValueTask OnResumeAsync();

        protected abstract ValueTask OnStopAsync();

        protected abstract ValueTask<bool> OnDetermineCanPause();

        bool IDownloadStrategy.CanPause => _canPause;

        void IDownloadStrategy.Download(IDownload download)
        {
            if (download is not TDownload)
            {
                throw new ArgumentException($"Expected {typeof(TDownload).Name} but got {download.GetType().Name}", nameof(download));
            }

            OnDownload((TDownload)download);

            Status = DownloadStatus.Waiting;
        }

        async ValueTask IDownloadStrategy.StartAsync()
        {
            _canPause = await OnDetermineCanPause();

            await OnStartAsync();

            Status = DownloadStatus.Running;
        }

        async ValueTask IDownloadStrategy.PauseAsync()
        {
            await OnPauseAsync();

            Status = DownloadStatus.Paused;
        }

        async ValueTask IDownloadStrategy.ResumeAsync()
        {
            await OnResumeAsync();

            Status = DownloadStatus.Running;
        }

        async ValueTask IDownloadStrategy.StopAsync()
        {
            await OnStopAsync();

            Status = DownloadStatus.Stopped;
        }
    }
}
