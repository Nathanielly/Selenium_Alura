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

        //setup - inicialização de testes
        public AoNavegarParaHome(TesteFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            //arrange - navegador isolado, na construção da classe


            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Leilões", driver.Title);


        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarNovosLeiloesNaPagina()
        {
            //arrange - navegador isolado, na construção da classe


            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Próximos Leilões", driver.PageSource);



        }

        [Fact]
        public void DadoChromeAbertoFormularioDeRegistroNaoDeveMostrarMensagemDeErro()
        {
            //arrange - navegador isolado na construção da classe

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