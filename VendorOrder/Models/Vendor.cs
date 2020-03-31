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


    public Vendor(string vendorName, string description, string address)
    {
      Name = vendorName;
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
      foreach (Vendor vendor in _instances)
      {
        if (vendor.Id == id)
        {
          return vendor;
        }
      }
      return _instances[0];
    }

    public static void Update(int id, string vendorName, string description, string address)
    {
      Vendor result = Find(id);
      result.Name = vendorName;
      result.Description = description;
      result.Address = address;
    }

    public static void Delete(int id)
    {
      Vendor toRemove = Find(id);
      _instances.Remove(toRemove);
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

    public static void UpdateOrder(int vendorId, int orderId, string product, int quantity)
    {
      Order order = GetOrder(vendorId, orderId);
      order.Product = product;
      order.Quantity = quantity;
    }
  }
}