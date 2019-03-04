using System.Collections.Generic;

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
      _instances.Clear();
    }

    public static List<Stylist> GetAll()
    {
      return _instances;
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
