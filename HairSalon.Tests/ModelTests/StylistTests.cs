using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {

    public void Dispose()
    {
      Stylist.ClearAll();
    }

    [TestMethod]
    public void StylistConstructor_CreatesInstanceOfStylist_Stylist()
    {
      Stylist newStylist = new Stylist("test stylist");
      Assert.AreEqual(typeof(Stylist), newStylist.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsDetails_String()
    {
      string details = "Test Stylist";
      Stylist newStylist = new Stylist(details);
      string result = newStylist.GetDetails();
      Assert.AreEqual(details, result);
    }

    [TestMethod]
    public void GetId_ReturnsStylistId_Int()
    {
      string details = "Test Stylist";
      Stylist newStylist = new Stylist(details);
      int result = newStylist.GetId();
      Assert.AreEqual(1, result);
   }

   [TestMethod]
   public void GetAll_ReturnsAllStylistObjects_StylistList()
   {
     string details01 = "Client";
     string details02 = "Specialty";
     Stylist newStylist1 = new Stylist(details01);
     Stylist newStylist2 = new Stylist(details02);
     List<Stylist> newList = new List<Stylist> { newStylist1, newStylist2 };
     List<Stylist> result = Stylist.GetAll();
     CollectionAssert.AreEqual(newList, result);
   }

   [TestMethod]
   public void Find_ReturnsCorrectStylist_Stylist()
   {
     string details01 = "Angus";
     string details02 = "Merle";
     Stylist newStylist1 = new Stylist(details01);
     Stylist newStylist2 = new Stylist(details02);
     Stylist result = Stylist.Find(2);
     Assert.AreEqual(newStylist2, result);
   }

   [TestMethod]
   public void GetClients_ReturnsEmptyClientList_ClientList()
   {
     string details = "Angus";
     Stylist newStylist = new Stylist(details);
     List<Client> newList = new List<Client> { };
     List<Client> result = newStylist.GetClients();
     CollectionAssert.AreEqual(newList, result);
   }

   [TestMethod]
   public void AddClient_AssociatesClientWithStylist_ClientList()
   {
     string name = "Jeffandrew";
     Client newClient = new Client(name);
     List<Client> newList = new List<Client> { newClient };
     string details = "Client";
     Stylist newStylist = new Stylist(details);
     newStylist.AddClient(newClient);
     List<Client> result = newStylist.GetClients();
     CollectionAssert.AreEqual(newList, result);
   }
 }
}
