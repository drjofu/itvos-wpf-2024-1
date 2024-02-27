using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Datenbindung2
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      this.DataContext = new Firma();
    }

    private void AlterInkrementieren(object sender, RoutedEventArgs e)
    {
      var liste = ((Firma)DataContext).Mitarbeiter;
      foreach (var mitarbeiter in liste)
      {
        mitarbeiter.Alter++;
      }
    }

    private void MitarbeiterHinzufügen(object sender, RoutedEventArgs e)
    {
      var liste = ((Firma)DataContext).Mitarbeiter;
      liste.Add(new() { Name = "der Neue", Wohnort = "hier", Alter = 20 });
    }
  }
}