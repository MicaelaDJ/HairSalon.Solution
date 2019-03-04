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
      Stylist newStylist = new Stylist("test");
      Assert.AreEqual(typeof(Stylist), newStylist.GetType());
    }

    [TestMethod]
    public void GetName_ReturnName_StylistNameString()
    {
      string name = "Jeffandrew";
      Stylist newStylist = new Stylist(name);
      string result = newStylist.GetName();
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void SetName_SetStylistName_StylistNameString()
    {
      string name = "Jeffandrew";
      Stylist newStylist = new Stylist(name);
      string updatedName = "Taako";
      newStylist.SetName(updatedName);
      string result = newStylist.GetName();
      Assert.AreEqual(updatedName, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyStylistList_StylistList()
    {
      List<Stylist> newList = new List<Stylist> { };
      List<Stylist> result = Stylist.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsStylists_StylistList()
    {
      string name01 = "Jeffandrew";
      string name02 = "Taako";
      Stylist newStylist1 = new Stylist(name01);
      Stylist newStylist2 = new Stylist(name02);
      List<Stylist> newList = new List<Stylist> { newStylist1, newStylist2 };
      List<Stylist> result = Stylist.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_StylistsInstantiateWithAnIdAndGetterReturns_Int()
    {
      string name = "Jeffandrew";
      Stylist newStylist = new Stylist(name);
      int result = newStylist.GetId();
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectStylist_Stylist()
    {
      string name01 = "Jeffandrew";
      string name02 = "Taako";
      Stylist newStylist1 = new Stylist(name01);
      Stylist newStylist2 = new Stylist(name02);
      Stylist result = Stylist.Find(2);
      Assert.AreEqual(newStylist2, result);
    }

    // [TestMethod]
    // public void GetId_TestToReturnNameId_Int()
    // {
    //   StylistClass name = new StylistClass("Jeffandrew");
    //   var newName = name.GetId();
    //   Assert.IsInstanceOfType(newName, typeof(int));
    // }

  }
}
