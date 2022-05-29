using AlphaBugTracker.BLL;
using AlphaBugTracker.DAL;
using AlphaBugTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using AlphaBugTracker.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AlphaBugTracker_UnitTest
{
    [TestClass]
    public class UnitTesting
    {
        Func<Project, bool> testFunc;
        Func<ProjectUser, bool> testFuncPU;
        private int id = 1;

        [TestMethod]
        public void AddingAProject()
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

        [TestMethod]
        public void AddingATicket()
        {

            IdentityUser currUser = new IdentityUser();
            currUser.UserName = "Sahil";


            Mock<ProjectRepository> mockRepoProject = new Mock<ProjectRepository>();
            Project mockProject = new Project { Id = 1, Name = "Project 1 testing" };
            
            Mock<TicketRepository> mockRepoTicket = new Mock<TicketRepository>();
            Ticket mockTicket = new Ticket {
                Id = 1,
                Title = "Ticket 1 testing",
                Description = "Ticket Description",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Project = mockProject,
                TicketTypeId = 0,
                TicketPriorityId = 0,
                TicketStatusId = 0,
                OwnerUser = currUser,
                AssignedToUser = currUser,
            };

            TicketBusinessLogic ticketBL = new TicketBusinessLogic(mockRepoTicket.Object);

            mockRepoTicket.Setup(repo => repo.GetById
            (It.Is<int>(t => t == 1))).Returns(mockTicket);

            var ticketFound = ticketBL.GetTicketById(1);
            Assert.AreEqual(ticketFound, mockTicket);

        }

        [TestMethod]
        public void AddingATicketComment()
        {

            IdentityUser currUser = new IdentityUser();
            currUser.UserName = "Omkar";


            Mock<ProjectRepository> mockRepoProject = new Mock<ProjectRepository>();
            Project mockProject = new Project { Id = 1, Name = "Project 1 testing" };

            Mock<TicketRepository> mockRepoTicket = new Mock<TicketRepository>();
            Ticket mockTicket = new Ticket
            {
                Id = 1,
                Title = "Ticket 1 testing",
                Description = "Ticket Description",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Project = mockProject,
                TicketTypeId = 0,
                TicketPriorityId = 0,
                TicketStatusId = 0,
                OwnerUser = currUser,
                AssignedToUser = currUser,
            };

            Mock<CommentRepository> mockRepoComment = new Mock<CommentRepository>();
            TicketComment mockTicketComment = new TicketComment
            {
                Id = 11,
                Ticket = mockTicket,
                Comment = "Comment testing",
                CreatedDate = DateTime.Now,
               UserCreator = currUser,

            };
            CommentBusinessLogic commentBL = new CommentBusinessLogic(mockRepoComment.Object);

            mockRepoComment.Setup(repo => repo.GetById
            (It.Is<int>(t => t == 1))).Returns(mockTicketComment);

            
            var ticketCommentFound = commentBL.GetById(1);
            Assert.AreEqual(ticketCommentFound, mockTicketComment);

        }

        [TestMethod]
        public void AddingATicketHistory()
        {

            IdentityUser currUser = new IdentityUser();
            currUser.UserName = "Md";


            Mock<ProjectRepository> mockRepoProject = new Mock<ProjectRepository>();
            Project mockProject = new Project { Id = 1, Name = "Project 1 testing" };
            
            Mock<TicketRepository> mockRepoTicket = new Mock<TicketRepository>();
            Ticket mockTicket = new Ticket
            {
                Id = 1,
                Title = "Ticket 1 testing",
                Description = "Ticket Description",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Project = mockProject,
                TicketTypeId = 0,
                TicketPriorityId = 0,
                TicketStatusId = 0,
                OwnerUser = currUser,
                AssignedToUser = currUser,
            };

            Mock<TicketHistoryRepository> mockRepoHistory = new Mock<TicketHistoryRepository>();
            TicketHistory mockHistory = new TicketHistory
            {
                Id = 1,
                Ticket = mockTicket,
                Title = "Ticket 1 testing",
                Description = "Ticket Description",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Project = mockProject,
                TicketTypeId = 0,
                TicketPriorityId = 0,
                TicketStatusId = 0,
                OwnerUser = currUser,
                AssignedToUser = currUser,
            };

        
            TicketHistoryBusinessLogic historyBL = new TicketHistoryBusinessLogic(mockRepoHistory.Object);

            mockRepoHistory.Setup(repo => repo.GetById
            (It.Is<int>(t => t == 1))).Returns(mockHistory);


            var ticketHistoryFound = historyBL.GetTicketHistoryById(1);
            Assert.AreEqual(ticketHistoryFound, mockHistory);

        }

        // Assign users to a project

        [TestMethod]
        public void AssignAUserToAProject()
        {

            IdentityUser currUser1 = new IdentityUser();
            currUser1.UserName = "Johnny";
            IdentityUser currUser2 = new IdentityUser();
            currUser2.UserName = "Omkar";

            Mock<ProjectRepository> mockRepoProject = new Mock<ProjectRepository>();
            Project mockProject = new Project { Id = 1, Name = "Project 1 testing" };

            Mock<ProjectUserRepository> mockRepoProjectUser = new Mock<ProjectUserRepository>();
            List<ProjectUser> mockListProjectUser = new  List<ProjectUser>() { 
            
                new ProjectUser() { Id = 1,  Project = mockProject,   UserMember = currUser1 },
                new ProjectUser() { Id = 2,  Project = mockProject,   UserMember = currUser2 }
            };


            ProjectUserBusinessLogic projectUserBL = new ProjectUserBusinessLogic(mockRepoProjectUser.Object);

            testFuncPU = f => f.Project.Id == 1;

            mockRepoProjectUser.Setup(repo => repo.GetList
            (It.Is<Func<ProjectUser, bool>>(f => f == testFuncPU))).Returns(mockListProjectUser);

            List<ProjectUser> listPUfound = projectUserBL.ListProjectsUsers_ByProjectFunc(testFuncPU);

            Assert.AreEqual(listPUfound.Count, mockListProjectUser.Count);

        }
    }
}