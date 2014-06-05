using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace MahApps.Metro.Simple.Demo
{
  /// <summary>
  /// Interaction logic for AccentThemeTestWindow.xaml
  /// </summary>
  public partial class AccentThemeTestWindow : MetroWindow
  {
    public AccentThemeTestWindow()
    {
      InitializeComponent();
    }

    private void DarkButtonClick(object sender, RoutedEventArgs e)
    {
      var theme = ThemeManager.DetectAppStyle(this);
      ThemeManager.ChangeAppStyle(this, theme.Item2, ThemeManager.GetAppTheme("BaseDark"));
    }

    private void LightButtonClick(object sender, RoutedEventArgs e)
    {
      var theme = ThemeManager.DetectAppStyle(this);
      ThemeManager.ChangeAppStyle(this, theme.Item2, ThemeManager.GetAppTheme("BaseLight"));
    }

    private void BlueButtonClick(object sender, RoutedEventArgs e)
    {
      var theme = ThemeManager.DetectAppStyle(this);
      ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Blue"), theme.Item1);
    }

    private void RedButtonClick(object sender, RoutedEventArgs e)
    {
      var theme = ThemeManager.DetectAppStyle(this);
      ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Red"), theme.Item1);
    }

    private void GreenButtonClick(object sender, RoutedEventArgs e)
    {
      var theme = ThemeManager.DetectAppStyle(this);
      ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent("Green"), theme.Item1);
    }

    private void DarkAppButtonClick(object sender, RoutedEventArgs e)
    {
      var theme = ThemeManager.DetectAppStyle(Application.Current);
      ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, ThemeManager.GetAppTheme("BaseDark"));
    }

    private void LightAppButtonClick(object sender, RoutedEventArgs e)
    {
      var theme = ThemeManager.DetectAppStyle(Application.Current);
      ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, ThemeManager.GetAppTheme("BaseLight"));
    }

    private void BlueAppButtonClick(object sender, RoutedEventArgs e)
    {
      var theme = ThemeManager.DetectAppStyle(Application.Current);
      ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Blue"), theme.Item1);
    }

    private void RedAppButtonClick(object sender, RoutedEventArgs e)
    {
      var theme = ThemeManager.DetectAppStyle(Application.Current);
      ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Red"), theme.Item1);
    }

    private void GreenAppButtonClick(object sender, RoutedEventArgs e)
    {
      var theme = ThemeManager.DetectAppStyle(Application.Current);
      ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("Green"), theme.Item1);
    }

    private void CustomThemeAppButtonClick(object sender, RoutedEventArgs e)
    {
      var theme = ThemeManager.DetectAppStyle(Application.Current);
      ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, ThemeManager.GetAppTheme("CustomTheme"));
    }

    private void CustomAccent1AppButtonClick(object sender, RoutedEventArgs e)
    {
      var theme = ThemeManager.DetectAppStyle(Application.Current);
      ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("CustomAccent1"), theme.Item1);
    }

    private void CustomAccent2AppButtonClick(object sender, RoutedEventArgs e)
    {
      var theme = ThemeManager.DetectAppStyle(Application.Current);
      ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("CustomAccent2"), theme.Item1);
    }

    private void AccentSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var selectedAccent = AccentSelector.SelectedItem as Accent;
      if (selectedAccent != null)
      {
        var theme = ThemeManager.DetectAppStyle(Application.Current);
        ThemeManager.ChangeAppStyle(Application.Current, selectedAccent, theme.Item1);
        Application.Current.MainWindow.Activate();
      }
    }
  }
}
