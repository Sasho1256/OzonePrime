using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using OzonePrime.Models;
using OzonePrime.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ozoneprimeTests.ServicesTests.GenreServiceTests
{
    class GetAllGenreTests
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
        public void GetAllTests()
        {
            GenreService genreService = new GenreService(this.context);
            Genre genre = new Genre();
            genre.Name = "Action";

            this.context.Genres.Add(genre);
            this.context.SaveChanges();

            List<Genre> genres = genreService.GetAll();
            Assert.AreEqual("Action", genres[0].Name);

        }    
    }
}
