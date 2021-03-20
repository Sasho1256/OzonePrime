using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using OzonePrime.Models;
using OzonePrime.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ozoneprimeTests.ServicesTests.UserServiceTests
{
    class UserProfileTests
    {
        private OzoneprimeContext context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<OzoneprimeContext>()
                .UseInMemoryDatabase("TestDb").Options;

            this.context = new OzoneprimeContext(options);
        }

        [TearDown]
        public void TearDown()
        {
            this.context.Database.EnsureDeleted();
        }

        [Test]
        public void ThrowsExcIfNooneIsLoggedIn()
        {
            UserService userService = new UserService(this.context);
                        
            string message = "";

            try
            {
                User user1 = userService.UserProfile();
            }
            catch (AccessViolationException ex)
            {
                message = ex.Message;  
            }            

            Assert.AreEqual("You must log in first!", message);
        }

        [Test]
        public void ReturnsInfoAboutTheLoggedUser()
        {
            User user = new User();
            user.UserName = "peshkata";
            user.Password = "peshkata";
            user.FirstName = "peshkata";
            user.LastName = "peshkata";
            user.IsLoggedIn = true;

            this.context.Users.Add(user);
            this.context.SaveChanges();

            UserService userService = new UserService(this.context);

            User user1 = userService.UserProfile();

            Assert.AreEqual(user.UserName, user1.UserName);
        }
    }
}
