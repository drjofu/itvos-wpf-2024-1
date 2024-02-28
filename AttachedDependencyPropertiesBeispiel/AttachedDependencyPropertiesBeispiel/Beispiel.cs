using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AttachedDependencyPropertiesBeispiel
{
  public class Beispiel
  {

    // propa
    public static int GetZahl(DependencyObject obj)
    {
      return (int)obj.GetValue(ZahlProperty);
    }

    public static void SetZahl(DependencyObject obj, int value)
    {
      obj.SetValue(ZahlProperty, value);
    }

    // Using a DependencyProperty as the backing store for Zahl.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ZahlProperty =
        DependencyProperty.RegisterAttached("Zahl", typeof(int), typeof(Beispiel), new FrameworkPropertyMetadata(0, OnZahlChanged));

    private static void OnZahlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      Debug.WriteLine($"Objekt: {d.GetType().Name}, Wert: {e.NewValue}");
    }
  }
}
