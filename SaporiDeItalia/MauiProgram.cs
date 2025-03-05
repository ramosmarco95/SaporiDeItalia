using SaporiDeItalia.Services;
using SaporiDeItalia.ViewModels;
using SaporiDeItalia.Views;
using Microsoft.Extensions.Logging;



namespace SaporiDeItalia;

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
        // Register services
        builder.Services.AddSingleton<MenuService>();
        builder.Services.AddSingleton<MenuViewModel>();
        builder.Services.AddTransient<MenuPage>();

		// Register services
		builder.Services.AddTransient<ContactService>();
        builder.Services.AddTransient<ContactViewModel>();
        builder.Services.AddTransient<ContactPage>();

        // Register services
        builder.Services.AddTransient<LocationViewModel>();
        builder.Services.AddTransient<LocationPage>();


        return builder.Build();
	}
}
