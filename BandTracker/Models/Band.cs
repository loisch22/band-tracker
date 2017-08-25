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
  }
}
