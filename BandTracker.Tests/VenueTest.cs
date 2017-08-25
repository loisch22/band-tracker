using Microsoft.VisualStudio.TestTools.UnitTesting;
using BandTracker;
using System;
using BandTracker.Models;
using System.Collections.Generic;

namespace BandTracker.Tests
{
  [TestClass]
  public class VenueTests : IDisposable
  {

     public VenueTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=band_tracker_test;";
    }

    public void Dispose()
    {
      Venue.DeleteAll();
    }

    [TestMethod]
    public void Equals_ReturnsTrueForTwoSameObject_True()
    {
      Venue newVenue = new Venue("Key Arena", 200);
      Venue newVenue2 = new Venue("Key Arena", 200);

      bool result = newVenue.Equals(newVenue2);

      Assert.AreEqual(true, result);
    }

    [TestMethod]
    public void Save_SavesNewVenueToDatabase_Venue()
    {
      Venue newVenue = new Venue("Key Arena", 200);
      newVenue.Save();

      List<Venue> expected = new List<Venue>{newVenue};
      List<Venue> actual = Venue.GetAll();

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void DeleteAll_DeletesAllVenues_Void()
    {
      Venue newVenue = new Venue("Key Arena", 200);
      newVenue.Save();

      Venue.DeleteAll();

      List<Venue> expected = new List<Venue>{};
      List<Venue> actual = Venue.GetAll();

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetAll_GetsAllVenuesFromDatabase_VenueList()
    {
      Venue newVenue = new Venue("Key Arena", 200);
      newVenue.Save();

      List<Venue> expected = new List<Venue>{newVenue};
      List<Venue> actual = Venue.GetAll();

      CollectionAssert.AreEqual(expected, actual);
    }



  }
}
