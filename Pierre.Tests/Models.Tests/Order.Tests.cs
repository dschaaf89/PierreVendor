using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Pierre.Models;

namespace Pierre.Tests
{
    [TestClass]
  public class OrderTest {

    // public void Dispose () {
    //   Item.ClearAll ();
    // }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order() 
    {
      Order newOrder = new Order ("test","test",5);
      Assert.AreEqual (typeof (Order), newOrder.GetType ());
    }
     [TestMethod]
    public void GetTitle_ReturnsTitle_String() 
    {
      //Arrange
      string title = "bob's store";

      //Act
      Order newVendor = new Order (title,"order Croissants",30);
      string result = newVendor.Title;

      //Assert
      Assert.AreEqual (title, result);
    }


}
}