using System.Windows;


namespace GenFunc
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NormalAllocButtonClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new NormalAlloc();
        }

        private void ExponentialAllocButtonClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new ExponentialAlloc();
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
