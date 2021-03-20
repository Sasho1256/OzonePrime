using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using OzonePrime.Models;
using OzonePrime.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ozoneprimeTests.ServicesTests.FilmServiceTests
{
    class FilmEditTests
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
        public void ThrowsExcIfFilmNameIsNull()
        {
            FilmService filmService = new FilmService(this.context);
            Film updatedFilm = new Film();


            string mess = "";
            try
            {
                filmService.Edit(updatedFilm, "1");
            }
            catch (ArgumentException ex)
            {
                mess = ex.Message;
            }

            Assert.AreEqual("Invalid input for name.", mess);
        }

        [Test]
        public void ThrowsExcIfFilmNameIsEmpty()
        {
            FilmService filmService = new FilmService(this.context);

            string mess = "";

            Film updatedFilm = new Film();
            updatedFilm.Name = "";
            
            try
            {
                filmService.Edit(updatedFilm, "1");
            }
            catch (ArgumentException ex)
            {
                mess = ex.Message;
            }

            Assert.AreEqual("Invalid input for name.", mess);
        }

        [Test]
        public void ThrowsExcIfFilmNameIsWhiteSpace()
        {
            FilmService filmService = new FilmService(this.context);

            string mess = "";

            Film updatedFilm = new Film();
            updatedFilm.Name = " ";

            try
            {
                filmService.Edit(updatedFilm, "1");
            }
            catch (ArgumentException ex)
            {
                mess = ex.Message;
            }

            Assert.AreEqual("Invalid input for name.", mess);
        }

        [Test]
        public void ThrowsExcIfDescriptionIsNull()
        {
            FilmService filmService = new FilmService(this.context);

            string mess = "";

            Film updatedFilm = new Film();
            updatedFilm.Name = "Star Wars";

            try
            {
                filmService.Edit(updatedFilm, "1");
            }
            catch (ArgumentException ex)
            {
                mess = ex.Message;
            }

            Assert.AreEqual("Invalid input for description.", mess);
        }

        [Test]
        public void ThrowsExcIfFilmDescriptionIsEmpty()
        {
            FilmService filmService = new FilmService(this.context);

            string mess = "";

            Film updatedFilm = new Film();
            updatedFilm.Name = "Star Wars";
            updatedFilm.Description = "";

            try
            {
                filmService.Edit(updatedFilm, "1");
            }
            catch (ArgumentException ex)
            {
                mess = ex.Message;
            }

            Assert.AreEqual("Invalid input for description.", mess);
        }

        [Test]
        public void ThrowsExcIfFilmDescriptionIsWhiteSpace()
        {
            FilmService filmService = new FilmService(this.context);

            string mess = "";

            Film updatedFilm = new Film();
            updatedFilm.Name = "Star Wars";
            updatedFilm.Description = " ";

            try
            {
                filmService.Edit(updatedFilm, "1");
            }
            catch (ArgumentException ex)
            {
                mess = ex.Message;
            }

            Assert.AreEqual("Invalid input for description.", mess);
        }

        [Test]
        public void EditFilmCorrectly()
        {
            FilmService filmService = new FilmService(this.context);

            Director director = new Director();
            director.Id = 1;
            director.FirstName = "asdasd";
            director.LastName = "asdasd";

            Genre genre = new Genre();
            genre.Id = 1;
            genre.Name = "asdasd";

            Film film = new Film();
            film.Id = 1;
            film.Name = "Star Wars";
            film.Price = 15;
            film.YearRelease = 1999;
            film.DirectorId = 1;
            film.GenreId = 1;
            film.Description = "qk film";

            this.context.Add(film);
            this.context.SaveChanges();

            Film updatedFilm = new Film();
            updatedFilm.Name = "Star Wars 2";
            updatedFilm.Price = 15;
            updatedFilm.YearRelease = 1999;
            updatedFilm.DirectorId = 1;
            updatedFilm.GenreId = 1;
            updatedFilm.Description = "qk film 2";

            filmService.Edit(updatedFilm, "1");

            List<Film> films = this.context.Films.ToList();

            Assert.AreEqual("Star Wars 2", films[0].Name);
            Assert.AreEqual("qk film 2", films[0].Description);

        }
    }
}
