using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pierre.Models;

namespace Pierre.Controllers
{
  public class orderController : Controller
  {
    [HttpGet("/vendor/{vendorId}/order/new")]
  public ActionResult New(int vendorId)
  {
    Vendor vendor = Vendor.Find(vendorId);
    return View(vendor);
  }

    [HttpPost("/order/delete")]
    public ActionResult DeleteAll()
    {
      Order.ClearAll();
      return View();
    }
    [HttpGet("/vendor/{vendorId}/order/{orderId}")]
    public ActionResult Show(int vendorId, int orderId)
    {
      Order order = Order.Find(orderId);
      Vendor vendor = Vendor.Find(vendorId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("order", order);
      model.Add("vendor", vendor);
      return View(model);
    }


  }
}