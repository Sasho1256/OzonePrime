using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using OzonePrime.Models;
using OzonePrime.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ozoneprimeTests.ServicesTests.DirectorServiceTests
{
    class CreateDirectorTests
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

        public void ThrowsExceptionIfFirstNameIsNull()
        {
            DirectorService directorService = new DirectorService(this.context);
            Director director = new Director();
            director.LastName = "Goshev";
            string message = "";
            try
            {
                directorService.Create(director);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }
            Assert.AreEqual("Incorrect input for first name.", message);

        }

        [Test]

        public void ThrowsExceptionIfFirstNameIsEmpty()
        {
            DirectorService directorService = new DirectorService(this.context);
            Director director = new Director();
            director.FirstName = "";
            string message = "";
            try
            {
                directorService.Create(director);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }
            Assert.AreEqual("Incorrect input for first name.", message);

        }

        [Test]

        public void ThrowsExceptionIfFirstNameIsWhiteSpace()
        {
            DirectorService directorService = new DirectorService(this.context);
            Director director = new Director();
            director.FirstName = " ";
            string message = "";
            try
            {
                directorService.Create(director);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }
            Assert.AreEqual("Incorrect input for first name.", message);

        }

        [Test]

        public void ThrowsExceptionIfLastNameIsNull()
        {
            DirectorService directorService = new DirectorService(this.context);
            Director director = new Director();
            director.FirstName = "Gosho";
            string message = "";
            try
            {
                directorService.Create(director);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }
            Assert.AreEqual("Incorrect input for last name.", message);

        }

        [Test]

        public void ThrowsExceptionIfLastNameIsEmpty()
        {
            DirectorService directorService = new DirectorService(this.context);
            Director director = new Director();
            director.FirstName = "Gosho";
            director.LastName = "";
            string message = "";
            try
            {
                directorService.Create(director);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }
            Assert.AreEqual("Incorrect input for last name.", message);

        }

        [Test]

        public void ThrowsExceptionIfLastNameIsWhiteSpace()
        {
            DirectorService directorService = new DirectorService(this.context);
            Director director = new Director();
            director.FirstName = "Gosho";
            director.LastName = " ";
            string message = "";
            try
            {
                directorService.Create(director);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }
            Assert.AreEqual("Incorrect input for last name.", message);

        }

        [Test]
        public void CreatesDirectorCorrectly()
        {
            DirectorService directorService = new DirectorService(this.context);
            Director director = new Director();
            director.FirstName = "Gosho";
            director.LastName = "Goshev";
            directorService.Create(director);

            List<Director> directors = this.context.Directors.ToList();

            Assert.AreEqual("Gosho", directors[0].FirstName);
            Assert.AreEqual("Goshev", directors[0].LastName);

        }
    }
}
