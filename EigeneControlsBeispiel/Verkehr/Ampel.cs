using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Verkehr
{
  /// <summary>
  /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
  ///
  /// Step 1a) Using this custom control in a XAML file that exists in the current project.
  /// Add this XmlNamespace attribute to the root element of the markup file where it is 
  /// to be used:
  ///
  ///     xmlns:MyNamespace="clr-namespace:Verkehr"
  ///
  ///
  /// Step 1b) Using this custom control in a XAML file that exists in a different project.
  /// Add this XmlNamespace attribute to the root element of the markup file where it is 
  /// to be used:
  ///
  ///     xmlns:MyNamespace="clr-namespace:Verkehr;assembly=Verkehr"
  ///
  /// You will also need to add a project reference from the project where the XAML file lives
  /// to this project and Rebuild to avoid compilation errors:
  ///
  ///     Right click on the target project in the Solution Explorer and
  ///     "Add Reference"->"Projects"->[Select this project]
  ///
  ///
  /// Step 2)
  /// Go ahead and use your control in the XAML file.
  ///
  ///     <MyNamespace:CustomControl1/>
  ///
  /// </summary>
  [TemplatePart(Name = "PART_LampeRot", Type = typeof(Shape))]
  [TemplatePart(Name = "PART_LampeGruen", Type = typeof(Shape))]
  [DefaultProperty(nameof(IstGrün))]
  public class Ampel : Control
  {
    private Shape? lampeRot;
    private Shape? lampeGruen;

    static Ampel()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(Ampel), new FrameworkPropertyMetadata(typeof(Ampel)));
    }


    // propdp
    [Category("Verkehr")]
    [Description("Schaltet die Ampel auf grün (true) oder rot (false)")]
    public bool IstGrün
    {
      get { return (bool)GetValue(IstGrünProperty); }
      set { SetValue(IstGrünProperty, value); }
    }

    // Using a DependencyProperty as the backing store for IstGrün.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IstGrünProperty =
        DependencyProperty.Register(nameof(IstGrün), typeof(bool), typeof(Ampel),
          new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnIstGrünChanged));

    private static void OnIstGrünChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      Ampel ampel = (Ampel)d;
      ampel.Schalten();
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      lampeRot = (Shape)this.GetTemplateChild("PART_LampeRot");
      lampeGruen = (Shape)this.GetTemplateChild("PART_LampeGruen");
      Schalten();
    }

    private void Schalten()
    {
      if (lampeRot is null) return;

      if (IstGrün)
      {
        lampeRot.Opacity = 0.2;
        lampeGruen!.Opacity = 1;
      }
      else
      {
        lampeRot.Opacity = 1;
        lampeGruen!.Opacity = 0.2;
      }
    }


  }
}