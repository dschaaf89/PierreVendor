using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pierre.Models;

namespace Pierre.Controllers
{
  public class VendorController : Controller
  {
    [HttpGet ("/vendor")]
        public ActionResult Index () {
            List<Vendor> allvendor = Vendor.GetAll ();
            return View (allvendor);
        }

        [HttpGet ("/vendor/new")]
        public ActionResult New () {
            return View ();
        }

        [HttpPost ("/vendor")]
        public ActionResult Create (string vendorName,string description) {
            Vendor newVendor = new Vendor (vendorName,description);
            return RedirectToAction ("Index");
        }

        [HttpGet ("/vendor/{id}")]
        public ActionResult Show (int id) {
            Dictionary<string, object> model = new Dictionary<string, object> ();
            Vendor selectedVendor = Vendor.Find (id);
            List<Order> vendorOrder = selectedVendor.Order;
            model.Add ("Vendor", selectedVendor);
            model.Add ("Order", vendorOrder);
            return View (model);
        }

        // This one creates new orders within a given Vendor, not new vendor:
        [HttpPost ("/vendor/{VendorId}/orders")]
        public ActionResult Create (int VendorId, string title ,string orderDescription, int price) {
            Dictionary<string, object> model = new Dictionary<string, object> ();
            Vendor foundVendor = Vendor.Find (VendorId);
            Order newOrder = new Order (title,orderDescription,price);
            foundVendor.AddOrder (newOrder);
            List<Order> VendorOrder = foundVendor.Order;
            model.Add ("orders", VendorOrder);
            model.Add ("vendor", foundVendor);
            return View ("Show", model);
        }
    [HttpGet("/vendor/search")]
    public ActionResult Search()
    {
      return View();
    }
    [HttpPost("/vendor/search")]
    public ActionResult SearchVendor(string vendor)
    {
      Vendor searchedVendor = Vendor.SearchVendor(vendor);
      //Console.WriteLine(a);
      return View("Show", searchedVendor);//, a);
    }


  }
}