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
    class AddFilmToMyListTests
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
        public void TestSettingOfFilmsUser()
        {
            FilmsUser filmsUser = new FilmsUser();

            filmsUser.FilmId = 1;
            filmsUser.Film = new Film();
            filmsUser.UserId = 1;
            filmsUser.User = new User();

            Assert.AreEqual(1, filmsUser.UserId);
        }

        [Test]
        public void ThrowsExcIfNooneIsLoggedIn()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = userService.Base64Encode("peshkata");
            user.FirstName = "peshkata";
            
            this.context.Users.Add(user);
            this.context.SaveChanges();

            string mess = "";
            try
            {
                userService.AddFilmToMyList("1");
            }
            catch (AccessViolationException ex)
            {
                mess = ex.Message;
            }            

            Assert.AreEqual("You must log in first!", mess);
        }

        [Test]
        public void AddsFilmToMyList()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "peshkata";
            user.Password = userService.Base64Encode("peshkata");
            user.FirstName = "peshkata";
            user.IsLoggedIn = true;

            Director director = new Director();
            director.Id = 1;
            director.FirstName = "Pesho";
            director.LastName = "Goshev";
            director.Films = new List<Film>();

            Genre genre = new Genre();
            genre.Id = 1;
            genre.Name = "Action";
            genre.Films = new List<Film>();

            Film film = new Film();
            film.Id = 1;
            film.Description = "Cool Movie";
            film.DirectorId = 1;
            film.GenreId = 1;
            film.Name = "Die Hard";
            film.Price = 15;
            film.YearRelease = 2000;
            film.ExpirationDays = 15;
            film.Director = director;
            film.Genre = genre;

            this.context.Users.Add(user);
            this.context.Directors.Add(director);
            this.context.Genres.Add(genre);
            this.context.Films.Add(film);
            this.context.SaveChanges();

            userService.AddFilmToMyList("1");

            List<FilmsUser> filmsUsers = this.context.FilmsUsers.ToList();

            Assert.AreEqual(1, filmsUsers.Count);
        }
    }
}
