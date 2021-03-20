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
        /*private ozoneprimeContext context;

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
            Film film = new Film();
            string mess = "";
            try
            {
                filmService.Edit(film, mess);
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

            Film film = new Film();
            film.Id = 1;
            film.Name = "";
            film.Price = 15;
            film.YearRelease = 1999;
            film.DirectorId = 1;
            film.GenreId = 1;
            film.Description = "qk film";

            this.context.Films.Add(film);
            this.context.SaveChanges();

            try
            {
                filmService.Edit(film, mess);
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

            Film film = new Film();
            film.Id = 1;
            film.Name = " ";
            film.Price = 15;
            film.YearRelease = 1999;
            film.DirectorId = 1;
            film.GenreId = 1;
            film.Description = "qk film";

            this.context.Films.Add(film);
            this.context.SaveChanges();

            try
            {
                filmService.Edit(film, mess);
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
            Film film = new Film();
            string mess = "";
            try
            {
                filmService.Edit(film, mess);
            }
            catch (ArgumentException ex)
            {
                mess = ex.Message;
            }

            Assert.AreEqual("Invalid input for name.", mess);
        }

        [Test]
        public void ThrowsExcIfFilmDescriptionIsEmpty()
        {
            FilmService filmService = new FilmService(this.context);

            string mess = "";

            Film film = new Film();
            film.Id = 1;
            film.Name = "Star Wars";
            film.Price = 15;
            film.YearRelease = 1999;
            film.DirectorId = 1;
            film.GenreId = 1;
            film.Description = "";

            this.context.Films.Add(film);
            this.context.SaveChanges();

            try
            {
                filmService.Edit(film, mess);
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

            Film film = new Film();
            film.Id = 1;
            film.Name = "Star Wars";
            film.Price = 15;
            film.YearRelease = 1999;
            film.DirectorId = 1;
            film.GenreId = 1;
            film.Description = " ";

            this.context.Films.Add(film);
            this.context.SaveChanges();

            try
            {
                filmService.Edit(film, mess);
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
            Film film = new Film();
            film.Name = "Gosho";
            film.Description = "qk film";
            filmService.Edit(updatedFilm, filmId);

            List<Film> films = this.context.Films.ToList();

            Assert.AreEqual("Star Wars", films[0].Name);
            Assert.AreEqual("qk film", films[0].Description);

        }*/
    }
}
