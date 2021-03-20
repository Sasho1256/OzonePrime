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
    class EditProfileTests
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

        //==============================================================

        [Test]
        public void ThrowsExcIfConfirmPasswordIsNull()
        {
            UserService userService = new UserService(this.context);

            string mess = "";

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();

            User user = new User();
            user.UserName = "peshkata";
            user.Password = userService.Base64Encode("peshkata");
            user.FirstName = "peshkata";
            user.IsLoggedIn = true;

            this.context.Users.Add(user);
            this.context.SaveChanges();

            try
            {
                userService.EditProfile(user, confirmPassword);
            }
            catch (ArgumentException ex)
            {
                mess = ex.Message;
            }

            Assert.AreEqual("Wrong confirmation password.", mess);
        }

        [Test]
        public void ThrowsExcIfConfirmPasswordIsEmpty()
        {
            UserService userService = new UserService(this.context);

            string mess = "";

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();
            confirmPassword.ConfirmPassword = "";

            User user = new User();
            user.UserName = "peshkata";
            user.Password = userService.Base64Encode("peshkata");
            user.FirstName = "peshkata";
            user.IsLoggedIn = true;

            this.context.Users.Add(user);
            this.context.SaveChanges();

            try
            {
                userService.EditProfile(user, confirmPassword);
            }
            catch (ArgumentException ex)
            {
                mess = ex.Message;
            }

            Assert.AreEqual("Wrong confirmation password.", mess);
        }

        [Test]
        public void ThrowsExcIfConfirmPasswordIsWhiteSpace()
        {
            UserService userService = new UserService(this.context);

            string mess = "";

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();
            confirmPassword.ConfirmPassword = " ";

            User user = new User();
            user.UserName = "peshkata";
            user.Password = userService.Base64Encode("peshkata");
            user.FirstName = "peshkata";
            user.IsLoggedIn = true;

            this.context.Users.Add(user);
            this.context.SaveChanges();

            try
            {
                userService.EditProfile(user, confirmPassword);
            }
            catch (ArgumentException ex)
            {
                mess = ex.Message;
            }

            Assert.AreEqual("Wrong confirmation password.", mess);
        }

        //==============================================================

        [Test]
        public void ThrowsExcIfConfirmPasswordIsIncorrect()
        {
            UserService userService = new UserService(this.context);

            string mess = "";

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();
            confirmPassword.ConfirmPassword = "peshkata1";

            User user = new User();
            user.UserName = "peshkata";
            user.Password = userService.Base64Encode("peshkata");
            user.FirstName = "peshkata";
            user.IsLoggedIn = true;

            this.context.Users.Add(user);
            this.context.SaveChanges();

            try
            {
                userService.EditProfile(user, confirmPassword);
            }
            catch (ArgumentException ex)
            {
                mess = ex.Message;
            }

            Assert.AreEqual("Wrong confirmation password.", mess);
        }

        [Test]
        public void ThrowsExcIfAUserWitTheSameUsernameAlreadyExists()
        {
            UserService userService = new UserService(this.context);

            string mess = "";

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();
            confirmPassword.ConfirmPassword = "peshkata1";

            User user = new User();
            user.UserName = "peshkata1";
            user.Password = userService.Base64Encode("peshkata1");
            user.FirstName = "peshkata1";
            user.IsLoggedIn = true;

            User user1 = new User();
            user1.UserName = "peshkata";
            user1.Password = userService.Base64Encode("peshkata");
            user1.FirstName = "peshkata";

            this.context.Users.Add(user);
            this.context.Users.Add(user1);
            this.context.SaveChanges();

            User user2 = new User();
            user2.UserName = "peshkata";

            try
            {
                userService.EditProfile(user2, confirmPassword);
            }
            catch (DuplicateNameException ex)
            {
                mess = ex.Message;
            }

            Assert.AreEqual("A user with that username already exists!", mess);
        }

        [Test]
        public void UpdatesUsernameCorrectly()
        {
            UserService userService = new UserService(this.context);

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();
            confirmPassword.ConfirmPassword = "peshkata1";

            User user = new User();
            user.UserName = "peshkata1";
            user.Password = userService.Base64Encode("peshkata1");
            user.FirstName = "peshkata1";
            user.IsLoggedIn = true;

            this.context.Users.Add(user);
            this.context.SaveChanges();

            User user1 = new User();
            user1.UserName = "peshkata";

            userService.EditProfile(user1, confirmPassword);

            User user2 = userService.UserProfile();

            Assert.AreEqual("peshkata", user2.UserName);
        }

        [Test]
        public void UpdatesPasswordCorrectly()
        {
            UserService userService = new UserService(this.context);

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();
            confirmPassword.ConfirmPassword = "peshkata1";

            User user = new User();
            user.UserName = "peshkata1";
            user.Password = userService.Base64Encode("peshkata1");
            user.FirstName = "peshkata1";
            user.IsLoggedIn = true;

            this.context.Users.Add(user);
            this.context.SaveChanges();

            User user1 = new User();
            user1.Password = "peshkata";

            userService.EditProfile(user1, confirmPassword);

            User user2 = userService.UserProfile();
                        
            Assert.AreEqual(userService.Base64Encode("peshkata"), user2.Password);
        }

        [Test]
        public void UpdatesFirstNameCorrectly()
        {
            UserService userService = new UserService(this.context);

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();
            confirmPassword.ConfirmPassword = "peshkata1";

            User user = new User();
            user.UserName = "peshkata1";
            user.Password = userService.Base64Encode("peshkata1");
            user.FirstName = "peshkata1";
            user.IsLoggedIn = true;

            this.context.Users.Add(user);
            this.context.SaveChanges();

            User user1 = new User();
            user1.FirstName = "peshkata";

            userService.EditProfile(user1, confirmPassword);

            User user2 = userService.UserProfile();

            Assert.AreEqual("peshkata", user2.FirstName);
        }

        [Test]
        public void UpdatesLastNameCorrectly()
        {
            UserService userService = new UserService(this.context);

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();
            confirmPassword.ConfirmPassword = "peshkata1";

            User user = new User();
            user.UserName = "peshkata1";
            user.Password = userService.Base64Encode("peshkata1");
            user.FirstName = "peshkata1";
            user.IsLoggedIn = true;

            this.context.Users.Add(user);
            this.context.SaveChanges();

            User user1 = new User();
            user1.LastName = "peshkata";

            userService.EditProfile(user1, confirmPassword);

            User user2 = userService.UserProfile();

            Assert.AreEqual("peshkata", user2.LastName);
        }

    }
}
