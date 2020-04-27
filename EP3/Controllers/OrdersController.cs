using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EP3.Data;
using EP3.Models;
using Microsoft.AspNetCore.Mvc;

namespace EP3.Controllers
{
  public class OrdersController : Controller
  {
    private readonly AppDb db;

    public OrdersController(AppDb db) => this.db = db;

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Details(int id)
    {
      var o = db.Orders.Find(id);
      return View(o);
    }

    [HttpGet("[controller]/Create/{customerId}")]
    public IActionResult Create(int customerId)
    {
      var c = db.Customers.Find(customerId);
      ViewBag.Customer = c;
      return View();
    }

    [HttpPost("[controller]/Create/{customerId}")]
    public async Task<IActionResult> CreateAsync(int customerId)
    {
      var c = await db.Customers.FindAsync(customerId);
      var o = new Order();

      //o.Customer = c;
      c.Orders.Add(o);

      await db.SaveChangesAsync(); // implicitly transactional

      return RedirectToAction(nameof(Details), new { o.Id });
    }
  }
}