using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class CategoryTest : IDisposable
  {

    public void Dispose()
    {
      Category.ClearAll();
    }

    [TestMethod]
    public void CategoryConstructor_CreatesInstanceOfCategory_Category()
    {
      Category newCategory = new Category("test category");
      Assert.AreEqual(typeof(Category), newCategory.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsDetails_String()
    {
      string details = "Test Category";
      Category newCategory = new Category(details);
      string result = newCategory.GetDetails();
      Assert.AreEqual(details, result);
    }

    [TestMethod]
    public void GetId_ReturnsCategoryId_Int()
    {
      string details = "Test Category";
      Category newCategory = new Category(details);
      int result = newCategory.GetId();
      Assert.AreEqual(1, result);
   }

   [TestMethod]
   public void GetAll_ReturnsAllCategoryObjects_CategoryList()
   {
     string details01 = "Client";
     string details02 = "Specialty";
     Category newCategory1 = new Category(details01);
     Category newCategory2 = new Category(details02);
     List<Category> newList = new List<Category> { newCategory1, newCategory2 };
     List<Category> result = Category.GetAll();
     CollectionAssert.AreEqual(newList, result);
   }

   [TestMethod]
   public void Find_ReturnsCorrectCategory_Category()
   {
     string details01 = "Client";
     string details02 = "Specialty";
     Category newCategory1 = new Category(details01);
     Category newCategory2 = new Category(details02);
     Category result = Category.Find(2);
     Assert.AreEqual(newCategory2, result);
   }

   [TestMethod]
   public void GetStylist_ReturnsEmptyStylistList_StylistList()
   {
     string details = "Clients";
     Category newCategory = new Category(details);
     List<Stylist> newList = new List<Stylist> { };
     List<Stylist> result = newCategory.GetStylists();
     CollectionAssert.AreEqual(newList, result);
   }

   [TestMethod]
   public void AddStylist_AssociatesStylistWithCategory_StylistList()
   {
     string name = "Jeffandrew";
     Stylist newStylist = new Stylist(name);
     List<Stylist> newList = new List<Stylist> { newStylist };
     string details = "Client";
     Category newCategory = new Category(details);
     newCategory.AddStylist(newStylist);
     List<Stylist> result = newCategory.GetStylists();
     CollectionAssert.AreEqual(newList, result);
   }
 }
}
