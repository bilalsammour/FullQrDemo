using Microsoft.Win32;
using System;
using System.IO;
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
            if (string.IsNullOrEmpty(CodeText.Text))
                return;

            var fileDialog = new SaveFileDialog
            {
                Filter = "PNG|*.png",
                Title = "QR"
            };

            fileDialog.ShowDialog();

            string fileName = fileDialog.FileName;

            if (string.IsNullOrEmpty(fileName))
                return;

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

                    WriteBitmap(fileName, source);
                }
                catch (Exception ex) { }
            }
        }

        void WriteBitmap(string fileName, BitmapSource bmp)
        {
            var encoder = new PngBitmapEncoder();
            var outputFrame = BitmapFrame.Create(bmp);
            encoder.Frames.Add(outputFrame);

            using (var file = File.OpenWrite(fileName))
            {
                encoder.Save(file);
            }
        }
    }
}
