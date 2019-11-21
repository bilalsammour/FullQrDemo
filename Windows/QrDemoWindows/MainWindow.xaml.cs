using System.Windows;

namespace QrDemoWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void Read_Click(object sender, RoutedEventArgs e)
        {
            var windows = new ReaderWindow();
            windows.Show();
        }

        void Write_Click(object sender, RoutedEventArgs e)
        {
            var windows = new WriterWindow();
            windows.Show();
        }
    }
}
