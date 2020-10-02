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
      Vendor newVendor = new Vendor("test","test");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
  {
    //Arrange
    string name = "Test name";
    Vendor newVendor = new Vendor(name,"test");

    //Act
    string result = newVendor.Name;

    //Assert
    Assert.AreEqual(name, result);
  }
   [TestMethod]
    public void GetDescription_ReturnsDescription_String()
  {
    //Arrange
    string description = "Test description";
    Vendor newVendor = new Vendor("name",description);

    //Act
    string result = newVendor.Description;

    //Assert
    Assert.AreEqual(description, result);
  }

  }
}
