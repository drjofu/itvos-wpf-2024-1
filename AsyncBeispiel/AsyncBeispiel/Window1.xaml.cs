using System;
using System.Collections.Generic;
using System.Diagnostics;
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
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class Window1 : Window
  {
    public Window1()
    {
      InitializeComponent();
    }

    private void BTN_Start_Click(object sender, RoutedEventArgs e)
    {
      Task.Run(Inkrementieren);
    }

    private void Inkrementieren()
    {
      for (int i = 0; i < 5; i++)
      {
        //Thread.Sleep(1000);
        //LBL.Content = i;
        //Dispatcher.Invoke(new Action<int>(Ausgeben), i);
        //        Dispatcher.BeginInvoke(new Action<int>(Ausgeben), i);
        //Dispatcher.BeginInvoke(new Action<int>(k => LBL.Content = k), i);
        //Dispatcher.BeginInvoke(new Action<int>(k => Debug.WriteLine(k)), i);
        //Dispatcher.BeginInvoke(new Action(() => LBL.Content = i));
        //Dispatcher.BeginInvoke(new Action(() => Debug.WriteLine(i)));  // Closure!!!
        int x = i;
        Dispatcher.BeginInvoke(new Action(() => Debug.WriteLine(x)));
      }

    }

    private void Ausgeben(int wert)
    {
      LBL.Content = wert;
    }
  }
}
