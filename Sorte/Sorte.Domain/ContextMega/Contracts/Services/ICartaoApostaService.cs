using Sorteio.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Sorte.Domain.ContextMega.Contracts.Services
{
    public interface ICartaoApostaServico 
    {
        CartaoAposta Criar(CartaoAposta cartaoAPosta);

        List<CartaoAposta> Listar();

        List<CartaoAposta> ListarGanhadores();

        void Atualizar(CartaoAposta aposta);
    }
}
