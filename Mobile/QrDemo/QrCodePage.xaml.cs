using Xamarin.Forms;

namespace QrDemo
{
    public partial class QrCodePage : ContentPage
    {
        public QrCodePage()
        {
            InitializeComponent();

            Generate.Clicked += Generate_Clicked;
        }

        void Generate_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textCode.Text))
                return;

            Qr.BarcodeValue = textCode.Text;
        }
    }
}
