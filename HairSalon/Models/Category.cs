using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Category
  {
    private static List<Category> _instances = new List<Category> {};
    private string _details;
    private int _id;
    private List<Stylist> _stylists;

    public Category(string categoryDetails)
    {
      _details = categoryDetails;
      _instances.Add(this);
      _id = _instances.Count;
      _stylists = new List<Stylist>{};
    }

    public string GetDetails()
    {
      return _details;
    }

    public int GetId()
    {
      return _id;
    }

    public void AddStylist(Stylist stylist)
    {
      _stylists.Add(stylist);
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<Category> GetAll()
    {
      return _instances;
    }

    public static Category Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public List<Stylist> GetStylists()
    {
      return _stylists;
    }

  }
}
