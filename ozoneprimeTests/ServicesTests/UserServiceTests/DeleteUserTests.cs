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
    class DeleteUserTests
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
        public void DeletesTheLoggedUser()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = userService.Base64Encode("peshkata");
            user.FirstName = "peshkata";
            user.IsLoggedIn = true;

            this.context.Users.Add(user);
            this.context.SaveChanges();

            userService.DeleteUser();

            List<User> users = this.context.Users.ToList();

            Assert.AreEqual(0, users.Count);
        }
    }
}
