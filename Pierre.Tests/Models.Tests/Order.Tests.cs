using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Pierre.Models;

namespace Pierre.Tests
{
    [TestClass]
  public class OrderTest : IDisposable {

    public void Dispose () {
      Order.ClearAll ();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order() 
    {
      Order newOrder = new Order ("test","test",5,DateTime.Now);
      Assert.AreEqual (typeof (Order), newOrder.GetType ());
    }
     [TestMethod]
    public void GetTitle_ReturnsTitle_String() 
    {
      //Arrange
      string title = "bob's store";

      //Act
      Order newVendor = new Order (title,"order Croissants",30,DateTime.Now);
      string result = newVendor.Title;

      //Assert
      Assert.AreEqual (title, result);
    }
    [TestMethod]
    public void SetDescription_SetDescription_String () {
      //Arrange
      string description = "croissants.";
      Order newOrder = new Order ("bobs Store",description,30,DateTime.Now);

      //Act
      string updatedDescription = "sourdough bread";
      newOrder.Description = updatedDescription;
      string result = newOrder.Description;

      //Assert
      Assert.AreEqual (updatedDescription, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_OrderList () {
      // Arrange
      List<Order> newList = new List<Order> { };

      // Act
      List<Order> result = Order.GetAll ();

      // Assert
      CollectionAssert.AreEqual (newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsOrders_OrderList () {
      //Arrange
      string description01 = "sourdough bread and cookies";
      string description02 = "cookies and cakes";
      Order newOrder1 = new Order ("bob",description01,5,DateTime.Now);
      Order newOrder2 = new Order ("green",description02,10,DateTime.Now);
      List<Order> newList = new List<Order> { newOrder1, newOrder2 };

      //Act
      List<Order> result = Order.GetAll ();

      //Assert
      CollectionAssert.AreEqual (newList, result);

    }

    [TestMethod]
    public void GetId_OrdersInstantiateWithAnIdAndGetterReturns_Int () {
      //Arrange
     string description = "sourdough bread and cookies.";
    Order newOrder = new Order("bob",description,15,DateTime.Now);

      //Act
      int result = newOrder.Id;

      //Assert
      Assert.AreEqual (1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectOrder_Order () {
      //Arrange
      string description01 = "sourdough bread and cookies";
      string description02 = "cookies and cakes";
      Order newOrder1 = new Order ("bob",description01,20,DateTime.Now);
      Order newOrder2 = new Order ("fred",description02,15,DateTime.Now);

      //Act
        Order result = Order.Find(2);

      //Assert
      Assert.AreEqual (newOrder2, result);
    }


}
}