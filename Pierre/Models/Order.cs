using System;
using System.Collections.Generic;

namespace Pierre.Models
{
public class Order
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Id { get; }
    public DateTime Date { get; set; }
    public string VendorName { get; set; }
    public int VendorId { get; set; }
    private static List<Order> _instances = new List<Order> { };

    public Order(string title, string description, int price, DateTime date, int id, string vendorName, int vendorId)
    {
        Title = title;
        Description = description;
        Price = price;
        Date = date;
        _instances.Add(this);
        Id = _instances.Count;
        VendorName = vendorName;
        VendorId = vendorId;
    }
    public static List<Order> GetAll()
    {
        return _instances;
    }

    public static void ClearAll()
    {
        _instances.Clear();
    }
    public static Order Find(int searchId)
    {
        return _instances[searchId - 1];
    }

}
}
