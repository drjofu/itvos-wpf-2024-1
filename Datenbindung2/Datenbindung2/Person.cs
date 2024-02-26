namespace Datenbindung2
{
  public class Person
  {
    public string? Name { get; set; }
    public int Alter { get; set; }
    public string? Wohnort { get; set; }

    public bool IstErfahren => Alter > 50;
  }

  public class Firma
  {
    public string Name { get; set; } = "Hinz & Kunz";
    public List<Person> Mitarbeiter { get; set; } = new List<Person>()
        {
          new Person{Name="Dagobert", Wohnort="Entenhausen", Alter=78},
          new Person{Name="Donald", Wohnort="Entenhausen", Alter=55},
          new Person{Name="Micky", Wohnort="Maushausen", Alter=44},
          new Person{Name="Bunny", Wohnort="Hasenhausen", Alter=23},
          new Person{Name="Snoopy", Wohnort="USA", Alter=4}
        };
  }
}
