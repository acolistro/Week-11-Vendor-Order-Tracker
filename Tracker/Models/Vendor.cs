using System;
using System.Collections.Generic;

namespace Tracker.Models
{
  public class Vendor
  {
    private static List<Vendor> _instances = new List<Vendor> {};
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public int Id { get; }
    public List<Order> Orders { get; set; }
    private static int _count = 0;

    public Vendor(string name, string description, string address)
    {
      Name = name;
      Description = description;
      Address = address;
      _instances.Add(this);
      Id = _count++;
      Orders = new List<Order> { };
    }

    public static List<Vendor> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _count = 0;
      _instances.Clear();
    }

    public static Vendor Find(int id)
    {
      foreach (Vendor vendor in _instances)
      {
        if (vendor.Id == id)
        {
          return vendor;
        }
      }
      return _instances[0];
    }
  }
}