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
    public void GetName_ReturnName_ClientString()
    {
      string name = "Jeffandrew";
      Client newClient = new Client(name);
      string result = newClient.GetName();
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void SetName_SetClientName_ClientString()
    {
      string name = "Jeffandrew";
      Client newClient = new Client(name);
      string updatedName = "Taako";
      newClient.SetName(updatedName);
      string result = newClient.GetName();
      Assert.AreEqual(updatedName, result);
    }

    // [TestMethod]
    // public void GetAll_ReturnsEmptyClientListFromDatabase_ClientList()
    // {
    //   List<Client> newList = new List<Client> { };
    //   List<Client> result = Client.GetAll();
    //   CollectionAssert.AreEqual(newList, result);
    // }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
    {
      Client firstClient = new Client("Jeffandrew");
      Client secondClient = new Client("Jeffandrew");
      Assert.AreEqual(firstClient, secondClient);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ClientList()
    {
      Client testClient = new Client("Jeffandrew");
      testClient.Save();
      List<Client> result = Client.GetAll();
      List<Client> testList = new List<Client>{testClient};
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyClientList_ClientList()
    {
      List<Client> newList = new List<Client> { };
      List<Client> result = Client.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsClients_ClientList()
    {
      string name01 = "Jeffandrew";
      string name02 = "Taako";
      Client newClient1 = new Client(name01);
      newClient1.Save();
      Client newClient2 = new Client(name02);
      newClient2.Save();
      List<Client> newList = new List<Client> { newClient1, newClient2 };
      List<Client> result = Client.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      Client testClient = new Client("Jeffandrew");
      testClient.Save();
      Client savedClient = Client.GetAll()[0];
      int result = savedClient.GetId();
      int testId = testClient.GetId();
      Assert.AreEqual(testId, result);
    }
    //
    // [TestMethod]
    // public void GetId_ClientsInstantiateWithAnIdAndGetterReturns_Int()
    // {
    //   string name = "Jeffandrew";
    //   Client newClient = new Client(name);
    //   int result = newClient.GetId();
    //   Assert.AreEqual(1, result);
    // }
    //
    // [TestMethod]
    // public void Find_ReturnsCorrectClient_Client()
    // {
    //   string name01 = "Jeffandrew";
    //   string name02 = "Taako";
    //   Client newClient1 = new Client(name01);
    //   Client newClient2 = new Client(name02);
    //   Client result = Client.Find(2);
    //   Assert.AreEqual(newClient2, result);
    // }

  }
}
