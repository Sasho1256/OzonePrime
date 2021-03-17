using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using OzonePrime.Models;
using OzonePrime.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ozoneprimeTests.ServicesTests.UserServiceTests
{
    class RegisterTests
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
        public void ThrowsExcIfSomeoneIsLoggedIn()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = "peshkata";
            user.FirstName = "peshkata";
            user.LastName = "peshkata";
            user.IsLoggedIn = true;

            this.context.Users.Add(user);
            this.context.SaveChanges();

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();
            confirmPassword.ConfirmPassword = "peshkata";

            string message = "";

            try
            {
                userService.Register(user, confirmPassword);
            }
            catch (AccessViolationException ex)
            {
                message = ex.Message;  
            }

            Assert.AreEqual("You are logged in, please logout and try again!", message);
        }

        [Test]
        public void ThrowsExcIfThereIsSomeoneWithTheSame()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = "peshkata";
            user.FirstName = "peshkata";
            user.LastName = "peshkata";
            user.IsLoggedIn = false;

            this.context.Users.Add(user);
            this.context.SaveChanges();

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();
            confirmPassword.ConfirmPassword = "peshkata";

            string message = "";

            try
            {
                userService.Register(user, confirmPassword);
            }
            catch (DuplicateNameException ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("A user with that username already exists!", message);
        }

        //========================================================

        [Test]
        public void ThrowsExcIfUsernameIsNull()
        {
            UserService userService = new UserService(this.context);

            User user = new User();            
            
            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();

            string message = "";

            try
            {
                userService.Register(user, confirmPassword);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Invalid input for username.", message);
        }

        [Test]
        public void ThrowsExcIfUsernameIsEmptyString()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "";

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();

            string message = "";

            try
            {
                userService.Register(user, confirmPassword);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Invalid input for username.", message);
        }

        [Test]
        public void ThrowsExcIfUsernameIsWhiteSpace()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = " ";

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();

            string message = "";

            try
            {
                userService.Register(user, confirmPassword);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Invalid input for username.", message);
        }

        //========================================================

        [Test]
        public void ThrowsExcIfPasswordIsNull()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();

            string message = "";

            try
            {
                userService.Register(user, confirmPassword);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Invalid input for password.", message);
        }

        [Test]
        public void ThrowsExcIPasswordIsEmptyString()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = "";

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();

            string message = "";

            try
            {
                userService.Register(user, confirmPassword);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Invalid input for password.", message);
        }

        [Test]
        public void ThrowsExcIfPasswordIsWhiteSpace()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = " ";

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();

            string message = "";

            try
            {
                userService.Register(user, confirmPassword);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Invalid input for password.", message);
        }

        //========================================================

        [Test]
        public void ThrowsExcIfFirstNameIsNull()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = "peshkata";            

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();

            string message = "";

            try
            {
                userService.Register(user, confirmPassword);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Invalid input for first name.", message);
        }

        [Test]
        public void ThrowsExcIfFirstNameIsEmptyString()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = "peshkata";
            user.FirstName = "";

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();

            string message = "";

            try
            {
                userService.Register(user, confirmPassword);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Invalid input for first name.", message);
        }

        [Test]
        public void ThrowsExcIfFirstNameIsWhiteSpace()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = "peshkata";
            user.FirstName = " ";

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();

            string message = "";

            try
            {
                userService.Register(user, confirmPassword);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Invalid input for first name.", message);
        }

        //========================================================

        [Test]
        public void ThrowsExcIfConfirmPasswordIsNull()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = "peshkata";
            user.FirstName = "peshkata";

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();

            string message = "";

            try
            {
                userService.Register(user, confirmPassword);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Invalid input for confirmation password.", message);
        }

        [Test]
        public void ThrowsExcIfConfirmPasswordIsEmptyString()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = "peshkata";
            user.FirstName = "peshkata";

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();
            confirmPassword.ConfirmPassword = "";

            string message = "";

            try
            {
                userService.Register(user, confirmPassword);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Invalid input for confirmation password.", message);
        }

        [Test]
        public void ThrowsExcIfConfirmPasswordIsWhiteSpace()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = "peshkata";
            user.FirstName = "peshkata";

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO(" ");

            string message = "";

            try
            {
                userService.Register(user, confirmPassword);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Invalid input for confirmation password.", message);
        }

        //========================================================

        [Test]
        public void ThrowsExcIfPasswordAndConfirmPasswordDontMatch()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = "peshkata";
            user.FirstName = "peshkata";
            
            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();
            confirmPassword.ConfirmPassword = "peshkatata";

            string message = "";

            try
            {
                userService.Register(user, confirmPassword);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }

            Assert.AreEqual("Password and confirmation password don't match.", message);
        }

        [Test]
        public void RegistersAPersonCorrectly()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = "peshkata";
            user.FirstName = "peshkata";
            user.LastName = "peshkata";
            user.IsLoggedIn = true;

            User user1 = new User();
            user1.UserName = "peshkata1";
            user1.Password = "peshkata";
            user1.FirstName = "peshkata";
            user1.LastName = "peshkata";

            this.context.Users.Add(user1);
            this.context.SaveChanges();

            ConfirmPasswordDTO confirmPassword = new ConfirmPasswordDTO();
            confirmPassword.ConfirmPassword = "peshkata";
            
            userService.Register(user, confirmPassword);

            User user2 = userService.UserProfile();
            
            Assert.AreEqual("peshkata", user2.UserName);
        }
    }
}
