using Sorteio.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Sorte.Domain.ContextMega.Repositories
{
    public interface ICartaoApostaRepositorio : IDisposable
    {
        CartaoAposta Criar(CartaoAposta cartaoAposta);

        List<CartaoAposta> Listar();

        List<CartaoAposta> ListaGanhadores();

        void Atualziar(CartaoAposta aposta);

    }
}
