namespace MrBildo.SprintDownloader.Services
{
    public interface IDownloadStrategyFactory
    {
        IDownloadStrategy Create(Guid id);
    }

    public sealed class DownloadStrategyFactory : IDownloadStrategyFactory
    {
        private readonly IDownloadStrategyRegistry _registry;
        private readonly IServiceProvider _serviceProvider;

        public DownloadStrategyFactory(IDownloadStrategyRegistry registry, IServiceProvider serviceProvider)
        {
            _registry = registry;
            _serviceProvider = serviceProvider;
        }

        public IDownloadStrategy Create(Guid id) => (IDownloadStrategy)_serviceProvider.GetRequiredService(_registry.Get(id));
    }
}
