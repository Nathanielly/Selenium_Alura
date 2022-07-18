using Alura.LeilaoOnline.Selenium.Fixture;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TesteFixture fixture)
        {
            driver = fixture.Driver;
            
        }

        [Fact]
        public void DadoInformacoesValidasRedirecionarParaPaginaDeAgradecimento()
        {
            //arrange - dado chrome aberto, página inicial do sistema de leilões
            driver.Navigate().GoToUrl("Http://localhost:5000");

                //nome
                var inputNome = driver.FindElement(By.Id("Nome"));

                //email
                var inputEmail = driver.FindElement(By.Id("Email"));

                //password
                var inputPassword = driver.FindElement(By.Id("Password"));

                //confirmPassword
                var inputConfirmPassword = driver.FindElement(By.Id("ConfirmPassword"));

                //botão para registrar
                var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

                //Passar valor para os campos
                inputNome.SendKeys("Nathanielly Oliveira");
                inputEmail.SendKeys("nathanielly23@hotmail.com");
                inputPassword.SendKeys("123");
                inputConfirmPassword.SendKeys("123");



            //act - efetuar o registro
            botaoRegistro.Click();

            //assert - deve ser redirecionado para página de agradecimento.
            Assert.Contains("Obrigado", driver.PageSource);

        }

        [Theory]
        [InlineData("", "nathanielly23@hotmail.com", "123", "123")]
        [InlineData("Nathanielly", "", "123", "123")]
        [InlineData("Nathanielly", "nathanielly23@hotmail.com", "", "123")]
        [InlineData("Nathanielly", "nathanielly23@hotmail.com", "123", "456")]
        public void DadoInformacoesInvalidasManterNaHome(string nome, string email, string password, string confirmPassword)
        {
            //arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            var inputNome = driver.FindElement(By.Id("Nome"));
            var inputEmail = driver.FindElement(By.Id("Email"));
            var inputPassword = driver.FindElement(By.Id("Password"));
            var inputConfirmPassword = driver.FindElement(By.Id("ConfirmPassword"));

            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys(nome);
            inputEmail.SendKeys(email);
            inputPassword.SendKeys(password);
            inputConfirmPassword.SendKeys(confirmPassword);

            //act
            botaoRegistro.Click();

            //assert
            Assert.Contains("section-registro", driver.PageSource);

        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            //act
            botaoRegistro.Click();


            //assert
            IWebElement elemento = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome]"));

            Assert.Equal("The Nome field is required.",elemento.Text);
        }

        [Fact]
        public void DadoEmailEmBrancoDeveMostrarMensagemDeErro()
        {
            //arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            //act
            botaoRegistro.Click();

            //assert
            IWebElement elemento = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Email]"));

            Assert.Equal("The Endereço de Email field is required.",elemento.Text);


        }

        [Fact]
        public void DadoSenhaEmBrancoMostrarMensagemDeErro()
        {
            //arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            //act
            botaoRegistro.Click();

            //assert
            IWebElement elemento = driver.FindElement(By.Id("Password-error"));
            Assert.Equal("The Senha field is required.",elemento.Text);

        }

        [Fact]
        public void DadoConfirmacaoSenhaEmBrancoMostrarMensagemDeErro()
        {
            //arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            //act
            botaoRegistro.Click();

            //assert
            IWebElement elemento = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=ConfirmPassword]"));
            Assert.Equal("The Confirmação de Senha field is required.",elemento.Text);


        }


    }

}
