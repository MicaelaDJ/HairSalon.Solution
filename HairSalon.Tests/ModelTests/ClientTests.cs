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
      Client newClient = new Client("test", 1);
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_ClientString()
    {
      //Arrange
      string name = "Jeffandrew";
      Client newClient = new Client(name, 1);
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
      Client newClient = new Client(name, 1);
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
      Client newClient1 = new Client(name01, 1);
      newClient1.Save();
      Client newClient2 = new Client(name02, 1);
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
      Client testClient = new Client("Jeffandrew", 1);
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
      Client firstClient = new Client("Jeffandrew", 1);
      Client secondClient = new Client("Jeffandrew", 1);
      //Assert
      Assert.AreEqual(firstClient, secondClient);
    }

    [TestMethod]
    public void Save_SavesToDatabase_ClientList()
    {
      //Arrange
      Client testClient = new Client("Jeffandrew", 1);
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
      Client testClient = new Client("Jeffandrew", 1);
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
      Client testClient = new Client("Jeffandrew", 1);
      testClient.Save();
      string secondName = "Taako";
      //Act
      testClient.Edit(secondName);
      string result = Client.Find(testClient.GetId()).GetName();
      //Assert
      Assert.AreEqual(secondName, result);
    }

    // [TestMethod]
    // public void GetStylistId_ReturnsClientsParentStylistId_Int()
    // {
    //   //Arrange
    //   Stylist newStylist = new Stylist("Karri S.");
    //   Client newClient = new Client("Jeffandrew", 1, newStylist.GetId());
    //   //Act
    //   int result = newClient.GetStylistId();
    //   //Assert
    //   Assert.AreEqual(newStylist.GetId(), result);
    // }

  }
}
