using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string _name;
    // private int _id;
    private static List<Stylist> _instances = new List<Stylist> {};

    public Stylist (string name)
    {
      _name = name;
      // _id = _instances.Count;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    // public int GetId()
    // {
    //   return _id;
    // }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        Stylist newStylist = new Stylist(stylistName, stylistId);
        allStylists.Add(newStylist);
      }

      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    // public static void ClearAll()
    // {
    //   _instances.Clear();
    // }
    //
    // public static Stylist Find(int searchId)
    // {
    //   return _instances[searchId-1];
    // }

  }
}
