using Microsoft.Extensions.DependencyInjection;

namespace MrBildo.SprintDownloader.Forms
{
    public interface IFormFactory
    {
        T Create<T>() where T : Form;
    }

    public class FormFactory : IFormFactory
    {
        private readonly IServiceScope _serviceScope;

        public FormFactory(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScope = serviceScopeFactory.CreateScope();
        }

        public T Create<T>() where T : Form => _serviceScope.ServiceProvider.GetRequiredService<T>();
    }
}
