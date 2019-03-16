using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtyTest : IDisposable
  {

    public void Dispose()
    {
      Specialty.ClearAll();
      Stylist.ClearAll();
    }

    public SpecialtyTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=micaela_jawor_test;";
    }

    [TestMethod]
    public void SpecialtyConstructor_CreatesInstanceOfSpecialty_Specialty()
    {
      Specialty newSpecialty = new Specialty("test");
      Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_SpecialtyString()
    {
      //Arrange
      string name = "Jeffandrew";
      Specialty newSpecialty = new Specialty(name);
      //Act
      string result = newSpecialty.GetName();
      //Assert
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void SetName_SetSpecialtyName_SpecialtyString()
    {
      //Arrange
      string name = "Jeffandrew";
      Specialty newSpecialty = new Specialty(name);
      //Act
      string updatedName = "Taako";
      newSpecialty.SetName(updatedName);
      string result = newSpecialty.GetName();
      //Assert
      Assert.AreEqual(updatedName, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptySpecialtyList_SpecialtyList()
    {
      //Arrange
      List<Specialty> newList = new List<Specialty> { };
      //Act
      List<Specialty> result = Specialty.GetAll();
      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsSpecialties_SpecialtyList()
    {
      //Arrange
      string name01 = "Jeffandrew";
      string name02 = "Taako";
      Specialty newSpecialty1 = new Specialty(name01);
      newSpecialty1.Save();
      Specialty newSpecialty2 = new Specialty(name02);
      newSpecialty2.Save();
      List<Specialty> newList = new List<Specialty> { newSpecialty1, newSpecialty2 };
      //Act
      List<Specialty> result = Specialty.GetAll();
      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectSpecialtyFromDatabase_Specialty()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("Jeffandrew");
      testSpecialty.Save();
      //Act
      Specialty foundSpecialty = Specialty.Find(testSpecialty.GetId());
      //Assert
      Assert.AreEqual(testSpecialty, foundSpecialty);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Specialty()
    {
      //Arrange, Act
      Specialty firstSpecialty = new Specialty("Jeffandrew");
      Specialty secondSpecialty = new Specialty("Jeffandrew");
      //Assert
      Assert.AreEqual(firstSpecialty, secondSpecialty);
    }

    [TestMethod]
    public void Save_SavesToDatabase_SpecialtyList()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("Jeffandrew");
      //Act
      testSpecialty.Save();
      List<Specialty> result = Specialty.GetAll();
      List<Specialty> testList = new List<Specialty>{testSpecialty};
      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("Jeffandrew");
      //Act
      testSpecialty.Save();
      Specialty savedSpecialty = Specialty.GetAll()[0];

      int result = savedSpecialty.GetId();
      int testId = testSpecialty.GetId();
      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Edit_UpdatesSpecialtyInDatabase_String()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("Jeffandrew");
      testSpecialty.Save();
      string secondName = "Taako";
      //Act
      testSpecialty.Edit(secondName);
      string result = Specialty.Find(testSpecialty.GetId()).GetName();
      //Assert
      Assert.AreEqual(secondName, result);
    }


    [TestMethod]
    public void Delete_DeletesSpecialtyAssociationsFromDatabase_SpecialtyList()
    {
      //Arrange
      Stylist testStylist = new Stylist("Jeffandrew");
      testStylist.Save();
      string testName = "Jeffandrew";
      Specialty testSpecialty = new Specialty(testName);
      testSpecialty.Save();
      //Act
      testSpecialty.AddStylist(testStylist);
      testSpecialty.Delete();
      List<Specialty> resultStylistSpecialties = testStylist.GetSpecialties();
      List<Specialty> testStylistSpecialties = new List<Specialty> {};
      //Assert
      CollectionAssert.AreEqual(testStylistSpecialties, resultStylistSpecialties);
    }

  }
}
