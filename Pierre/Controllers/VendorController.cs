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
      List<Vendor> vendors = Vendor.GetAll();
      return View(vendors);
    }
    [HttpPost("/vendor")]
    public ActionResult Create(string name, string description)
    {
      new Vendor(name, description);
      List<Vendor> vendors = Vendor.GetAll();
      return RedirectToAction("Index", vendors);
    }
    [HttpGet("/vendor/new")]
    public ActionResult New()
    {
      return View();
    }
    [HttpGet("/vendor/{id}")]
    public ActionResult Details(int id)
    {
      Vendor vendor = Vendor.GetVendorWithId(id);
      return View(vendor);
    }
    [HttpGet("/vendor/{id}/order/new")]
    public ActionResult newOrder(int id)
    {
      Vendor vendor = Vendor.GetVendorWithId(id);
      return View(vendor);
    }
    [HttpPost("/vendor/{id}/order/new")]
    public ActionResult CreateOrder(string title, string description, int price, DateTime orderDate, int vendorId)
    {
      Vendor vendor = Vendor.GetVendorWithId(vendorId);
      vendor.AddOrder(new Order(title, description, price, orderDate, vendor.GetOrderCount(), vendor.Name, vendor.Id));
      return RedirectToAction("Details");
    }
    [HttpGet("/vendor/{id}/order/{oid}")]
    public ActionResult ShowOrder(int id, int oid)
    {
      Vendor vendor = Vendor.GetVendorWithId(id);
      Order order = vendor.GetOrderWithId(oid);
      return View(order);
    }
    [HttpGet("/vendor/{id}/order/{oid}/delete")]
    public ActionResult DeleteOrder(int vendorId, int orderId)
    {
      Vendor vendor = Vendor.GetVendorWithId(vendorId);
      vendor.DeleteOrder(orderId);

      return RedirectToAction("Details");
    }
    [HttpGet("/vendor/{id}/order/deleteAll")]
    public ActionResult DeleteAllOrders(int vendorId)
    {
      Vendor vendor = Vendor.GetVendorWithId(vendorId);
      vendor.DeleteAllOrders(); ;
      return RedirectToAction("Details");
    }


    [HttpGet("/vendor/{id}/delete")]
    public ActionResult DeleteVendor(int id)
    {
      Vendor vendor = Vendor.GetVendorWithId(id);
      vendor.DeleteVendor();
      return RedirectToAction("Index");
    }
    [HttpGet("/vendor/deleteAll")]
    public ActionResult DeleteAllVendors(int id)
    {
      Vendor.ClearAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/vendor/search")]
    public ActionResult Search()
    {

      return View();
    }
    [HttpPost("/vendor/search")]
    public ActionResult SearchVendor(string vendor)
    {
      Vendor vendor1 = Vendor.SearchVendor(vendor);
      //Console.WriteLine(a);
      return View("ShowDetails", vendor1);//, a);
    }


  }

}
