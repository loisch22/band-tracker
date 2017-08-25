using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace BandTracker.Models
{
  public class Venue
  {
    private int _id;
    private string _name;
    private int _price;

    public Venue(string name, int price, int id = 0)
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

    public override bool Equals(System.Object otherVenue)
    {
      if (!(otherVenue is Venue))
      {
        return false;
      }
      else
      {
        Venue newVenue = (Venue) otherVenue;
        bool idEquality = (this.GetId()) == newVenue.GetId();
        bool nameEquality = (this.GetName()) == newVenue.GetName();
        bool priceEquality = (this.GetPrice()) == newVenue.GetPrice();

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
      cmd.CommandText = @"INSERT INTO venues (name, price) VALUE (@name, @price);";

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

    public static List<Venue> GetAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM venues ORDER BY name;";

      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      List<Venue> allVenues = new List<Venue>{};

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        int price = rdr.GetInt32(2);
        Venue foundVenue = new Venue(name, price, id);
        allVenues.Add(foundVenue);
      }
      conn.Close();
      return allVenues;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM venues;";

      cmd.ExecuteNonQuery();
      conn.Close();
    }

  }
}
