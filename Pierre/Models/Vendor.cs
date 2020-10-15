using System;
using System.Collections.Generic;
namespace Pierre.Models
{
  public class Vendor
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public int Id { get; set; }

    private List<Order> _orders = new List<Order> { };

    private static List<Vendor> _instances = new List<Vendor> { };

    public Vendor(string name, string description)
    {
      Name = name;
      Description = description;
      Id = _instances.Count;
      _instances.Add(this);

    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static List<Vendor> GetAll()
    {
      return _instances;
    }
    public static Vendor Find(int searchId)
    {
      return _instances[searchId-1];
    }
    public void AddOrder(Order order)
    {
      _orders.Add(order);
    }
    public List<Order> GetOrders()
    {
      return _orders;
    }
    public int GetOrderCount()
    {
      return _orders.Count;
    }
    public static Vendor GetVendorWithId(int id)
    {
      foreach (Vendor vendor in _instances)
      {
        if (vendor.Id == id)
        {
          return vendor;
        }
      }
      return null;
    }
    // did not add the functionality to Delete vendor or orders
    // public void DeleteVendor()
    // {
    //   _instances.Remove(this);
    // }
    // public void DeleteOrder(int orderId)
    // {
    //   Order orderToBeDeleted = GetOrderWithId(orderId);
    //   _orders.Remove(orderToBeDeleted);
    // }
    // public void DeleteAllOrders()
    // {
    //   _orders.Clear();
    // }
    public Order GetOrderWithId(int id)
    {
      foreach (Order item in _orders)
      {
        if (item.Id == id)
        {
          return item;
        }
      }
      return null;
    }
    public static Vendor SearchVendor(string vendorSearch)
    {
      //List<Record> result = new List<Record>{};
      foreach (Vendor vendor in _instances)
      {
        if (vendor.Name == vendorSearch)
        {
          return vendor;
        }
      }
      return null;
    }
  }
}