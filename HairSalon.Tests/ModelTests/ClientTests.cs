using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {

    public void Dispose()
    {
      Client.ClearAll();
      Stylist.ClearAll();
    }

    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=micaela_jawor_test;";
    }

    [TestMethod]
    public void ClientConstructor_CreatesInstanceOfClient_Client()
    {
      Client newClient = new Client("test");
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_ClientString()
    {
      //Arrange
      string name = "Jeffandrew";
      Client newClient = new Client(name);
      //Act
      string result = newClient.GetName();
      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void SetName_SetClientName_ClientString()
    {
      //Arrange
      string name = "Jeffandrew";
      Client newClient = new Client(name);
      //Act
      string updatedName = "Taako";
      newClient.SetName(updatedName);
      string result = newClient.GetName();
      //Assert
      Assert.AreEqual(updatedName, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyClientList_ClientList()
    {
      //Arrange
      List<Client> newList = new List<Client> { };
      //Act
      List<Client> result = Client.GetAll();
      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsClients_ClientList()
    {
      //Arrange
      string name01 = "Jeffandrew";
      string name02 = "Taako";
      Client newClient1 = new Client(name01);
      newClient1.Save();
      Client newClient2 = new Client(name02);
      newClient2.Save();
      List<Client> newList = new List<Client> { newClient1, newClient2 };
      //Act
      List<Client> result = Client.GetAll();
      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectClientFromDatabase_Client()
    {
      //Arrange
      Client testClient = new Client("Jeffandrew");
      testClient.Save();
      //Act
      Client foundClient = Client.Find(testClient.GetId());
      //Assert
      Assert.AreEqual(testClient, foundClient);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
    {
      //Arrange, Act
      Client firstClient = new Client("Jeffandrew");
      Client secondClient = new Client("Jeffandrew");
      //Assert
      Assert.AreEqual(firstClient, secondClient);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ClientList()
    {
      //Arrange
      Client testClient = new Client("Jeffandrew");
      //Act
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};
      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Client testClient = new Client("Jeffandrew");
      //Act
      testClient.Save();
      Client savedClient = Client.GetAll()[0];

      int result = savedClient.GetId();
      int testId = testClient.GetId();
      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Edit_UpdatesClientInDatabase_String()
    {
      //Arrange
      Client testClient = new Client("Jeffandrew");
      testClient.Save();
      string secondName = "Taako";
      //Act
      testClient.Edit(secondName);
      string result = Client.Find(testClient.GetId()).GetName();
      //Assert
      Assert.AreEqual(secondName, result);
    }

    [TestMethod]
    public void GetStylists_ReturnsAllClientStylists_StylistList()
    {
      //Arrange
      Client testClient = new Client("Jeffandrew");
      testClient.Save();
      Stylist testStylist1 = new Stylist("Karri S.");
      testStylist1.Save();
      Stylist testStylist2 = new Stylist("Barry B.");
      testStylist2.Save();
      //Act
      testClient.AddStylist(testStylist1);
      List<Stylist> result = testClient.GetStylists();
      List<Stylist> testList = new List<Stylist> {testStylist1};
      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void AddStylist_AddStylistToClient_StylistList()
    {
      //Arrange
      Client testClient = new Client("Jeffandrew");
      testClient.Save();
      Stylist testStylist = new Stylist("Karri S.");
      testStylist.Save();
      //Act
      testClient.AddStylist(testStylist);

      List<Stylist> result = testClient.GetStylists();
      List<Stylist> testList = new List<Stylist>{testStylist};
      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Delete_DeletesClientAssociationsFromDatabase_ClientList()
    {
      //Arrange
      Stylist testStylist = new Stylist("Jeffandrew");
      testStylist.Save();
      string testName = "Jeffandrew";
      Client testClient = new Client(testName);
      testClient.Save();
      //Act
      testClient.AddStylist(testStylist);
      testClient.Delete();
      List<Client> resultStylistClients = testStylist.GetClients();
      List<Client> testStylistClients = new List<Client> {};
      //Assert
      CollectionAssert.AreEqual(testStylistClients, resultStylistClients);
    }

  }
}
