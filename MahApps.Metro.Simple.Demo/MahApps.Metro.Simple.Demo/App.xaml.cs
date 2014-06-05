using System;
using System.Windows;

namespace MahApps.Metro.Simple.Demo
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
      protected override void OnStartup(StartupEventArgs e)
      {
          ThemeManager.AddAccent("CustomAccent1", new Uri("pack://application:,,,/MahApps.Metro.Simple.Demo;component/CustomAccents/CustomAccent1.xaml"));
          ThemeManager.AddAccent("CustomAccent2", new Uri("pack://application:,,,/MahApps.Metro.Simple.Demo;component/CustomAccents/CustomAccent2.xaml"));
          ThemeManager.AddAppTheme("CustomTheme", new Uri("pack://application:,,,/MahApps.Metro.Simple.Demo;component/CustomAccents/CustomTheme.xaml"));

          base.OnStartup(e);
      }
  }
}
