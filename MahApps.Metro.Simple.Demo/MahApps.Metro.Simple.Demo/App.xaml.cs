using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Xml;

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

          SetThemeColor(Colors.Red);
          SetThemeColor(Colors.Yellow);
          //SetThemeColor(Colors.Red, true); // yes, again red, test for the thememanager, it should only add once

          base.OnStartup(e);
      }

      public static void SetThemeColor(Color color, bool changeImmediately = false)
      {
          //Log.Info("Setting theme to '{0}'", color.ToString());

          //<Color x:Key="HighlightColor">
          //    #800080
          //</Color>
          //<Color x:Key="AccentColor">
          //    #CC800080
          //</Color>
          //<Color x:Key="AccentColor2">
          //    #99800080
          //</Color>
          //<Color x:Key="AccentColor3">
          //    #66800080
          //</Color>
          //<Color x:Key="AccentColor4">
          //    #33800080
          //</Color>

          //<SolidColorBrush x:Key="HighlightBrush" Color="{StaticResource HighlightColor}" />
          //<SolidColorBrush x:Key="AccentColorBrush" Color="{StaticResource AccentColor}" />
          //<SolidColorBrush x:Key="AccentColorBrush2" Color="{StaticResource AccentColor2}" />
          //<SolidColorBrush x:Key="AccentColorBrush3" Color="{StaticResource AccentColor3}" />
          //<SolidColorBrush x:Key="AccentColorBrush4" Color="{StaticResource AccentColor4}" />
          //<SolidColorBrush x:Key="WindowTitleColorBrush" Color="{StaticResource AccentColor}" />
          //<SolidColorBrush x:Key="AccentSelectedColorBrush" Color="White" />
          //<LinearGradientBrush x:Key="ProgressBrush" EndPoint="0.001,0.5" StartPoint="1.002,0.5">
          //    <GradientStop Color="{StaticResource HighlightColor}" Offset="0" />
          //    <GradientStop Color="{StaticResource AccentColor3}" Offset="1" />
          //</LinearGradientBrush>
          //<SolidColorBrush x:Key="CheckmarkFill" Color="{StaticResource AccentColor}" />
          //<SolidColorBrush x:Key="RightArrowFill" Color="{StaticResource AccentColor}" />

          //<Color x:Key="IdealForegroundColor">
          //    Black
          //</Color>
          //<SolidColorBrush x:Key="IdealForegroundColorBrush" Color="{StaticResource IdealForegroundColor}" />

          //Log.Debug("Creating runtime accent resource dictionary");

          var resourceDictionary = new ResourceDictionary();

          resourceDictionary.Add("HighlightColor", color);
          resourceDictionary.Add("AccentColor", Color.FromArgb((byte)(204), color.R, color.G, color.B));
          resourceDictionary.Add("AccentColor2", Color.FromArgb((byte)(153), color.R, color.G, color.B));
          resourceDictionary.Add("AccentColor3", Color.FromArgb((byte)(102), color.R, color.G, color.B));
          resourceDictionary.Add("AccentColor4", Color.FromArgb((byte)(51), color.R, color.G, color.B));

          resourceDictionary.Add("HighlightBrush", new SolidColorBrush((Color)resourceDictionary["HighlightColor"]));
          resourceDictionary.Add("AccentColorBrush", new SolidColorBrush((Color)resourceDictionary["AccentColor"]));
          resourceDictionary.Add("AccentColorBrush2", new SolidColorBrush((Color)resourceDictionary["AccentColor2"]));
          resourceDictionary.Add("AccentColorBrush3", new SolidColorBrush((Color)resourceDictionary["AccentColor3"]));
          resourceDictionary.Add("AccentColorBrush4", new SolidColorBrush((Color)resourceDictionary["AccentColor4"]));
          resourceDictionary.Add("WindowTitleColorBrush", new SolidColorBrush((Color)resourceDictionary["AccentColor"]));
          resourceDictionary.Add("AccentSelectedColorBrush", new SolidColorBrush(Colors.White));

          resourceDictionary.Add("ProgressBrush", new LinearGradientBrush(new GradientStopCollection(new[]
                {
                    new GradientStop((Color)resourceDictionary["HighlightColor"], 0),
                    new GradientStop((Color)resourceDictionary["AccentColor3"], 1)
                }), new Point(0.001, 0.5), new Point(1.002, 0.5)));

          resourceDictionary.Add("CheckmarkFill", new SolidColorBrush((Color)resourceDictionary["AccentColor"]));
          resourceDictionary.Add("RightArrowFill", new SolidColorBrush((Color)resourceDictionary["AccentColor"]));

          resourceDictionary.Add("IdealForegroundColor", Colors.Black);
          resourceDictionary.Add("IdealForegroundColorBrush", new SolidColorBrush((Color)resourceDictionary["IdealForegroundColor"]));

          var application = Application.Current;
          var applicationTheme = ThemeManager.AppThemes.First(x => string.Equals(x.Name, "BaseLight"));

          //Log.Debug("Applying theme to MahApps");

          var resDictName = string.Format("ApplicationAccent_{0}.xaml", color.ToString().Replace("#", string.Empty));
          var fileName = Path.Combine(Path.GetTempPath(), resDictName);
          using (var writer = System.Xml.XmlWriter.Create(fileName, new System.Xml.XmlWriterSettings { Indent = true }))
          {
              System.Windows.Markup.XamlWriter.Save(resourceDictionary, writer);
              writer.Close();
          }

          resourceDictionary = new ResourceDictionary() { Source = new Uri(fileName, UriKind.Absolute) };

          var newAccent = new Accent { Name = resDictName, Resources = resourceDictionary };
          ThemeManager.AddAccent(newAccent.Name, newAccent.Resources.Source);
          if (changeImmediately)
          {
            ThemeManager.ChangeAppStyle(application, newAccent, applicationTheme);
          }
      }
  }
}
