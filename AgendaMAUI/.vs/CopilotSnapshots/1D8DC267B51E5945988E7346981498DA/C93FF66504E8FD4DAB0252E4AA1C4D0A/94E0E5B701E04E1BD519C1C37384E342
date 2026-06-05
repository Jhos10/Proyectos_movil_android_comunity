using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.Maui.Storage;

namespace AgendaMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Registrar servicio de base de datos y páginas/ViewModels para inyección de dependencias
            builder.Services.AddSingleton<AgendaMAUI.Services.DatabaseService>(provider =>
            {
                string dbPath = Path.Combine(FileSystem.AppDataDirectory, "contacts.db3");
                return new AgendaMAUI.Services.DatabaseService(dbPath);
            });

            builder.Services.AddTransient<AgendaMAUI.ViewModels.ContactsViewModel>();
            builder.Services.AddTransient<MainPage>();

            return builder.Build();
        }
    }
}
