using System;
using System.Collections.Generic;
namespace Pierre.Models
{
  public class Vendor
  {
        public string Name  {get;set;}
        public string Description {get;set;}
        public int Id {get;set;}

        private List<Order> orders = new List<Order>{};

        private static List<Vendor> _instances = new List<Vendor>{};

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
      return _instances[searchId - 1];
    }
    public void AddOrder(Order order)
    {
      orders.Add(order);
    }
    public List<Order>GetOrders(){
        return orders;
    }

    public int getOrderCount()
    {
        return orders.Count;
    }
    public static Vendor getVendorWithId(int id)
    {
      foreach(Vendor vendor in _instances)
      {
        if(vendor.Id == id)
        {
          return vendor;
        }
      }
      return null;
    }
     public void deleteVendor()
        {
            _instances.Remove(this);
        }
         public void deleteOrder(int orderId)
        {
            Order orderToBeDeleted = getOrderWithId(orderId);
            orders.Remove(orderToBeDeleted);
        }
        public void deleteAllOrders()
        {
            orders.Clear();
        }
         public Order getOrderWithId(int id)
        {
            foreach (Order item in orders)
            {
                if(item.Id == id)
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
          if(vendor.Name == vendorSearch)
          {
            return vendor;
          }
      }
      return null;
    }

    
  }
}