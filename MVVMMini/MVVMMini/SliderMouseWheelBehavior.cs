using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;

namespace MVVMMini
{
  public class SliderMouseWheelBehavior : Behavior<Slider>
  {
    protected override void OnAttached()
    {
      base.OnAttached();
      this.AssociatedObject.MouseWheel += AssociatedObject_MouseWheel;
    }

    private void AssociatedObject_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
    {
      var newValue = AssociatedObject.Value + e.Delta * AssociatedObject.SmallChange;
      newValue = Math.Max(newValue, AssociatedObject.Minimum);
      newValue = Math.Min(newValue, AssociatedObject.Maximum);
      this.AssociatedObject.Value = newValue;
    }

    protected override void OnDetaching()
    {
      this.AssociatedObject.MouseWheel -= AssociatedObject_MouseWheel;
      base.OnDetaching();
    }
  }
}
