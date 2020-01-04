using Coypu.Drivers;
using NinjaPlus.Common;
using NinjaPlus.Pages;
using NUnit.Framework;

namespace NinjaPlus.Tests
{
    public class LoginTests : BaseTest
    {
        private LoginPage _login;
        private Sidebar _side;

        [SetUp]
        public void Start()
        {
            _login = new LoginPage(Browser);
            _side = new Sidebar(Browser); 
        }

        [Test]
        [Category("Critical")]
        public void ShouldSeeLoggedUser()
        {
            _login.With("murillo.welsi@gmail.com","Mw123456*");
            Assert.AreEqual("Murillo Welsi de Souza Pereira", _side.LoggedUser());
        }

        [TestCase("murillo.welsi@gmail.com","123456","Usuário e/ou senha inválidos")]
        [TestCase("murillo.welsi-mail.com","Mw123456*","Usuário e/ou senha inválidos")]
        [TestCase("","Mw123456*","Opps. Cadê o email?")]
        [TestCase("murillo.welsi@gmail.com","","Opps. Cadê a senha?")]
        public void ShoudSeeAlertMessage(string email, string pass, string expectedMessage)
        {
            _login.With(email, pass);
            Assert.AreEqual(expectedMessage, _login.AlertMessage());
        }
    }
}


// Buscando o elemento pelo name 
            // browser.FillIn("email").With("murillo.welsi@gmail.com");
            // browser.FillIn("password").With("Mw123456*");
            
            // Buscando o elemento pelo id
            // browser.FillIn("emailId").With("murillo.welsi@gmail.com");
            // browser.FillIn("passId").With("Mw123456*");
            
            // Buscando o elemento pelo CSS Selector
            // browser.FindCss("input[placeholder='nome@gmail.com']").SendKeys("murillo.welsi@gmail.com");
            // browser.FindCss("input[placeholder=senha]").SendKeys("Mw123456*");
            // browser.ClickButton("Entrar");