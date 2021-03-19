using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using OzonePrime.Models;
using OzonePrime.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ozoneprimeTests.ServicesTests.DirectorServiceTests
{
    class GetAllDirectorsTests
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
        public void GetAllDirectorTests()
        {
            DirectorService directorService = new DirectorService(this.context);
            Director director = new Director();
            director.FirstName = "Gosho";
            director.LastName = "Goshev";

            this.context.Directors.Add(director);
            this.context.SaveChanges();

            List<Director> directors = directorService.GetAll();

            Assert.AreEqual("Gosho", directors[0].FirstName);
            Assert.AreEqual("Goshev", directors[0].LastName);

        }
    }
}
