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
    public void OrderConstructor_CreatesInstanceOfOrder_Order () {
      Order newOrder = new Order ();
      Assert.AreEqual (typeof (Order), newOrder.GetType ());
    }
}
}