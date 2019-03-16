using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtyControllerTest
    {

      [TestMethod]
      public void CreateSpecialty_ReturnsCorrectSpecialtiesView_True()
      {
        //Arrange
        SpecialtiesController controller = new SpecialtiesController();

        //Act
        ActionResult indexView = controller.New();

        //Assert
        Assert.IsInstanceOfType(indexView, typeof(ViewResult));
      }

    }
}
