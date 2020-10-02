using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pierre.Models;

namespace Pierre.Controllers
{
  public class VendorController : Controller {
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
      Vendor newVendor = new Vendor(vendor,description);
      return RedirectToAction("Index");
    }
    
}
}