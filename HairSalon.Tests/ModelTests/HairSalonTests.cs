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

  }
}
