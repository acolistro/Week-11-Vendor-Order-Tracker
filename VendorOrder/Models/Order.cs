using System;
using System.Collections.Generic;

namespace VendorOrder.Models
{
  public class Order
  {
    private static List<Order> _instances = new List<Order> {};
    public string Product { get; set; }
    public int Quantity { get; set; }
    public int Id { get; }
    public static int IdCounter = 0;
  
    public Order(string product, int quantity)
    {
      Product = product;
      Quantity = quantity;
      _instances.Add(this);
      Id = IdCounter++;
    }

    public static List<Order> GetAll()
    {
      return _instances;
    }

    public static Order Find(int searchId)
    {
      return _instances[searchId];
    }
  }
}