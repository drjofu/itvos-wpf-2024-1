using System.ServiceModel.Syndication;
using System.Windows;
using System.Xml;

namespace RssFeedÜbung
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      var reader = XmlReader.Create("http://www.spiegel.de/schlagzeilen/tops/index.rss");
      var feed = SyndicationFeed.Load(reader);
      this.DataContext=feed;
    }
  }
}