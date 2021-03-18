using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using OzonePrime.Models;
using OzonePrime.Services;
using System;
using System.Data;

namespace ozoneprimeTests.ServicesTests.UserServiceTests
{
    class LogInTests
    {
        private ozoneprimeContext context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ozoneprimeContext>()
                .UseInMemoryDatabase("TestDb").Options;

            this.context = new ozoneprimeContext(options);
        }

        [TearDown]
        public void TearDown()
        {
            this.context.Database.EnsureDeleted();
        }

        [Test]
        public void ThrowsExcIfInTheContextIsntAProfileThatMatchesTheLogInInfo()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = "peshkata";
            
            string message = "";

            try
            {
                userService.LogIn(user);
            }
            catch (MissingMemberException ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Such profile doesn't exist.", message);
        }

        [Test]
        public void ThrowsExcIfInTheresALoggedUser()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = "peshkata";
            user.FirstName = "peshkata";
            user.IsLoggedIn = true;

            this.context.Users.Add(user);
            this.context.SaveChanges();

            User user1 = new User();
            user1.UserName = "peshkata";
            user1.Password = "peshkata";

            string message = "";

            try
            {
                userService.LogIn(user1);
            }
            catch (AccessViolationException ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("You are logged in, please logout and try again!", message);
        }

        [Test]
        public void ThrowsExcIfInThePasswordIsWrong()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = userService.Base64Encode("peshkata");
            user.FirstName = "peshkata";
            
            this.context.Users.Add(user);
            this.context.SaveChanges();

            User user1 = new User();
            user1.UserName = "peshkata";
            user1.Password = "peshkatata";

            string message = "";

            try
            {
                userService.LogIn(user1);
            }
            catch (InvalidOperationException ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Wrong password.", message);
        }

        [Test]
        public void LogsUserCorrectly()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = userService.Base64Encode("peshkata");
            user.FirstName = "peshkata";

            User user1 = new User();
            user1.UserName = "peshkata1";
            user1.Password = userService.Base64Encode("peshkata1");
            user1.FirstName = "peshkata1";

            this.context.Users.Add(user);
            this.context.Users.Add(user1);
            this.context.SaveChanges();

            User loggingUser = new User();
            loggingUser.UserName = "peshkata";
            loggingUser.Password = "peshkata";
                        
            userService.LogIn(loggingUser);

            User loggedUser = userService.UserProfile();
            
            Assert.AreEqual("peshkata", loggedUser.FirstName);
        }
    }
}
