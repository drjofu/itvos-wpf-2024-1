using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

    private CancellationTokenSource cancellationTokenSource;

    private async void BTN_Start_Click(object sender, RoutedEventArgs e)
    {
      BTN_Start.IsEnabled = false;
      BTN_Stop.IsEnabled = true;
      var progress = new Progress<int>(x => LBL.Content = x);

      using (cancellationTokenSource = new CancellationTokenSource())
      {
        Task t = Inkrementieren(progress, cancellationTokenSource.Token);
        try
        {
          await t;
        }
        catch (Exception ex)
        {
        }

        //Inkrementieren(progress)
        //  .ContinueWith(t => BTN_Start.IsEnabled = true, TaskScheduler.FromCurrentSynchronizationContext());
        //await Task.Delay(1000);
        //LBL.Content = "nächste Aktion";
        //await Task.Delay(1000);
        //await Inkrementieren(progress, cancellationTokenSource.Token);

        BTN_Start.IsEnabled = true;
        BTN_Stop.IsEnabled = false;
        LBL.Content = t.Status.ToString();
      }
    }

    private Task Inkrementieren(IProgress<int> progress, CancellationToken cancellationToken)
    {
      return Task.Run(async () =>
      {
        for (int i = 0; i < 5; i++)
        {
          //throw new ApplicationException("ohh...");

          if (cancellationTokenSource.IsCancellationRequested)
          {
            // aufräumen...
            cancellationToken.ThrowIfCancellationRequested();
          }

          //Thread.Sleep(1000);
          await Task.Delay(1000, cancellationToken);

          progress.Report(i);
          //throw new Exception("ohhh");
        }

      }, cancellationToken);
    }

    private void BTN_Stop_Click(object sender, RoutedEventArgs e)
    {
      cancellationTokenSource?.Cancel();
    }
  }
}
