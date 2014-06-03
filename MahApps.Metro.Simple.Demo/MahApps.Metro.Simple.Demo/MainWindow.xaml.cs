using System;
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

    private MetroWindow accentThemeTestWindow;

    private void AccentTest_ButtonClick(object sender, RoutedEventArgs e)
    {
      if (accentThemeTestWindow != null)
      {
        accentThemeTestWindow.Close();
      }

      accentThemeTestWindow = new AccentThemeTestWindow();
      accentThemeTestWindow.Show();
    }
  }
}
