using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VendorOrder.Models;

namespace VendorOrder.Controllers
{
  public class VendorsController : Controller
  {
    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string name, string description, string address)
    {
      Vendor newVendor = new Vendor(name, description, address);
      return RedirectToAction("Index");
    }

    [HttpGet("vendors/{id}")]
    public ActionResult show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(id);
      List<Order> vendorOrders = selectedVendor.Orders;
      model.Add("vendor", selectedVendor);
      model.Add("orders", vendorOrders);
      return View(model);
    }

    // [HttpPost("/vendors/{vendorId}/orders")]
    // public ActionResult Create(int vendorId,)
  }
}    