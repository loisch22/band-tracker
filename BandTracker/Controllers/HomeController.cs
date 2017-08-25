using Microsoft.AspNetCore.Mvc;
using BandTracker.Models;
using System.Collections.Generic;
using System;

namespace BandTracker.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
    [HttpGet("/view/venues")]
    public ActionResult Venues()
    {
      return View(Venue.GetAll());
    }
    [HttpPost("/view/venues")]
    public ActionResult VenuesPost()
    {
      return View("Venues", Venue.GetAll());
    }
    [HttpGet("/venue/detail/{venueId}")]
    public ActionResult VenueDetails(int venueId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>{};

      Venue foundVenue = Venue.Find(venueId);
      model.Add("venue", foundVenue);

      List<Band> foundBands = foundVenue.GetBands();
      model.Add("bands", foundBands);

      return View(model);
    }
    [HttpPost("/venue/detail/{venueId}")]
    public ActionResult VenueDetailsPost(int venueId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>{};

      Venue foundVenue = Venue.Find(venueId);
      model.Add("venue", foundVenue);

      Band newBand = new Band(Request.Form["band-name"], int.Parse(Request.Form["band-price"]));
      newBand.Save();

      foundVenue.AddBand(newBand.GetId());

      List<Band> foundBands = foundVenue.GetBands();
      model.Add("bands", foundBands);

      return View("VenueDetails", model);
    }
    [HttpGet("/venue/form")]
    public ActionResult VenueForm()
    {
      return View();
    }
    [HttpPost("/venue/success")]
    public ActionResult VenueSuccess()
    {
        Venue newVenue = new Venue(Request.Form["name"], int.Parse(Request.Form["price"]));
        newVenue.Save();

        return View(newVenue);
    }
    [HttpGet("/view/bands")]
    public ActionResult Bands()
    {
      return View(Band.GetAll());
    }
    [HttpPost("/view/bands")]
    public ActionResult BandsPost()
    {
      return View("Bands", Band.GetAll());
    }
    [HttpGet("/band/detail/{bandId}")]
    public ActionResult BandDetails(int bandId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>{};

      Band foundBand = Band.Find(bandId);
      model.Add("band", foundBand);

      List<Venue> foundVenues = foundBand.GetVenues();
      model.Add("venues", foundVenues);

      return View(model);
    }
    [HttpPost("/band/detail/{bandId}")]
    public ActionResult BandDetailsPost(int bandId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>{};

      Band foundBand = Band.Find(bandId);
      model.Add("band", foundBand);

      Venue newVenue = new Venue(Request.Form["venue-name"], int.Parse(Request.Form["venue-price"]));
      newVenue.Save();

      foundBand.AddVenue(newVenue.GetId());

      List<Venue> foundVenues = foundBand.GetVenues();
      model.Add("venues", foundVenues);

      return View("BandDetails", model);
    }
    [HttpGet("/band/form")]
    public ActionResult BandForm()
    {
      return View();
    }
    [HttpPost("/band/success")]
    public ActionResult BandSuccess()
    {
      Band newBand = new Band(Request.Form["name"], int.Parse(Request.Form["price"]));
      newBand.Save();

      return View(newBand);
    }

  }
}
