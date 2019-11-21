using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace QrDemo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void ScanCustomPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScannerPage());
        }

        async void GenerateBarcode(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QrCodePage());
        }
    }
}
