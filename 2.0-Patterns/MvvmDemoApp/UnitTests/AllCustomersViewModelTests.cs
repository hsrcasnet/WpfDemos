﻿using DemoApp.DataAccess;
using DemoApp.Model;
using DemoApp.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class AllCustomersViewModelTests
    {
        #region Boilerplate Code

        public AllCustomersViewModelTests()
        {
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        #endregion // Boilerplate Code

        [TestMethod]
        public void TestTotalSelectedSales()
        {
            var repos = new CustomerRepository(Constants.CUSTOMER_DATA_FILE);
            var target = new AllCustomersViewModel(repos);

            var notifications = 0;
            target.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "TotalSelectedSales")
                {
                    ++notifications;
                }
            };

            Assert.AreEqual(0.0, target.TotalSelectedSales, "Should be zero when no customers are selected");

            var firstCust = target.AllCustomers[0];

            firstCust.IsSelected = true;
            Assert.AreEqual(1, notifications, "TotalSelectedSales change notification was not raised");
            Assert.AreEqual(firstCust.TotalSales, target.TotalSelectedSales);

            var secondCust = target.AllCustomers[1];
            secondCust.IsSelected = true;
            Assert.AreEqual(2, notifications, "TotalSelectedSales change notification was not raised again");
            Assert.AreEqual(firstCust.TotalSales + secondCust.TotalSales, target.TotalSelectedSales);
        }

        [TestMethod]
        public void TestNewCustomerIsAdded()
        {
            var repos = new CustomerRepository(Constants.CUSTOMER_DATA_FILE);
            var target = new AllCustomersViewModel(repos);

            Assert.AreEqual(3, target.AllCustomers.Count, "Test data includes three customers");

            repos.AddCustomer(Customer.CreateCustomer(123.45, "new", "customer", false, "new.customer@email.com"));

            Assert.AreEqual(4, target.AllCustomers.Count, "Adding a customer to the repository increase the Count");
        }
    }
}