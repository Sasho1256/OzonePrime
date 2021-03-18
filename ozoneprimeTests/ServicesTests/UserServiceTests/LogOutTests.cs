using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using OzonePrime.Models;
using OzonePrime.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ozoneprimeTests.ServicesTests.UserServiceTests
{
    class LogOutTests
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
        public void LogsEveryoneOut()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = userService.Base64Encode("peshkata");
            user.FirstName = "peshkata";
            user.IsLoggedIn = true;

            this.context.Users.Add(user);
            this.context.SaveChanges();

            userService.LogOut();

            List<User> users = this.context.Users.Where(u => u.IsLoggedIn == true).ToList();

            Assert.AreEqual(0, users.Count);
        }

    }
}
