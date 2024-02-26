using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace Datenbindung1
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    static App()
    {
      Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
      Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

      string text = string.Format("{0:0.0}", 1.234);

      FrameworkElement.LanguageProperty.OverrideMetadata(
        typeof(FrameworkElement),
        new FrameworkPropertyMetadata(
          XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.Name))
        );

    }
  }

}
