using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string _details;
    private int _id;
    public Stylist(string stylistDetails, int id = 0)
    {
      _details = stylistDetails;
      _id = id;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = this.GetId().Equals(newStylist.GetId());
        bool detailsEquality = this.GetDetails().Equals(newStylist.GetDetails());
        return (idEquality && detailsEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }

    public string GetDetails()
    {
      return _details;
    }

    public int GetId()
    {
      return _id;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (details) VALUES (@details);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@details";
      name.Value = this._details;
      cmd.Parameters.Add(name);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
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
      cmd.CommandText = @"SELECT * FROM stylists;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int StylistId = rdr.GetInt32(0);
        string StylistDetails = rdr.GetString(1);
        Stylist newStylist = new Stylist(StylistDetails, StylistId);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    public static Stylist Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int StylistId = 0;
      string StylistDetails = "";
      while(rdr.Read())
      {
        StylistId = rdr.GetInt32(0);
        StylistDetails = rdr.GetString(1);
      }
      Stylist newStylist = new Stylist(StylistDetails, StylistId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newStylist;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public List<Client> GetClients()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT client_id FROM stylists_clients WHERE stylist_id = @Stylist_id;";
      MySqlParameter stylistIdParameter = new MySqlParameter();
      stylistIdParameter.ParameterName = "@StylistId";
      stylistIdParameter.Value = _id;
      cmd.Parameters.Add(stylistIdParameter);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<int> clinetIds = new List<int> {};
      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        clientIds.Add(clientId);
      }
      rdr.Dispose();
      List<Client> clients = new List<Client> {};
      foreach (int clientId in clientIds)
      {
        var clientQuery = conn.CreateCommand() as MySqlCommand;
        clientQuery.CommandText = @"SELECT * FROM clients WHERE id = @ClientId;";
        MySqlParameter clientIdParameter = new MySqlParameter();
        clientIdParameter.ParameterName = "@ClientId";
        clientIdParameter.Value = clientId;
        clientQuery.Parameters.Add(clientIdParameter);
        var clientQueryRdr = clientQuery.ExecuteReader() as MySqlDataReader;
        while (clientQueryRdr.Read())
        {
          int thisClientId = clientQueryRdr.GetInt32(0);
          string clinetName = clientQueryRdr.GetString(1);
          Client foundClient = new Client(clientName, thisClientId);
          clinets.Add(foundClient);
        }
        itemQueryRdr.Dispose();
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return clients;
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = new MySqlCommand("DELETE FROM sttlists WHERE id = @StylistId; DELETE FROM stylists_clients WHERE stylist_id = @StylistId;", conn);
      MySqlParameter stylistIdParameter = new MySqlParameter();
      stylistIdParameter.ParameterName = "@StylistId";
      stylistIdParameter.Value = this.GetId();
      cmd.Parameters.Add(stylistIdParameter);
      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }

    public void AddClient(Client newClient)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists_clients (stylist_id, client_id) VALUES (@StylistId, @ClientId);";
      MySqlParameter stylist_id = new MySqlParameter();
      stylist_id.ParameterName = "@StylistId";
      stylist_id.Value = _id;
      cmd.Parameters.Add(stylist_id);
      MySqlParameter client_id = new MySqlParameter();
      client_id.ParameterName = "@ClientId";
      client_id.Value = newClient.GetId();
      cmd.Parameters.Add(client_id);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

  }
}
