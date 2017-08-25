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
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=bandtracker_test;";
    }

    public void Dispose()
    {
      Venue.DeleteAll();
    }
