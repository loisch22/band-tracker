using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace BandTracker.Models
{
  public class Band
  {
    private int _id;
    private string _name;
    private int _price;

    public Band(string name, int price, int id = 0)
    {
      _name = name;
      _price = price;
      _id = id;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public int GetPrice()
    {
      return _price;
    }

    public override bool Equals(System.Object otherBand)
    {
      if (!(otherBand is Band))
      {
        return false;
      }
      else
      {
        Band newBand = (Band) otherBand;
        bool idEquality = (this.GetId()) == newBand.GetId();
        bool nameEquality = (this.GetName()) == newBand.GetName();
        bool priceEquality = (this.GetPrice()) == newBand.GetPrice();

        return (idEquality && nameEquality && priceEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetId().GetHashCode();
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO bands (name, price) VALUE (@name, @price);";

      MySqlParameter nameParam = new MySqlParameter();
      nameParam.ParameterName = "@name";
      nameParam.Value = _name;
      cmd.Parameters.Add(nameParam);

      MySqlParameter priceParam = new MySqlParameter();
      priceParam.ParameterName = "@price";
      priceParam.Value = _price;
      cmd.Parameters.Add(priceParam);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Band> GetAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM bands ORDER BY name;";

      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      List<Band> allBands = new List<Band>{};

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        int price = rdr.GetInt32(2);
        Band foundBand = new Band(name, price, id);
        allBands.Add(foundBand);
      }
      conn.Close();
      return allBands;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM bands;";

      cmd.ExecuteNonQuery();
      conn.Close();
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM bands WHERE id = @id;";

      MySqlParameter idParam = new MySqlParameter();
      idParam.ParameterName = "@id";
      idParam.Value = _id;
      cmd.Parameters.Add(idParam);

      cmd.ExecuteNonQuery();
      conn.Close();
    }

    public static Band Find(int searchId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM bands WHERE id = @id;";

      MySqlParameter idParam = new MySqlParameter();
      idParam.ParameterName = "@id";
      idParam.Value = searchId;
      cmd.Parameters.Add(idParam);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int id = 0;
      string name = "";
      int price = 0;

      while(rdr.Read())
      {
        id = rdr.GetInt32(0);
        name = rdr.GetString(1);
        price = rdr.GetInt32(2);
      }
      Band foundBand = new Band(name, price, id);
      conn.Close();
      return foundBand;
    }

    public void Update(string newName, int newPrice)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE bands SET name = @name, price = @price WHERE id = @id;";

      MySqlParameter nameParam = new MySqlParameter();
      nameParam.ParameterName = "@name";
      nameParam.Value = newName;
      cmd.Parameters.Add(nameParam);

      MySqlParameter priceParam = new MySqlParameter();
      priceParam.ParameterName = "@price";
      priceParam.Value = newPrice;
      cmd.Parameters.Add(priceParam);

      MySqlParameter idParam = new MySqlParameter();
      idParam.ParameterName = "@id";
      idParam.Value = _id;
      cmd.Parameters.Add(idParam);

      cmd.ExecuteNonQuery();
      conn.Close();
    }

    public void AddVenue(int venueId)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO bands_venues (band_id, venue_id) VALUES (@bandId, @venueId);";

      MySqlParameter bandIdParam = new MySqlParameter();
      bandIdParam.ParameterName = "@bandId";
      bandIdParam.Value = _id;
      cmd.Parameters.Add(bandIdParam);

      MySqlParameter idParam = new MySqlParameter();
      idParam.ParameterName = "@venueId";
      idParam.Value = venueId;
      cmd.Parameters.Add(idParam);

      cmd.ExecuteNonQuery();
      conn.Close();
    }

    public List<Venue> GetVenues()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT venues.*
      FROM bands
      JOIN bands_venues ON (bands.id = bands_venues.band_id)
      JOIN venues ON (bands_venues.venue_id = venues.id)
      WHERE bands.id = @bandId;";

      MySqlParameter idParam = new MySqlParameter();
      idParam.ParameterName = "@bandId";
      idParam.Value = _id;
      cmd.Parameters.Add(idParam);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Venue> allVenues = new List<Venue>{};

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        int price = rdr.GetInt32(2);
        Venue newVenue = new Venue(name, price, id);
        allVenues.Add(newVenue);
      }
      conn.Close();
      return allVenues;
    }
  }
}
