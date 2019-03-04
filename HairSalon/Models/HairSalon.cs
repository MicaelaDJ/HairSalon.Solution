using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string _name;
    private int _id;
    private static List<Stylist> _instances = new List<Stylist> {};

    public Stylist (string name)
    {
      _name = name;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<Stylist> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Stylist Find(int searchId)
    {
      return _instances[searchId-1];
    }

  }
}
