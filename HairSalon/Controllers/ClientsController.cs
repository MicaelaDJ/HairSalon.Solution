using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {

    [HttpGet("/clients")]
    public ActionResult Index()
    {
      List<Client> allClients = Client.GetAll();
      return View(allClients);
    }

    [HttpGet("/clients/new")]
    public ActionResult New()
    {
       return View();
    }

    [HttpPost("/clients")]
    public ActionResult Create(string name)
    {
      Client newClient = new Client(name);
      newClient.Save();
      List<Client> allClients = Client.GetAll();
      return View("Index", allClients);
    }

    [HttpGet("/clients/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Client selectedClient = Client.Find(id);
      List<Stylist> clientStylists = selectedClient.GetStylists();
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("client", selectedClient);
      model.Add("clientStylists", clientStylists);
      model.Add("allStylists", allStylists);
      return View(model);
    }

    [HttpPost("/clients/{clientId}/stylists/new")]
    public ActionResult AddStylist(int clientId, int stylistId)
    {
      Client client = Client.Find(clientId);
      Stylist stylist = Stylist.Find(stylistId);
      client.AddStylist(stylist);
      return RedirectToAction("Show", new { id = clientId });
    }

    [HttpGet("/clients/{id}/delete")]
    public ActionResult Delete(int id)
    {
      Client client = Client.Find(id);
      client.Delete();
      return RedirectToAction("Index");
    }

    [HttpGet("/clients/delete")]
    public ActionResult Delete()
    {
      Client.DeleteAll();
      // List<Client> allClients = Client.GetAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/stylists/{stylistId}/client/{clientId}/edit")]
    public ActionResult Edit(int stylistId, int clientId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      model.Add("stylist", stylist);
      Client client = Client.Find(clientId);
      model.Add("client", client);
      return View(model);
    }

    [HttpGet("/clients/{id}/edit")]
    public ActionResult Edit(int id)
    {
      Client newClient = Client.Find(id);
      return View(newClient);
    }

    [HttpPost("/clients/{id}/edit")]
    public ActionResult EditPost(int id, string name)
    {
      Client newClient = Client.Find(id);
      newClient.Edit(name);
      List<Client> allClients = Client.GetAll();
      return RedirectToAction("Index");
    }

  }
}
