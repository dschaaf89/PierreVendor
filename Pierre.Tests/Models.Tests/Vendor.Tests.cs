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
      
      //Act
      List<Vendor> newResult = Vendor.GetAll();
      //Assert
      CollectionAssert.AreEqual (newList, newResult);
    }
    [TestMethod]
  public void Find_ReturnsCorrectVendor_Vendor()
  {
    //Arrange
    string name01 = "Work";
    string name02 = "School";
    Vendor newVendor1 = new Vendor(name01,"Test");
    Vendor newVendor2 = new Vendor(name02,"test");

    //Act
    Vendor result = Vendor.Find(2);

    //Assert
    Assert.AreEqual(newVendor2, result);
  }
  [TestMethod]
  public void AddOrder_VendorOrdersListHasOrder_Vendor()
  {
    //Arrange
    string name01 = "Work";
    Vendor newVendor1 = new Vendor(name01,"Test");
    Order newOrder1 = new Order ("bob","12dozen",20,DateTime.Now,1,"bob",1);
    List<Order> newVendorOrders= new List<Order> {newOrder1};
    newVendor1.AddOrder(newOrder1);
    
    //Act
    List<Order> result = newVendor1.GetOrders();
    
    //Assert
     CollectionAssert.AreEqual(newVendorOrders, result);
  }
  // same test because i need to retrieve the list with GetOrders. and test it.
    [TestMethod]
  public void GetOrders_ReturnsAListOfOrders_Vendor()
  {
    //Arrange
    string name01 = "Work";
    Vendor newVendor1 = new Vendor(name01,"Test");
    Order newOrder1 = new Order ("bob","12dozen",20,DateTime.Now,1,"bob",1);
    List<Order> newVendorOrders= new List<Order> {newOrder1};
    newVendor1.AddOrder(newOrder1);
    
    //Act
    List<Order> result = newVendor1.GetOrders();
    
    //Assert
     CollectionAssert.AreEqual(newVendorOrders, result);
  }
   [TestMethod]
  public void GetOrderCOunt_ReturnsTheCountOfOrdersInList_Vendor()
  {
    //Arrange
    string name01 = "Work";
    Vendor newVendor1 = new Vendor(name01,"Test");
    Order newOrder1 = new Order ("bob","12dozen",20,DateTime.Now,1,"bob",1);
    newVendor1.AddOrder(newOrder1);
    
    
    //Act
    int result = newVendor1.GetOrderCount();
    
   
    //Assert
     Assert.AreEqual(1, result);
  }
  [TestMethod]
  public void GetVendorWithId_returnsCorrectVendor_vendor()
  {
    //Arrange
    string name01 = "Work";
    string name02 = "School";
    Vendor newVendor1 = new Vendor(name01,"Test");
    Vendor newVendor2 = new Vendor(name02,"test");
    List<Vendor> newVendor = new List<Vendor>(){newVendor1,newVendor2};
    
    //Act
    Vendor result = Vendor.GetVendorWithId(1);

    //Assert
    Assert.AreEqual(result, newVendor2);
  }
  [TestMethod]
  public void SearchVendor_returnsCorrectVendor_vendor()
  {
    //Arrange
    string name01 = "Work";
    string name02 = "School";
    Vendor newVendor1 = new Vendor(name01,"Test");
    Vendor newVendor2 = new Vendor(name02,"test");

    //Act
    Vendor result = Vendor.SearchVendor("Work");

    //Assert
    Assert.AreEqual(newVendor1, result);
  }
  

  }
}