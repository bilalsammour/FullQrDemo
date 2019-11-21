using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using ZXing;
using ZXing.Common;

namespace QrDemoWindows
{
    /// <summary>
    /// Interaction logic for WriterWindow.xaml
    /// </summary>
    public partial class WriterWindow : Window
    {
        public WriterWindow()
        {
            InitializeComponent();
        }

        void Go_Click(object sender, RoutedEventArgs e)
        {
            var barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = 300,
                    Width = 300,
                    Margin = 1
                }
            };

            using (var bitmap = barcodeWriter.Write(CodeText.Text))
            {
                var hbmp = bitmap.GetHbitmap();
                try
                {
                    var source = Imaging.CreateBitmapSourceFromHBitmap(hbmp, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    QrCodeImage.Source = source;
                }
                catch (Exception ex) { }
            }
        }
    }
}
