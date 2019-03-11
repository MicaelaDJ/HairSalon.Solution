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

    [HttpGet("/clients/{clientId}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Client selectedClient = Client.Find(id);
      List<Stylist> clientStylists = selectedClient.GetStylists();
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("selectedClient", selectedClient);
      model.Add("clientStylists", clientStylists);
      model.Add("allStylists", allStylists);
      return View(model);
    }

    // [HttpPost("/clients/delete")]
    // public ActionResult DeleteAll()
    // {
    //   Stylist.ClearAll();
    //   return View();
    // }
    //
    // [HttpGet("/stylists/{stylistId}/client/{clientId}/edit")]
    // public ActionResult Edit(int stylistId, int clientId)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Stylist stylist = Stylist.Find(stylistId);
    //   model.Add("stylist", stylist);
    //   Client client = Client.Find(clientId);
    //   model.Add("client", client);
    //   return View(model);
    // }
    //
    // [HttpPost("/stylists/{stylistId}/clients/{clientId}")]
    // public ActionResult Update(int stylistId, int clientId, string newName)
    // {
    //   Client client = Client.Find(clientId);
    //   client.Edit(newName);
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Stylist stylist = Stylist.Find(stylistId);
    //   model.Add("stylist", stylist);
    //   model.Add("client", client);
    //   return View ("Show", model);
    // }

  }
}
