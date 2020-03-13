using System;
using System.Collections.Generic;

namespace Tracker.Models
{
  public class Order
  {
    private static List<Order> _instances = new List<Order> {};
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Id { get; }
    public List<Order> Orders { get; set; }
  
    public Order(string title, string description, int price)
    {
      Title = title;
      Description = description;
      Price = price;
      _instances.Add(this);
      Id = _count++;
    }

    public static List<Order> GetAll()
    {
      return _instances;
    }

    public static void ResetAll()
    {
      _count = 0;
      _instances.Clear();
    }

    public static Order Find(int id)
    {
      foreach (Order order in _instances)
      {
        if (order.Id == id)
        {
          return order;
        }
      }
      return _instances[0];
    }

    public static void Update(int id, string title, string description, int price)
    {
      Order result = Find(id);
      result.Title = title;
      result.Description = description;
      result.Price = price;
    }

    public static void Delete(int id)
    {
      Order toRemove = Find(id);
      _instances.Remove(toRemove);
    }
  }
}