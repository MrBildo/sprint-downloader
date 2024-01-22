using System.Reflection;
using Microsoft.Extensions.Hosting;

namespace MrBildo.SprintDownloader
{
    internal static class Program
    {
        private static IServiceProvider Container { get; set; } = default!;

        [STAThread]
        private static void Main()
        {
            Container = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    //services.AddHttpClient<IDownloaderService<WiiUDownload>, WiiUDownloaderService>("wii-u")
                    //    .ConfigureHttpClient(client =>
                    //    {
                    //        client.BaseAddress = new Uri("https://www.fanzootechnology.com");
                    //    });

                    services.AddSingleton<IFormFactory, FormFactory>();
                    services.AddSingleton<DownloadManager>();

                    foreach (var form in Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(Form))))
                    {
                        services.AddTransient(form);
                    }

                    services.AddTransient<IWiiUTitleLoader, WiiUTitleLoader>();
                })
                    .Build()
                        .Services;

            ApplicationConfiguration.Initialize();

            Application.Run(Container.GetRequiredService<MainForm>());
        }
    }
}