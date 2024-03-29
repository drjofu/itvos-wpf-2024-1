﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ressourcen2
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void Ändern1(object sender, RoutedEventArgs e)
    {
      var brush = (LinearGradientBrush)this.Resources["LGB"];
      brush.GradientStops[0].Color = Colors.Red;
    }

    private void Ändern2(object sender, RoutedEventArgs e)
    {
      Resources["LGB"] = new LinearGradientBrush(Colors.Yellow, Colors.Violet, 30);
    }
  }
}