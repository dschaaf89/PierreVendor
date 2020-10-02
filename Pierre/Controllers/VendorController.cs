using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
  public class ArtistController : Controller {
    [HttpGet("/artist")]
    public ActionResult Index()
    {
      List<Artist> allArtist = Artist.GetAll();
      return View(allArtist);
    }
    
    [HttpGet("/artist/new")]
    public ActionResult New(){
      return View();
    }

    [HttpPost("/artist")]
    public ActionResult Create(string artist){
      Artist newArtist = new Artist(artist);
      return RedirectToAction("Index");
    }
[HttpGet ("/artist/{id}")]
        public ActionResult Show (int id) {
            Dictionary<string, object> model = new Dictionary<string, object> ();
            Artist selectedArtist = Artist.Find (id);
            List<Record> artistRecords = selectedArtist.Record;
            model.Add ("artist", selectedArtist);
            model.Add ("record", artistRecords);
            // return View (model);
            return View(selectedArtist);
        }
  // [HttpPost("/artist/{artistId}/record")]
  // public ActionResult Create (string title,string artist, List<string> songs, int artistId)
  // {
  // Dictionary<string, object> model = new Dictionary<string, object> (); 
  // Artist foundArtist = Artist.Find(artistId);
  // Record newRecord = new Record(title,artist,songs);
  // foundArtist.AddRecord (newRecord);
  // List<Record> artistRecords = foundArtist.Record;
  // model.Add("record", artistRecords);
  // model.Add("artist",foundArtist);
  // return View("Show",model);  
  // }
  [HttpPost("/artist/{artistId}/record")]///artists/@Model.Id/record
  public ActionResult Create(string artistName, string recordTitle, string songs, int artistId)
  {
    string[] songArr = songs.Split(' ');
    List<string> songList = new List<string>{};
    foreach (string item in songArr)
    {
        songList.Add(item);
    }

    Record r = new Record(recordTitle,artistName,songList);
    Artist foundArtist = Artist.Find(artistId);
    foundArtist.AddRecord (r);
    
    return View("Show",foundArtist);
    //return RedirectToAction("Index");
  }
  [HttpGet ("/artist/search")]
        public ActionResult Search () {
            
            return View();
        }

  
  [HttpPost ("/artist/search")]
        public ActionResult SearchArtist (string artist) {
           Artist a = Artist.SearchArtist(artist);
            //Console.WriteLine(a);
            return View("Show",a );//, a);
        }

  }
}