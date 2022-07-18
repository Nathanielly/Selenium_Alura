using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.Fixture
{
    public class TesteFixture: IDisposable
    {
        public IWebDriver Driver { get; private set; }

        //Setup - inicializar
        public TesteFixture()
        {
            Driver = new ChromeDriver();
        }

        //TearDown - fechar o navegador
        public void Dispose()
        {
            Driver.Quit();
        }



    }
}
