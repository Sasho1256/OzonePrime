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
    class FilmInfoInMyListTests
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
        public void FilmInfoMyListTests()
        {
            UserService userService = new UserService(this.context);

            User user = new User();
            user.UserName = "Gosho";
            user.Password = userService.Base64Encode("Gosho");
            user.FirstName = "Gosho";
            user.IsLoggedIn = true;

            FilmService filmService = new FilmService(this.context);

            Director director = new Director();
            director.Id = 1;
            director.FirstName = "George";
            director.LastName = "Lucas";

            Genre genre = new Genre();
            genre.Id = 1;
            genre.Name = "sci-fi";

            Film film = new Film();
            film.Id = 1;
            film.Name = "Star Wars";
            film.Price = 15;
            film.YearRelease = 1999;
            film.DirectorId = 1;
            film.GenreId = 1;
            film.Description = "qk film";

            this.context.Films.Add(film);
            this.context.Directors.Add(director);
            this.context.Genres.Add(genre);
            this.context.SaveChanges();

            userService.AddFilmToMyList("1");

            List<Film> myList = userService.GetMyList();

            Assert.AreEqual("Star Wars", myList[0].Name);

        }*/
    }
}
