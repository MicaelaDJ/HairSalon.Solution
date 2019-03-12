using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientControllerTest
    {

      [TestMethod]
      public void CreateClient_ReturnsCorrectClientsView_True()
      {
        //Arrange
        ClientsController controller = new ClientsController();

        //Act
        ActionResult indexView = controller.New();

        //Assert
        Assert.IsInstanceOfType(indexView, typeof(ViewResult));
      }


      // [TestMethod]
      // public void Create_ReturnsCorrectModelType_ClientsList()
      // {
      //   //Arrange, Act
      //   ClientsController controller = new ClientsController();
      //
      //   //Assert
      //   Assert.IsInstanceOfType(controller.New(), typeof(ViewResult));
      // }

      // [TestMethod]
      // public void Create_RedirectsToCorrectAction_Index()
      // {
      //   //Arrange
      //   ClientsController controller = new ClientsController();
      //   RedirectToActionResult actionResult = controller.Create("Jeffandrew") as RedirectToActionResult;
      //
      //   //Act
      //   string result = actionResult.ActionName;
      //
      //   //Assert
      //   Assert.AreEqual(result, "Index");
      // }

    }
}
