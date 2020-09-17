using BankManagement.Controllers;
using BankManagement.Models;
using BankManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTestBankManagement
{
    class BranchControllerTest
    {
        BankDBContext db;
        [SetUp]
        public void Setup()
        {
            var branch = new List<BranchDetails>
            {
                new BranchDetails{BranchId = 1, CustomerId=1, Location="Dummy Location 1", IFSC="12345"},
                new BranchDetails{BranchId = 2, CustomerId=2, Location="Dummy Location 2", IFSC="12347" },
                new BranchDetails{BranchId = 4, CustomerId=2, Location="Dummy Location 2", IFSC="12347" }

            };
            var branchdata = branch.AsQueryable();
            var mockSet = new Mock<DbSet<BranchDetails>>();
            mockSet.As<IQueryable<BranchDetails>>().Setup(m => m.Provider).Returns(branchdata.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(branchdata.Expression);
            mockSet.As<IQueryable<BranchDetails>>().Setup(m => m.ElementType).Returns(branchdata.ElementType);
            mockSet.As<IQueryable<BranchDetails>>().Setup(m => m.GetEnumerator()).Returns(branchdata.GetEnumerator());
            var mockContext = new Mock<BankDBContext>();

            mockContext.Setup(d => d.Branches).Returns(mockSet.Object);
            db = mockContext.Object;
        }
        [TestCase]
        public void Get_Details()
        {
            var x = new Mock<branch>(db);
            Branch_DetailsController obj = new Branch_DetailsController(x.Object);
            var data = obj.GetDetails();
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }
        [TestCase]
        public void Get_details_id()
        {
            var x = new Mock<branch>(db);
            Branch_DetailsController obj = new Branch_DetailsController(x.Object);
            var data = obj.GetDetail(1);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }
        [TestCase]
        public void Add_detail()
        {
            var x = new Mock<branch>(db);
           Branch_DetailsController obj = new Branch_DetailsController(x.Object);
            BranchDetails n = new BranchDetails { BranchId=1, CustomerId = 1, Location = "Dummy Location 1", IFSC="99999" };
            var data = obj.AddDetail(n);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }
        [TestCase]
        public void Update_detail()
        {
            var x = new Mock<branch>(db);
            Branch_DetailsController obj = new Branch_DetailsController(x.Object);
            BranchDetails obj2 = new BranchDetails { CustomerId = 6, IFSC = "12345", Location = "fhgjg" };
            var data = obj.UpdateDetail(2, obj2);
            var okResult = data as string;
            Assert.AreEqual("1", okResult);
        }
        [TestCase]
        public void Delete_detail()
        {
            var x = new Mock<branch>(db);
            Branch_DetailsController obj = new Branch_DetailsController(x.Object);
            var data = obj.DeleteDetail(4);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
