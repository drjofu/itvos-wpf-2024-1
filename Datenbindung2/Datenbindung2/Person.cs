using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Datenbindung2
{
  public class Person : INotifyPropertyChanged
  {
    public string? Name { get; set; }
    //   public int Alter { get; set; }
    private int alter;

    public int Alter
    {
      get { return alter; }
      set
      {
        if (alter == value) return;

        alter = value;
        //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Alter)));
        OnPropertyChanged();
        OnPropertyChanged(nameof(IstErfahren));
      }
    }

    public string? Wohnort { get; set; }

    public bool IstErfahren => Alter > 50;

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }

  public class Firma
  {
    public string Name { get; set; } = "Hinz & Kunz";
    public ObservableCollection<Person> Mitarbeiter { get; set; } = new ObservableCollection<Person>()
        {
          new Person{Name="Dagobert", Wohnort="Entenhausen", Alter=78},
          new Person{Name="Donald", Wohnort="Entenhausen", Alter=55},
          new Person{Name="Micky", Wohnort="Maushausen", Alter=44},
          new Person{Name="Bunny", Wohnort="Hasenhausen", Alter=23},
          new Person{Name="Snoopy", Wohnort="USA", Alter=4}
        };
  }
}
