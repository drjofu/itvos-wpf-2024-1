using System.ComponentModel;

namespace AsyncBeispiel
{
  public class Data : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler? PropertyChanged;

    public int Counter { get; set; }

    private readonly Timer timer;

    public Data()
    {
      timer = new Timer(TimerTick, null, 1000, 1000);
    }

    private void TimerTick(object? state)
    {
      Counter++;
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Counter)));
    }
  }
}
