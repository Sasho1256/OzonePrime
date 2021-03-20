using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using OzonePrime.Models;
using OzonePrime.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ozoneprimeTests
{
    class SettingTests
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
        public void TestSettingOfUsersRole()
        {
            UsersRole usersRole = new UsersRole();

            usersRole.UserId = 1;
            usersRole.User = new User();
            usersRole.RoleId = 1;
            usersRole.Role = new Role();

            Assert.AreEqual(1, usersRole.UserId);
        }

        [Test]
        public void TestSettingOfFilmDTO()
        {
            FilmDTO filmDTO = new FilmDTO();
            filmDTO.film = new Film();
            filmDTO.Directors = new List<Director>();
            filmDTO.Genres = new List<Genre>();

            FilmDTO filmDTO1 = new FilmDTO(new List<Director>(), new List<Genre>());

            FilmDTO filmDTO2 = new FilmDTO(new Film(), new List<Director>(), new List<Genre>());

            Assert.AreEqual(0, filmDTO1.Directors.Count);
        }

        [Test]
        public void TestSettingOfExMessDTO()
        {
            ExMessDTO exMessDTO = new ExMessDTO();
            exMessDTO.ExMess = "nishto";

            ExMessDTO exMessDTO1 = new ExMessDTO("nishto");
            
            Assert.AreEqual("nishto", exMessDTO1.ExMess);
        }

        [Test]
        public void TestSettingOfErrorViewModel()
        {
            ErrorViewModel errorViewModel = new ErrorViewModel();
            errorViewModel.RequestId = "nishto";            

            Assert.AreEqual(true, errorViewModel.ShowRequestId);
        }
    }
}
