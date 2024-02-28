using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidierungenBeispiel
{
  public class Data : IDataErrorInfo
  {
    private int geradeZahl;
    public int GeradeZahl
    {
      get { return geradeZahl; }
      set
      {
        if (value % 2 != 0) throw new ApplicationException($"{value} ist ungerade");
        geradeZahl = value;
      }
    }

    public int GeradeZahl2 { get; set; }
    public int GeradeZahl3 { get; set; }

    public string this[string columnName] {
      get
      {
        switch (columnName)
        {
          case nameof(GeradeZahl2):
            if (GeradeZahl2 % 2 != 0)
              return $"{GeradeZahl2} ist nicht gerade!";
            return "";
        }
        return "das habe ich nicht erwartet...";
      }
    }
    public string Error => throw new NotImplementedException();
  }
}
