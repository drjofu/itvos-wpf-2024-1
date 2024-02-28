using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AsyncBeispiel
{
  /// <summary>
  /// Interaction logic for Window2.xaml
  /// </summary>
  public partial class Window2 : Window
  {
    public Window2()
    {
      InitializeComponent();
    }

    private async void BTN_Start_Click(object sender, RoutedEventArgs e)
    {
      BTN_Start.IsEnabled = false;
      var progress = new Progress<int>(x => LBL.Content = x);
      await Inkrementieren(progress);
      //Inkrementieren(progress)
      //  .ContinueWith(t => BTN_Start.IsEnabled = true, TaskScheduler.FromCurrentSynchronizationContext());
      await Task.Delay(1000);
      LBL.Content = "nächste Aktion";
      await Task.Delay(1000);
      await Inkrementieren(progress);
      BTN_Start.IsEnabled = true;

    }

    private Task Inkrementieren(IProgress<int> progress)
    {
      return Task.Run(() =>
      {
        for (int i = 0; i < 5; i++)
        {
          Thread.Sleep(1000);
          progress.Report(i);
          //throw new Exception("ohhh");
        }

      });
    }

  }
}
