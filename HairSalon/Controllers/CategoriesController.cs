using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class CategoriesController : Controller
  {

    [HttpGet("/categories")]
    public ActionResult Index()
    {
      List<Category> allCategories = Category.GetAll();
      return View(allCategories);
    }

    [HttpGet("/categories/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/categories")]
    public ActionResult Create(string categoryDetails)
    {
      Category newCategory = new Category(categoryDetails);
      List<Category> allCategories = Category.GetAll();
      return View("Index", allCategories);
    }

    [HttpGet("/categories/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category selectedCategory = Category.Find(id);
      List<Stylist> categoryStylists = selectedCategory.GetStylists();
      model.Add("category", selectedCategory);
      model.Add("stylists", categoryStylists);
      return View(model);
    }

    // This one creates new Stylists within a given Category, not new Categories:
    [HttpPost("/categories/{categoryId}/stylists")]
    public ActionResult Create(int categoryId, string stylistName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category foundCategory = Category.Find(categoryId);
      Stylist newStylist = new Stylist(stylistName);
      foundCategory.AddStylist(newStylist);
      List<Stylist> categoryStylists = foundCategory.GetStylists();
      model.Add("stylists", categoryStylists);
      model.Add("category", foundCategory);
      return View("Show", model);
    }

  }
}
