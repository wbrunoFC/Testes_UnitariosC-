using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTest
    {
        [Fact]
        public void testLeilao()
        {
            var leilao = new Leilao("Van Gogh");
            var pessoa1 = new Interessada("Bruno", leilao);
            var pessoa2 = new Interessada("Maria", leilao);

            leilao.RecebeLance(pessoa1, 400);
            leilao.RecebeLance(pessoa2, 100);
            leilao.RecebeLance(pessoa1, 500);

            leilao.TerminaPregao();
            var valorEsperado = 500000;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
    
        }

        [Theory]
        [InlineData(1000, new double[] {800, 900})]
        [InlineData(1000, new double[] {800, 500})]
        [InlineData(800, new double[] { 800 })]
        public void leilaoComVariosLances(double valorEsperado, double[] ofertas)
        {
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Jonas", leilao);

            foreach(var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }
            leilao.TerminaPregao();
        }

        [Fact]
        public void testDeException()
        {
            // Cenario
            var leilao = new Leilao("Van Gogh");
            
            try
            {
                // Acao
                leilao.TerminaPregao();
            } 
            catch (System.Exception e)
            {
                // Verificacao
                Assert.IsType<System.InvalidOperationException>(e);
            }
        }
    }
}
