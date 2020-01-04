using System;
using Coypu;
using Coypu.Drivers;
using Coypu.Drivers.Selenium;
using NUnit.Framework;

namespace NinjaPlus.Common
{
    public class BaseTest
    {
        // propriedade publica => public (pode ser acessada por qualquer cód, até mesmo outro projeto)
        // propriedade privada => private (pode ser acessada somente pela classe que ela está)
        // propriedade protegida => protected (ela pode ser acessada somente por ela ou por um filho herdado)

        // public String nome;
        // private String _nome;
        // protected String Nome;

        protected BrowserSession Browser;
        
        [SetUp]
        public void Setup()
        {
            var configs = new SessionConfiguration
            {
                AppHost = "http://ninjaplus-web",
                Port = 5000,
                SSL = false,
                Driver = typeof(SeleniumWebDriver),
                Browser = Coypu.Drivers.Browser.Chrome,
                Timeout = TimeSpan.FromSeconds(10)
            };

            Browser = new BrowserSession(configs);
            
            Browser.MaximiseWindow();
        }

        [TearDown]
        public void Finish()
        {
            Browser.Dispose();
        }
    }
}