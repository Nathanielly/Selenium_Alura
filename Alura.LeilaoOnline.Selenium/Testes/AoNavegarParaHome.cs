using Alura.LeilaoOnline.Selenium.Fixture;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;


namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome : IClassFixture<TesteFixture>
    {
        private IWebDriver driver;

        //setup - inicializa��o de testes
        public AoNavegarParaHome(TesteFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            //arrange - navegador isolado, na constru��o da classe


            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Leil�es", driver.Title);


        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarNovosLeiloesNaPagina()
        {
            //arrange - navegador isolado, na constru��o da classe


            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Pr�ximos Leil�es", driver.PageSource);



        }

        [Fact]
        public void DadoChromeAbertoFormularioDeRegistroNaoDeveMostrarMensagemDeErro()
        {
            //arrange - navegador isolado na constru��o da classe

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert 
            var form = driver.FindElement(By.TagName("form"));
            var spans = form.FindElements(By.TagName("span"));
            foreach(var span in spans)
            {
                Assert.True(string.IsNullOrEmpty(span.Text));
            }


        }

    }
}