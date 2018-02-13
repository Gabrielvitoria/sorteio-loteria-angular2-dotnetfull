using LiteDB;
using Sorte.Domain.ContextMega.Repositories;
using Sorteio.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Sorte.Infraestructure.Contexs.MegaSenha.Repositories
{
    public class CartaoApostaRepositorio : ICartaoApostaRepositorio
    {

        public CartaoAposta Criar(CartaoAposta cartaoAposta)
        {
            return TabelaAposta.Criar(cartaoAposta);
        }

        public List<CartaoAposta> Listar()
        {
            return TabelaAposta.Listar();
        }

        public List<CartaoAposta> ListaGanhadores()
        {
            return TabelaAposta.ListarGanhadores();
        }

        public void Atualziar(CartaoAposta aposta)
        {
            TabelaAposta.Atualizar(aposta);
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }

    internal class TabelaAposta
    {
        public static CartaoAposta Criar(CartaoAposta aposta)
        {
            using (var db = new LiteDatabase(@"C:\Temp\Loteria.db"))
            {
                var cartaoAposta = db.GetCollection<CartaoAposta>("CartaoAposta");
                cartaoAposta.Insert(aposta);
            }
            return aposta;
        }

        public static List<CartaoAposta> Listar()
        {
            var lista = new List<CartaoAposta>();

            using (var db = new LiteDatabase(@"C:\Temp\Loteria.db"))
            {
                var cartaoAposta = db.GetCollection<CartaoAposta>("CartaoAposta");

                foreach (var item in cartaoAposta.FindAll() )
                {
                    lista.Add(item);
                }
            }
            return lista.OrderBy(x=> x.DataAposta).ToList();
        }

        public static List<CartaoAposta> ListarGanhadores()
        {
            var lista = new List<CartaoAposta>();

            using (var db = new LiteDatabase(@"C:\Temp\Loteria.db"))
            {
                var cartaoAposta = db.GetCollection<CartaoAposta>("CartaoAposta");

                foreach (var item in cartaoAposta.FindAll())
                {
                    if(item.QuantidadeNumerosAcetados >= 4)
                        lista.Add(item);
                }
            }
            return lista;
        }

        public static void Atualizar(CartaoAposta aposta)
        {
            using (var db = new LiteDatabase(@"C:\Temp\Loteria.db"))
            {
                var cartaoAposta = db.GetCollection<CartaoAposta>("CartaoAposta");

                cartaoAposta.Update(aposta);
            }

        }
       
    }
}
