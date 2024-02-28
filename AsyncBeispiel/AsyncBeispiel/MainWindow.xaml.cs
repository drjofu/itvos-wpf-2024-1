using System.Windows;
using System.Windows.Threading;

namespace AsyncBeispiel
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private long zähler;
    private DispatcherTimer timer;
    private object syncObj = new object();

    public MainWindow()
    {
      InitializeComponent();
      timer = new DispatcherTimer();
      timer.Interval = TimeSpan.FromMilliseconds(100);
      timer.Tick += Timer_Tick;
      timer.Start();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
      LBL.Content = zähler;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      //Inkrementieren();
      //Task.Run(Inkrementieren);
      
      Task.Factory.StartNew(new Action(Inkrementieren));
    }

    private void Inkrementieren()
    {
      for (long i = 0; i < 100000000; i++)
      {
        //  Monitor.Enter(syncObj);
        //  try
        //  {
        //    zähler++;
        //  }
        //  finally
        //  {
        //    Monitor.Exit(syncObj);
        //  }
        lock (syncObj)
        {
          zähler++;
        }
      }
    }
  }
}