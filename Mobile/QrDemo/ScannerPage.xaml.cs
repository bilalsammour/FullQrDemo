using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing;

namespace QrDemo
{
    public partial class ScannerPage : ContentPage
    {
        public ScannerPage()
        {
            InitializeComponent();

            zxing.OnScanResult += Zxing_OnScanResult;
            overlay.FlashButtonClicked += Overlay_FlashButtonClicked;
        }

        void Zxing_OnScanResult(Result result)
        {
            Device.BeginInvokeOnMainThread(async () => await Zxing_OnScanResultUi(result));
        }

        async Task Zxing_OnScanResultUi(Result result)
        {
            zxing.IsAnalyzing = false;
            await DisplayAlert("Scanned Barcode", result.Text, "OK");
            await Navigation.PopAsync();
        }

        void Overlay_FlashButtonClicked(Button sender, EventArgs e)
        {
            zxing.IsTorchOn = !zxing.IsTorchOn;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            zxing.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            zxing.IsScanning = false;

            base.OnDisappearing();
        }
    }
}
