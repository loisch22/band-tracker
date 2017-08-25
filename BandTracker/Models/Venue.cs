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
  }
}
