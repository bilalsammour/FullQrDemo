using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;
using ZXing;

namespace QrDemoWindows
{
    /// <summary>
    /// Interaction logic for ReaderWindow.xaml
    /// </summary>
    public partial class ReaderWindow : Window
    {
        public ReaderWindow()
        {
            InitializeComponent();
        }

        void Go_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "PNG|*.png",
                Title = "QR"
            };

            fileDialog.ShowDialog();

            string fileName = fileDialog.FileName;

            if (string.IsNullOrEmpty(fileName))
                return;

            QrCodeImage.Source = new BitmapImage(new Uri(fileName, UriKind.Absolute));

            // create a barcode reader instance
            var barcodeReader = new BarcodeReader();

            // create an in memory bitmap
            var barcodeBitmap = (Bitmap)Image.FromFile(fileName);

            // decode the barcode from the in memory bitmap
            var barcodeResult = barcodeReader.Decode(barcodeBitmap);

            // output results to console
            CodeText.Text = barcodeResult?.Text;
            CodeType.Text = barcodeResult?.BarcodeFormat.ToString();
        }
    }
}
