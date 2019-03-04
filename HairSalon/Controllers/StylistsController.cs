using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {

    [HttpGet("/categories/{categoryId}/stylists/new")]
    public ActionResult New(int categoryId)
    {
       Category category = Category.Find(categoryId);
       return View(category);
    }

    [HttpGet("/categories/{categoryId}/stylists/{stylistId}")]
    public ActionResult Show(int categoryId, int stylistId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category category = Category.Find(categoryId);
      model.Add("stylist", stylist);
      model.Add("category", category);
      return View(model);
    }

    [HttpPost("/stylists/delete")]
    public ActionResult DeleteAll()
    {
      Stylist.ClearAll();
      return View();
    }

  }
}
