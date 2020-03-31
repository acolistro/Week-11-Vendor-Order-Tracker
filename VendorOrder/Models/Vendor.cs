using System;
using System.Collections.Generic;

namespace VendorOrder.Models
{
  public class Vendor
  {
    private static List<Vendor> _instances = new List<Vendor> {};
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public int Id { get; }
    public List<Order> Orders { get; set; }


    public Vendor(string name, string description, string address)
    {
      Name = name;
      Description = description;
      Address = address;
      _instances.Add(this);
      Id = _instances.Count;
      Orders = new List<Order> { };
    }

    public static List<Vendor> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Vendor Find(int id)
    {
      return _instances[id];
    }


    public static void AddOrder(int id, Order newOrder)
    {
      Vendor vendor = Find(id);
      vendor.Orders.Add(newOrder);
    }

    public static List<Order> GetOrdersList(int id)
    {
      Vendor vendor = Find(id);
      List<Order> newOrderList = vendor.Orders;
      return newOrderList;
    }

    public static Order GetOrder(int vendorId, int OrderId)
    {
      List<Order> orderList = GetOrdersList(vendorId);
      Order result = orderList[0];
      foreach (var item in orderList)
      {
        if (OrderId == item.Id)
        {
          return item;
        }
      }
      return result;
    }
  }
}