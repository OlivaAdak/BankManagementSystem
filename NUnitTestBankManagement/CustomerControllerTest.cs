using BankManagement.Controllers;
using BankManagement.Models;
using BankManagement.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTestBankManagement
{
    class CustomerControllerTest
    {
        BankDBContext db;
        [SetUp]
        public void Setup()
        {
            var cust = new List<Customer>
            {
                new Customer{CustomerId = 1, Name="Dummy1", Address="Dummy Address 1", DOB=new DateTime(1996-10-29), AdharCardNo="12345",PhoneNo="1122334455", Email="abc12@gnail.com", AccountType="Savings",Balance=5000},
                new Customer{CustomerId = 2, Name="Dummy2", Address="Dummy Address 2", DOB=new DateTime(1997-02-29), AdharCardNo="12346",PhoneNo="1122334466", Email="abc13@gnail.com", AccountType="Current",Balance=6000},
                new Customer{CustomerId = 3, Name="Dummy3", Address="Dummy Address 3", DOB=new DateTime(1999-11-29), AdharCardNo="12347",PhoneNo="1122334477", Email="abc14@gnail.com", AccountType="Savings",Balance=7000},
                new Customer{CustomerId = 4, Name="Dummy4", Address="Dummy Address 4", DOB=new DateTime(1998-09-29), AdharCardNo="12348",PhoneNo="1122334488", Email="abc15@gnail.com", AccountType="Current",Balance=8000}
            };
            var loandata = cust.AsQueryable();
            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(loandata.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(loandata.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(loandata.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(loandata.GetEnumerator());
            var mockContext = new Mock<BankDBContext>();
            
            mockContext.Setup(c => c.Customers).Returns(mockSet.Object);
            db = mockContext.Object;
        }
        [TestCase]
        public void Get_Details()
        {
            var custdata = new Mock<customer>(db) ;
            Customer_DetailsController obj = new Customer_DetailsController(custdata.Object);
            var data = obj.GetDetails();
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }
        [TestCase]
        public void Get_details_id1()
        {
            var custdata = new Mock<customer>(db);
            Customer_DetailsController obj = new Customer_DetailsController(custdata.Object);
            var data = obj.GetDetail(2);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }
        [Test]
        public void Get_details_id2()
        {
            var custdata = new Mock<customer>(db);
            Customer_DetailsController obj = new Customer_DetailsController(custdata.Object);
            var data = obj.GetDetail(10);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }
        [TestCase]
        public void Add_detail()
        {
            var custdata = new Mock<customer>(db);
            Customer_DetailsController obj = new Customer_DetailsController(custdata.Object);
            Customer n = new Customer { CustomerId = 1, Name = "Dummy1", Address = "Dummy Address 1", DOB = new DateTime(1996 - 10 - 29), AdharCardNo = "12345", PhoneNo = "1122334455", Email = "abc12@gnail.com", AccountType = "Savings", Balance = 5000 };
            var data = obj.AddDetail(n);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }
        [TestCase]
        public void Update_detail()
        {
            var custdata = new Mock<customer>(db);
            Customer_DetailsController obj = new Customer_DetailsController(custdata.Object);
            Customer obj1 = new Customer { AccountType = "savings", Balance = 30000, Name = "gfkrgj" };
            var data = obj.UpdateDetail(2, obj1);
            var okResult = data as string;
            Assert.AreEqual("1", okResult);
        }
        [TestCase]
        public void delete_detail()
        {
            var custdata = new Mock<customer>(db);
            Customer_DetailsController obj = new Customer_DetailsController(custdata.Object);
            var data = obj.DeleteDetail(2);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
