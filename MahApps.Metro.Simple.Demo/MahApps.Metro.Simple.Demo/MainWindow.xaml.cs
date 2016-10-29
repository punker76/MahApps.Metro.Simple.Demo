using System.Windows;
using MahApps.Metro.Controls;

namespace MahApps.Metro.Simple.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GitHubButtonClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MahApps/MahApps.Metro");
        }
    }
}
