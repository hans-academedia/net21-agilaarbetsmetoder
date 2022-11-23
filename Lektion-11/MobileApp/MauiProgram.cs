using Microsoft.Extensions.Logging;
using MobileApp.ViewModels;
using MobileApp.Views;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace MobileApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseBarcodeReader()
			.ConfigureMauiHandlers(x =>
			{
				x.AddHandler(typeof(CameraBarcodeReaderView), typeof(CameraBarcodeReaderViewHandler));
                x.AddHandler(typeof(CameraView), typeof(CameraViewHandler));
                x.AddHandler(typeof(BarcodeGeneratorView), typeof(BarcodeGeneratorViewHandler));
            })
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddTransient<DetailsViewModel>();
		builder.Services.AddTransient<DetailsPage>();

        builder.Services.AddTransient<QrViewModel>();
        builder.Services.AddTransient<QrPage>();

        return builder.Build();
	}
}
