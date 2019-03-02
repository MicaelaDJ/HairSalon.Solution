using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.HomeControllers
{
  public class HomeController : Controller
  {
    [Http("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}
