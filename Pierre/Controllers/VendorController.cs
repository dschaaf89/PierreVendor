using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pierre.Models;

namespace Pierre.Controllers
{
  public class VendorController : Controller
  {
    [HttpGet("/vendor")]
    public ActionResult Index()
    {
      List<Vendor> allVendor = Vendor.GetAll();
      return View(allVendor);
    }
    [HttpGet("/vendor/new")]
    public ActionResult New()
    {
      return View();
    }
    [HttpPost("/vendor")]
    public ActionResult create(string vendor, string description)
    {
      Vendor newVendor = new Vendor(vendor, description);
      return RedirectToAction("Index");
    }
    [HttpGet("/vendor/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(id);
      List<Order> vendorOrder = selectedVendor.Order;
      model.Add("vendor", selectedVendor);
      model.Add("order", vendorOrder);
      // return View (model);
      return View(selectedVendor);
    }
    [HttpGet("/vendor/search")]
    public ActionResult Search()
    {
      return View();
    }
    [HttpPost("/artist/search")]
    public ActionResult SearchVendor(string vendor)
    {
      Vendor searchedVendor = Vendor.SearchVendor(vendor);
      //Console.WriteLine(a);
      return View("Show", searchedVendor);//, a);
    }


  }
}