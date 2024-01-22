namespace MrBildo.SprintDownloader.Services
{
    public interface IDownloadStrategyRegistry
    {
        Type Get(Guid id);

        Type? Find(string name);

        IEnumerable<Type> All { get; }

        void Register<TStrategy>(TStrategy strategyType) where TStrategy : IDownloadStrategy;
    }

    public sealed class DownloadStrategyRegistry : IDownloadStrategyRegistry
    {
        private readonly Dictionary<Guid, Type> _idToType = [];

        private readonly Dictionary<string, Type> _nameToType = [];

        public Type Get(Guid id) => _idToType[id];

        public Type? Find(string name) => _nameToType.TryGetValue(name, out var type) ? type : null;

        public IEnumerable<Type> All => _idToType.Values;

        public void Register<TStrategy>(TStrategy strategyType) where TStrategy : IDownloadStrategy
        {
            _idToType[strategyType.Id] = strategyType.GetType();
            _nameToType[strategyType.Name] = strategyType.GetType();
        }
    }
}
