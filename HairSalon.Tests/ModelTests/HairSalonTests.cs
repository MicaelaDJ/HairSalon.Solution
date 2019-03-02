using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;
using System.IO;

namespace HairSalon.Tests
{
  [TestClass]
  public class HairSalonTest : IDisposable
  {

    public void Dispose()
    {

    }

    [TestMethod]
    public void GetName_TestToReturnName_StylistNameString()
    {
      StylistClass name = new StylistClass("Jeffandrew");
      var newName = name.GetName();
      Assert.IsInstanceOfType(newName, typeof(string));
    }

    [TestMethod]
    public void GetId_TestToReturnNameId_Int()
    {
      StylistClass name = new StylistClass("Jeffandrew");
      var newName = name.GetId();
      Assert.IsInstanceOfType(newName, typeof(int));
    }

    [TestMethod]
    public void FindById_TestToReturnAListOfStylists_Stylist()
    {
      string name = "Jeffandrew";
      StylistClass.Save(name);
      StylistClass temp = StylistClass.FindById(1);
      StylistClass name = new StylistClass("Jeffandrew");
      name = temp;
      Assert.IsInstanceOfType(name, typeof(StylistClass));
    }

    [TestMethod]
    public void DeleteById_TestToDeleteStylistById_StylistList()
    {
      string name = "Jeffandrew";
      List<StylistClass> tempList = new List<StylistClass> {};
      StylistClass.Save(name);
      List<StylistClass> secondTempList = StylistClass.GetAll();
      int id = secondTempList[0].GetId();
      StylistClass.Delete(id);
      List<StylistClass> thirdTempList = StylistClass.GetAll();
      CollectionAssert.AreEqual(tempList, thirdTempList);
    }

    [TestMethod]
  }
}
