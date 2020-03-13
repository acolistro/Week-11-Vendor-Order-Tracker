using System;
using System.Collections.Generic;

namespace Vendor.Models
{
  public class Order
  {
    private static List<Order> _instances = new List<Order> {};
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public List<Order> Orders { get; set; }
  }
}