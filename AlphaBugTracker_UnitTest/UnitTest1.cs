using AlphaBugTracker.BLL;
using AlphaBugTracker.DAL;
using AlphaBugTracker.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace AlphaBugTracker_UnitTest
{
    

    [TestClass]
    public class UnitTest1
    {
        Func<Project, bool> testFunc; 

        [TestMethod]
        public void AddingATicket()
        {
            

            Mock<ProjectRepository> mockRepo = new Mock<ProjectRepository>();
            Project mockProject = new Project { Id = 1, Name = "Project 1 testing" };

            testFunc = f => f.Id == 1;
            
            mockRepo.Setup(repo => repo.Get           
            (It.Is<Func<Project, bool>>(f=> f==testFunc))).Returns(mockProject);

            ProjectBusinessLogic projectBL = new ProjectBusinessLogic(mockRepo.Object);

            
            var projectFound = projectBL.GetProjectById(testFunc);
            Assert.AreEqual(projectFound, mockProject);


        }
    }
}