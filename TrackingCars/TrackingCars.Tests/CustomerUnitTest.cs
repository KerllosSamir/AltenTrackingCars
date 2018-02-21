using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrackingCars.Controllers;
using TrackingCars.Models;
using TrackingCars.UISearchCriterias;
using System.Collections.Generic;

namespace TrackingCars.Tests
{
    [TestClass]
    public class CustomerUnitTest
    {
        [TestMethod]
        public void GetCustomersTestMethod()
        {

            //Arrange
            CustomerController customer = new CustomerController();
            UICustomerSC sc = new UICustomerSC();
            List<CustomerModel> lstCustomers;

            //Act
            lstCustomers= customer.GetCustomers(sc);



            //Assert

            Assert.IsNotNull(lstCustomers);

            Assert.AreNotEqual(0, lstCustomers.Count);

            Assert.IsNotNull(lstCustomers[0].Vehicles);


            sc.Id = 1;
            lstCustomers = customer.GetCustomers(sc);

            Assert.IsNotNull(lstCustomers);



        }


        [TestMethod]
        public void GetCustomersLookupTestMethod()
        {

            //Arrange
            CustomerController customer = new CustomerController();
            UICustomerSC sc = new UICustomerSC();
            List<CustomerModel> lstCustomers;

            //Act
            lstCustomers = customer.GetCustomerLookup();

            //Assert

            Assert.IsNotNull(lstCustomers);

            Assert.AreNotEqual(0, lstCustomers.Count);

            Assert.IsNull(lstCustomers[0].Vehicles);

        }
    }
}
