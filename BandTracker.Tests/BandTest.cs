using Microsoft.VisualStudio.TestTools.UnitTesting;
using BandTracker;
using System;
using BandTracker.Models;
using System.Collections.Generic;

namespace BandTracker.Tests
{
  [TestClass]
  public class BandTests : IDisposable
  {

     public BandTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=band_tracker_test;";
    }

    public void Dispose()
    {
      Band.DeleteAll();
    }

    [TestMethod]
    public void Equals_ReturnsTrueForTwoSameObject_True()
    {
      Band newBand = new Band("Green Day", 200);
      Band newBand2 = new Band("Green Day", 200);

      bool result = newBand.Equals(newBand2);

      Assert.AreEqual(true, result);
    }
    [TestMethod]
    public void Save_SavesNewBandToDatabase_Band()
    {
      Band newBand = new Band("Green Day", 200);
      newBand.Save();

      List<Band> expected = new List<Band>{newBand};
      List<Band> actual = Band.GetAll();

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void DeleteAll_DeletesAllBands_Void()
    {
      Band newBand = new Band("Green Day", 200);
      newBand.Save();

      Band.DeleteAll();

      List<Band> expected = new List<Band>{};
      List<Band> actual = Band.GetAll();

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetAll_GetsAllBandsFromDatabase_BandList()
    {
      Band newBand = new Band("Green Day", 200);
      newBand.Save();

      List<Band> expected = new List<Band>{newBand};
      List<Band> actual = Band.GetAll();

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Find_ReturnsSpecificBand_Band()
    {
      Band newBand = new Band("Green Day", 200);
      newBand.Save();
      Band newBand2 = new Band("Linkin Park", 200);
      newBand2.Save();

      Band foundBand = Band.Find(newBand.GetId());

      Band expected = newBand;
      Band actual = foundBand;

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Delete_DeletesSpecificBand_List()
    {
      Band newBand = new Band("Green Day", 200);
      newBand.Save();
      Band newBand2 = new Band("Linkin Park", 200);
      newBand2.Save();

      newBand.Delete();

      List<Band> expected = new List<Band>{newBand2};
      List<Band> actual = Band.GetAll();

      CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Update_UpdateBandDetails_Band()
    {
      Band newBand = new Band("Green Day", 200);
      newBand.Save();

      newBand.Update("Greener Day", 400);

      Band updatedBand = new Band("Greener Day", 400);

      string expected = updatedBand.GetName();
      string actual = Band.Find(newBand.GetId()).GetName();

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AddVenue_AddVenueToBand_Venue()
    {
      Venue newVenue = new Venue("Key Arena", 200);
      newVenue.Save();

      Band newBand = new Band("Green Day", 200);
      newBand.Save();

      newBand.AddVenue(newVenue.GetId());

      List<Venue> expected = new List<Venue>{newVenue};
      List<Venue> actual = newBand.GetVenues();

      CollectionAssert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void GetVenues_GetVenuesForBand_List()
    {
      Venue newVenue = new Venue("Key Arena", 200);
      newVenue.Save();

      Band newBand = new Band("Green Day", 200);
      newBand.Save();

      newBand.AddVenue(newVenue.GetId());

      List<Venue> expected = new List<Venue>{newVenue};
      List<Venue> actual = newBand.GetVenues();

      CollectionAssert.AreEqual(expected, actual);
    }
    // [TestMethod]
    // public void Delete_DeletesBandFromSpecificVenueOnly_Void()
    // {
    //   Band newBand = new Band("Green Day", 200);
    //   newBand.Save();
    //   Venue newVenue = new Venue("Key Arena", 200);
    //   newVenue.Save();
    //   Venue newVenue2 = new Venue("Gorge", 400);
    //   newVenue2.Save();
    //   newBand.AddVenue(newVenue.GetId());
    //   newBand.AddVenue(newVenue2.GetId());
    //
    //   newBand.Delete(newVenue.GetId());
    //
    //   List<Venue> expected = new List<Venue>{newVenue2};
    //   List<Venue> actual = newBand.GetVenues();
    //
    //   CollectionAssert.AreEqual(expected, actual);
    // }

  }
}
