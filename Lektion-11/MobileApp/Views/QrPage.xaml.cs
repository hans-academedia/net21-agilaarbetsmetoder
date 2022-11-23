using MobileApp.ViewModels;

namespace MobileApp.Views;

public partial class QrPage : ContentPage
{
	public QrPage(QrViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		qrReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
		{
			AutoRotate = true,
			Multiple = true
		};
	}

	private void qrReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
	{
		foreach (var code in e.Results)
			Console.WriteLine($"{code.Format} -> {code.Value}");

		Dispatcher.Dispatch(() =>
		{
			Result.Text = e.Results[0].Value;
		});
	}
}