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

      List<Band> allBands = Band.GetAll();
      model.Add("allBands", allBands);

      return View(model);
    }
    [HttpPost("/venue/detail/{venueId}")]
    public ActionResult VenueDetailsPost(int venueId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>{};

      Venue foundVenue = Venue.Find(venueId);
      model.Add("venue", foundVenue);

      List<Band> foundBands = foundVenue.GetBands();
      model.Add("bands", foundBands);

      List<Band> allBands = Band.GetAll();
      model.Add("allBands", allBands);

      return View("VenueDetails", model);
    }
    [HttpPost("/add/band/venue/{venueId}")]
    public ActionResult AddBand(int venueId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>{};

      Venue foundVenue = Venue.Find(venueId);
      int bandId = int.Parse(Request.Form["band"]);
      foundVenue.AddBand(bandId);
      model.Add("venue", foundVenue);

      List<Band> foundBands = foundVenue.GetBands();
      model.Add("bands", foundBands);

      List<Band> allBands = Band.GetAll();
      model.Add("allBands", allBands);

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

      List<Venue> allVenues = Venue.GetAll();
      model.Add("allVenues", allVenues);

      return View(model);
    }
    [HttpPost("/band/detail/{bandId}")]
    public ActionResult BandDetailsPost(int bandId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>{};

      Band foundBand = Band.Find(bandId);
      model.Add("band", foundBand);

      List<Venue> foundVenues = foundBand.GetVenues();
      model.Add("venues", foundVenues);

      List<Venue> allVenues = Venue.GetAll();
      model.Add("allVenues", allVenues);

      return View("BandDetails", model);
    }
    [HttpPost("/add/venue/band/{bandId}")]
    public ActionResult AddVenue(int bandId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>{};

      Band foundBand = Band.Find(bandId);
      int venueId = int.Parse(Request.Form["venue"]);
      foundBand.AddVenue(venueId);
      model.Add("band", foundBand);

      List<Venue> foundVenues = foundBand.GetVenues();
      model.Add("venues", foundVenues);

      List<Venue> allVenues = Venue.GetAll();
      model.Add("allVenues", allVenues);

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
    [HttpGet("/venue/update/{venueId}")]
    public ActionResult UpdateVenue(int venueId)
    {
      Venue foundVenue = Venue.Find(venueId);

      return View(foundVenue);
    }
    [HttpPost("/venue/update/{venueId}/success")]
    public ActionResult UpdateVenueSuccess(int venueId)
    {
      Venue foundVenue = Venue.Find(venueId);
      foundVenue.Update(Request.Form["name"], int.Parse(Request.Form["price"]));
      Venue updatedVenue = Venue.Find(foundVenue.GetId());
      return View(updatedVenue);
    }
    [HttpGet("/band/update/{bandId}")]
    public ActionResult UpdateBand(int bandId)
    {
      Band foundBand = Band.Find(bandId);

      return View(foundBand);
    }
    [HttpPost("/band/update/{bandId}/success")]
    public ActionResult UpdateBandSuccess(int bandId)
    {
      Band foundBand = Band.Find(bandId);
      foundBand.Update(Request.Form["name"], int.Parse(Request.Form["price"]));
      Band updatedBand = Band.Find(foundBand.GetId());
      return View(updatedBand);
    }
    [HttpGet("/venue/delete/{venueId}")]
    public ActionResult DeleteVenue(int venueId)
    {
      Venue foundVenue = Venue.Find(venueId);
      foundVenue.Delete();

      return View(foundVenue);
    }
    [HttpGet("/band/delete/{bandId}")]
    public ActionResult DeleteBand(int bandId)
    {
      Band foundBand = Band.Find(bandId);
      foundBand.Delete();

      return View(foundBand);
    }
  }
}
