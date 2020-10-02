using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pierre.Models;
namespace Pierre.Tests
{
  [TestClass]
  public class VendorTest
  {
    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor();
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }
    public void GetName_ReturnsName_String()
  {
    //Arrange
    string name = "Test name";
    Vendor newVendor = new Vendor(name);

    //Act
    string result = newVendor.Name;

    //Assert
    Assert.AreEqual(name, result);
  }

  }
}
