using Xamarin.Forms;

namespace QrDemo
{
    public partial class QrCodePage : ContentPage
    {
        public QrCodePage()
        {
            InitializeComponent();

            Go.Clicked += Go_Clicked;
        }

        void Go_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textCode.Text))
                return;

            Qr.BarcodeValue = textCode.Text;
        }
    }
}
