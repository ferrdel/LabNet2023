using Lab.EF.Data;
using Lab.EF.Entities;
using Lab.EF.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Lab.EF.Logic.Tests
{
    [TestClass()]
    public class CategoriesLogicTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var mockSet = new Mock<DbSet<Categories>>();

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

            var categoriesLogic = new CategoriesLogic(mockContext.Object);

            categoriesLogic.Add(new Categories
            {
                CategoryID = 21,
                CategoryName = "TestName"
            });

            mockSet.Verify(m => m.Add(It.IsAny<Categories>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}