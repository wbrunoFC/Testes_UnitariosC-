using System;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOline.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var leilao = new Leilao("Van Gogh");
            var pessoa1 = new Interessada("Bruno", leilao);
            var pessoa2 = new Interessada("Maria", leilao);

            leilao.RecebeLance(pessoa1, 400);
            leilao.RecebeLance(pessoa2, 100);
            leilao.RecebeLance(pessoa1 , 500);

            leilao.TerminaPregao();
            Console.WriteLine(leilao.Ganhador.Valor);
        }
    }
}
