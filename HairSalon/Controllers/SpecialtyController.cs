using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class SpecialtiesController : Controller
  {

    [HttpGet("/specialties")]
    public ActionResult Index()
    {
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View(allSpecialties);
    }

    [HttpGet("/specialties/new")]
    public ActionResult New()
    {
       return View();
    }

    [HttpPost("/specialties")]
    public ActionResult Create(string name)
    {
      Specialty newSpecialty = new Specialty(name);
      newSpecialty.Save();
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View("Index", allSpecialties);
    }

    [HttpGet("/specialties/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty selectedSpecialty = Specialty.Find(id);
      List<Stylist> specialtyStylists = selectedSpecialty.GetStylists();
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("specialty", selectedSpecialty);
      model.Add("specialtyStylists", specialtyStylists);
      model.Add("allStylists", allStylists);
      return View(model);
    }

    [HttpPost("/specialties/{specialtyId}/stylists/new")]
    public ActionResult AddStylist(int specialtyId, int stylistId)
    {
      Specialty specialty = Specialty.Find(specialtyId);
      Stylist stylist = Stylist.Find(stylistId);
      specialty.AddStylist(stylist);
      return RedirectToAction("Show", new { id = specialtyId });
    }

    [HttpGet("/specialties/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Specialty specialty = Specialty.Find(id);
      specialty.Delete();
      return RedirectToAction("Index");
    }

    [HttpGet("/specialties/delete")]
    public ActionResult Delete()
    {
      Specialty.DeleteAll();
      // List<Specialty> allSpecialties = Specialty.GetAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/stylists/{stylistId}/specialty/{specialtyId}/edit")]
    public ActionResult Edit(int stylistId, int specialtyId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      model.Add("stylist", stylist);
      Specialty specialty = Specialty.Find(specialtyId);
      model.Add("specialty", specialty);
      return View(model);
    }

    [HttpGet("/specialties/{id}/edit")]
    public ActionResult Edit(int id)
    {
      Specialty newSpecialty = Specialty.Find(id);
      return View(newSpecialty);
    }

    [HttpPost("/specialties/{id}/edit")]
    public ActionResult EditPost(int id, string name)
    {
      Specialty newSpecialty = Specialty.Find(id);
      newSpecialty.Edit(name);
      List<Specialty> allSpecialties = Specialty.GetAll();
      return RedirectToAction("Index");
    }

  }
}
