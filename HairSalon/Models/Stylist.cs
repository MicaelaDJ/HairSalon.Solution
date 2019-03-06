using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Stylist
  {
    private static List<Stylist> _instances = new List<Stylist> {};
    private string _details;
    private int _id;
    private List<Client> _clients;

    public Stylist(string stylistDetails)
    {
      _details = stylistDetails;
      _instances.Add(this);
      _id = _instances.Count;
      _clients = new List<Client>{};
    }

    public string GetDetails()
    {
      return _details;
    }

    public int GetId()
    {
      return _id;
    }

    public void AddClient(Client client)
    {
      _clients.Add(client);
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM categories;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM categories;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int StylistId = rdr.GetInt32(0);
        string StylistDetails = rdr.GetString(1);
        Stylist newStylist = new Stylist(StylistDetails);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    public static Stylist Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public List<Client> GetClients()
    {
      return _clients;
    }

  }
}
