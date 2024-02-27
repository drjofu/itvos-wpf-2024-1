using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace RssFeedBeispiel
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      WebClient wc = new WebClient();
      //WebProxy proxy = new WebProxy("...", 1234);
      //proxy.UseDefaultCredentials = true;
      //wc.Proxy = proxy;
      var reader = XmlReader.Create(wc.OpenRead("http://www.spiegel.de/schlagzeilen/tops/index.rss"));

      //wc.UseDefaultCredentials = true;

      //var reader = XmlReader.Create(File.OpenText("index.rss"));

      //var reader = XmlReader.Create("http://www.spiegel.de/schlagzeilen/tops/index.rss");

      var feed = SyndicationFeed.Load(reader);
      this.DataContext = feed;
    }

    private void NavClick(object sender, RoutedEventArgs e)
    {
      string url = ((Hyperlink)sender).NavigateUri.AbsoluteUri;

      // Process.Start(url);
      var psi = new ProcessStartInfo(url);
      psi.UseShellExecute = true;

      Process.Start(psi);
    }

    private void RefreshClick(object sender, RoutedEventArgs e)
    {
      var reader = XmlReader.Create("http://www.spiegel.de/schlagzeilen/tops/index.rss");
      var feed = SyndicationFeed.Load(reader);
      this.DataContext = feed;
      
    }
  }
}
