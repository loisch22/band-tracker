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

    [TestMethod]
    public void Find_ReturnsSpecificVenue_Venue()
    {
      Venue newVenue = new Venue("Key Arena", 200);
      newVenue.Save();
      Venue newVenue2 = new Venue("Gorge", 200);
      newVenue2.Save();

      Venue foundVenue = Venue.Find(newVenue.GetId());

      Venue expected = newVenue;
      Venue actual = foundVenue;

      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void Delete_DeletesSpecificVenue_List()
    {
      Venue newVenue = new Venue("Key Arena", 200);
      newVenue.Save();
      Venue newVenue2 = new Venue("Gorge", 200);
      newVenue2.Save();

      newVenue.Delete();

      List<Venue> expected = new List<Venue>{newVenue2};
      List<Venue> actual = Venue.GetAll();

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Update_UpdateVenueDetails_Venue()
    {
      Venue newVenue = new Venue("Key Arena", 200);
      newVenue.Save();

      newVenue.Update("Tacoma Dome", 400);

      Venue updatedVenue = new Venue("Tacoma Dome", 400);

      string expected = updatedVenue.GetName();
      string actual = Venue.Find(newVenue.GetId()).GetName();

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AddBand_AddBandToVenue_Band()
    {
      Venue newVenue = new Venue("Key Arena", 200);
      newVenue.Save();

      Band newBand = new Band("Green Day", 200);
      newBand.Save();

      newVenue.AddBand(newBand.GetId());

      List<Band> expected = new List<Band>{newBand};
      List<Band> actual = newVenue.GetBands();

      CollectionAssert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void GetBands_GetBandsForVenue_List()
    {
      Venue newVenue = new Venue("Key Arena", 200);
      newVenue.Save();

      Band newBand = new Band("Green Day", 200);
      newBand.Save();

      newVenue.AddBand(newBand.GetId());

      List<Band> expected = new List<Band>{newBand};
      List<Band> actual = newVenue.GetBands();

      CollectionAssert.AreEqual(expected, actual);
    }
  }
}
