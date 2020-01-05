using NinjaPlus.Common;
using NinjaPlus.Models;
using NinjaPlus.Pages;
using NUnit.Framework;

namespace NinjaPlus.Tests
{
    public class SaceMovieTest : BaseTest
    {
        private LoginPage _login;

        private MoviePage _movie;

        [SetUp]
        public void Before()
        {
            _login = new LoginPage(Browser);
            _movie = new MoviePage(Browser);
            _login.With("murillo.welsi@gmail.com", "Mw123456*");
        }

        [Test]
        public void ShouldSaveMovie()
        {
            var movieData = new MovieModel()
            {
                Title = "Gisaengchung",
                Status = "Disponível",
                Year = "2019",
                ReleaseDate = "10/10/2019",
                Plot = "All unemployed, Ki-taek and his family take peculiar interest in the wealthy and glamorous Parks, as they ingratiate themselves into their lives and get entangled in an unexpected incident."
            };

            _movie.Add();
            _movie.Save(movieData);
        }
    }
}