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
    vendor vendor = vendor.Find(vendorId);
    return View(vendor);
  }
  // [HttpPost("/vendor/{vendorId}/order")]///vendors/@Model.Id/order
  // public ActionResult Create(string vendorName, string orderTitle, string songs)
  // {
  //   string[] songArr = songs.Split(' ');
  //   List<string> songList = new List<string>{};
  //   foreach (string item in songArr)
  //   {
  //       songList.Add(item);
  //   }

  //   order r = new order(orderTitle,vendorName,songList);
    
  //   return RedirectToAction("Index");
  // }

  [HttpGet ("/vendor/{vendorId}/order/{orderId}")]
  public ActionResult Show(int vendorId, int orderId)
  {
    order order = order.Find(orderId);
    vendor vendor = vendor.Find(vendorId);
    Dictionary<string, object> model = new Dictionary<string, object> ();
    model.Add ("order", order);
    model.Add ("vendor", vendor);
    return View (model);  
  }

  [HttpPost ("/orders/delete")]
        public ActionResult DeleteAll () {
            order.ClearAll ();
            return View ();
        }

  }
}