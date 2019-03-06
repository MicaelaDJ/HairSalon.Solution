using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=micaela_jawor_test;";
    }

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
    public void GetDetails_ReturnsDetails_String()
    {
      //Arrange
      string details = "Test Stylist";
      Stylist newStylist = new Stylist(details);
      //Act
      string result = newStylist.GetDetails();
      //Assert
      Assert.AreEqual(details, result);
    }

   //  [TestMethod]
   //  public void GetId_ReturnsStylistId_Int()
   //  {
   //    //Arrange
   //    string details = "Test Stylist";
   //    Stylist newStylist = new Stylist(details);
   //    //Act
   //    int result = newStylist.GetId();
   //    //Assert
   //    Assert.AreEqual(1, result);
   // }
   //
   // [TestMethod]
   // public void GetAll_ReturnsAllStylistObjects_StylistList()
   // {
   //   //Arrange
   //   string details01 = "Client";
   //   string details02 = "Specialty";
   //   Stylist newStylist1 = new Stylist(details01);
   //   Stylist newStylist2 = new Stylist(details02);
   //   List<Stylist> newList = new List<Stylist> { newStylist1, newStylist2 };
   //   //Act
   //   List<Stylist> result = Stylist.GetAll();
   //   //Assert
   //   CollectionAssert.AreEqual(newList, result);
   // }
   //
   // [TestMethod]
   // public void Find_ReturnsCorrectStylist_Stylist()
   // {
   //   //Arrange
   //   string details01 = "Client";
   //   string details02 = "Specialty";
   //   Stylist newStylist1 = new Stylist(details01);
   //   Stylist newStylist2 = new Stylist(details02);
   //   //Act
   //   Stylist result = Stylist.Find(2);
   //   //Assert
   //   Assert.AreEqual(newStylist2, result);
   // }

   [TestMethod]
   public void GetClients_ReturnsEmptyClientList_ClientList()
   {
     //Arrange
     string details = "Clients";
     Stylist newStylist = new Stylist(details);
     List<Client> newList = new List<Client> { };
     //Act
     List<Client> result = newStylist.GetClients();
     //Assert
     CollectionAssert.AreEqual(newList, result);
   }

   [TestMethod]
   public void AddClient_AssociatesClientWithStylist_ClientList()
   {
     //Arrange
     string name = "Jeffandrew";
     Client newClient = new Client(name, 1);
     List<Client> newList = new List<Client> { newClient };
     string details = "Client";
     Stylist newStylist = new Stylist(details);
     newStylist.AddClient(newClient);
     //Act
     List<Client> result = newStylist.GetClients();
     //Assert
     CollectionAssert.AreEqual(newList, result);
   }

   [TestMethod]
   public void GetAll_StylistsEmptyAtFirst_List()
   {
     //Arrange, Act
     int result = Stylist.GetAll().Count;
     //Assert
     Assert.AreEqual(0, result);
   }

   [TestMethod]
   public void Equals_ReturnsTrueIfDetailsAreTheSame_Stylist()
   {
     //Arrange, Act
     Stylist firstStylist = new Stylist("Karri S.");
     Stylist secondStylist = new Stylist("Karri S.");
     //Assert
     Assert.AreEqual(firstStylist, secondStylist);
   }
 }
}
