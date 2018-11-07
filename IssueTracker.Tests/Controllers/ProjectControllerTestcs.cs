using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IssueTracker;
using IssueTracker.Controllers;

namespace IssueTracker.Tests.Controllers
{
    [TestClass]
    public class ProjectControllerTestcs
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            ProjectController controller = new ProjectController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void Details()
        {
            // Arrange
            //ProjectController controller = new ProjectController();

            // Act
            //ViewResult result = controller.Details() as ViewResult;

            // Assert
            //Assert.IsNotNull(result);

        }
    }
}
