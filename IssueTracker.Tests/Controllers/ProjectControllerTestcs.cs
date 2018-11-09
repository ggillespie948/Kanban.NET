using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IssueTracker;
using IssueTracker.Controllers;
using IssueTracker.Models;

namespace IssueTracker.Tests.Controllers
{
    [TestClass]
    public class ProjectControllerTestcs
    {
        [TestMethod]
        public void Details()
        {
            // Arranger
            //ProjectController controller = new ProjectController();

            // Act
            //ViewResult result = controller.Details() as ViewResult;

            // Assert
            //Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddNewProject()
        {
            //Arrange
            ProjectController controller = new ProjectController();
            var mockedDb = new MockedApplicationDbContext();
            mockedDb.ProjectModels = new FakeDbSet<ProjectModels>();
            var projectModel = new ProjectModels { Id = 1, ApplicationUserId = "123abc",
                Title = "New Project", Description = "New Project Description", };

            //Act
            mockedDb.ProjectModels.Add(projectModel);

            //Assert
            mockedDb.ProjectModels.Contains(projectModel);

        }

        [TestMethod]
        public void RetrieveProjectDetails()
        {

        }

        
    }
}
