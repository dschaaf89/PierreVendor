using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pierre.Models;
namespace Pierre.Tests {
  [TestClass]
  public class VendorTest :IDisposable {
     public void Dispose()
    {
      Vendor.ClearAll();
    }
    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor () {
      Vendor newVendor = new Vendor ("test", "test");
      Assert.AreEqual (typeof (Vendor), newVendor.GetType ());
    }

    [TestMethod]
    public void GetName_ReturnsName_String () {
      //Arrange
      string name = "Test name";
      Vendor newVendor = new Vendor (name, "test");

      //Act
      string result = newVendor.Name;

      //Assert
      Assert.AreEqual (name, result);
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String () {
      //Arrange
      string description = "Test description";
      Vendor newVendor = new Vendor ("name", description);

      //Act
      string result = newVendor.Description;

      //Assert
      Assert.AreEqual (description, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllCategoryObjects_CategoryList () 
    {
      //Arrange
      string name01 = "bread";
      string name02 = "Cookie";
      Vendor newVendor1 = new Vendor (name01,"bread store");
      Vendor newVendor2 = new Vendor (name02,"cookie store");
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };
      List<Vendor> newResult = Vendor.GetAll();
      //Act
      foreach (Vendor item in newResult)
      {
        Console.WriteLine(item.Name);
      }
     

      //Assert
      CollectionAssert.AreEqual (newList, newResult);
    }

  }
}