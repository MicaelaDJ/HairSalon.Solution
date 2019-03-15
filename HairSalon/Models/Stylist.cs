using System.Collections.Generic;
using MySql.Data.MySqlClient;
// using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string _details;
    private int _id;

    public Stylist(string details, int id = 0)
    {
      _details = details;
      _id = id;
    }

    public string GetDetails()
    {
      return _details;
    }

    public void SetDetails(string newDetails)
    {
      _details = newDetails;
    }

    public int GetId()
    {
      return _id;
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
        int stylistId = rdr.GetInt32(0);
        string stylistDetails = rdr.GetString(1);
        Stylist newStylist = new Stylist(stylistDetails, stylistId);
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
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
        bool detailsEquality = this.GetDetails() == newStylist.GetDetails();
        return (idEquality && detailsEquality);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists (details) VALUES (@details);";
      MySqlParameter details = new MySqlParameter();
      details.ParameterName = "@details";
      details.Value = this._details;
      cmd.Parameters.Add(details);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Edit(string newDetails)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE stylists SET details = (@stylistDetails) WHERE id = (@stylistId);";
      MySqlParameter stylistNameParameter = new MySqlParameter();
      stylistNameParameter.ParameterName = "@stylistDetails";
      stylistNameParameter.Value = newDetails;
      cmd.Parameters.Add(stylistNameParameter);
      MySqlParameter stylistIdParameter = new MySqlParameter();
      stylistIdParameter.ParameterName = "@stylistId";
      stylistIdParameter.Value = this._id;
      cmd.Parameters.Add(stylistIdParameter);
      cmd.ExecuteNonQuery();
      _details = newDetails;
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
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT clients.* FROM stylists
          JOIN stylist_clients ON (stylists.id = stylist_clients.stylist_id)
          JOIN clients ON (stylist_clients.client_id = clients.id)
          WHERE stylists.id = @StylistId;";
      MySqlParameter stylistIdParameter = new MySqlParameter();
      stylistIdParameter.ParameterName = "@StylistId";
      stylistIdParameter.Value = _id;
      cmd.Parameters.Add(stylistIdParameter);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Client> clients = new List<Client> {};
      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        Client newClient = new Client(clientName, clientId);
        clients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return clients;
    }

    public List<Specialty> GetSpecialties()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT specialties.* FROM stylists
          JOIN stylist_specialties ON (stylists.id = stylist_specialties.stylist_id)
          JOIN specialties ON (stylist_specialties.specialty_id = specialties.id)
          WHERE stylists.id = @StylistId;";
      MySqlParameter stylistIdParameter = new MySqlParameter();
      stylistIdParameter.ParameterName = "@StylistId";
      stylistIdParameter.Value = _id;
      cmd.Parameters.Add(stylistIdParameter);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Specialty> specialties = new List<Specialty> {};
      while(rdr.Read())
      {
        int specialtyId = rdr.GetInt32(0);
        string specialtyName = rdr.GetString(1);
        Specialty newSpecialty = new Specialty(specialtyName, specialtyId);
        specialties.Add(newSpecialty);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return specialties;
    }

    public void AddClient(Client newClient)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylist_clients (stylist_id, client_id) VALUES (@StylistId, @ClientId);";
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

    public void AddSpecialty(Specialty newSpecialty)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylist_specialties (stylist_id, specialty_id) VALUES (@StylistId, @SpecialtyId);";
      MySqlParameter stylist_id = new MySqlParameter();
      stylist_id.ParameterName = "@StylistId";
      stylist_id.Value = _id;
      cmd.Parameters.Add(stylist_id);
      MySqlParameter specialty_id = new MySqlParameter();
      specialty_id.ParameterName = "@SpecialtyId";
      specialty_id.Value = newSpecialty.GetId();
      cmd.Parameters.Add(specialty_id);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = this._id;
      cmd.Parameters.Add(searchId);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }

  }
}
