using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using OzonePrime.Models;
using OzonePrime.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ozoneprimeTests.ServicesTests.GenreServiceTests
{
    class CreateGenreTests
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

        public void ThrowsExceptionIfNameIsNull()
        {
            GenreService genreService = new GenreService(this.context);
            Genre genre = new Genre();
            string message = "";
            try
            {
                genreService.Create(genre);
            }
            catch(ArgumentException ex)
            {
                message = ex.Message;
            }
            Assert.AreEqual("Incorrect input for name.", message);

        }

        [Test]

        public void ThrowsExceptionIfNameIsEmpty()
        {
            GenreService genreService = new GenreService(this.context);
            Genre genre = new Genre();
            genre.Name = "";
            string message = "";
            try
            {
                genreService.Create(genre);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }
            Assert.AreEqual("Incorrect input for name.", message);

        }

        [Test]

        public void ThrowsExceptionIfNameIsWhiteSpace()
        {
            GenreService genreService = new GenreService(this.context);
            Genre genre = new Genre();
            genre.Name = " ";
            string message = "";
            try
            {
                genreService.Create(genre);
            }
            catch (ArgumentException ex)
            {
                message = ex.Message;
            }
            Assert.AreEqual("Incorrect input for name.", message);

        }

        [Test]

        public void CreatesGenreCorrectly()
        {
            GenreService genreService = new GenreService(this.context);
            Genre genre = new Genre();
            genre.Name = "Action";
            genreService.Create(genre);
            List<Genre> genres = this.context.Genres.ToList();

            Assert.AreEqual("Action", genres[0].Name);

        }
    }
}
