using Sorte.Domain.ContextMega.Contracts.Services;
using Sorte.Domain.ContextMega.Repositories;
using Sorteio.Domain.Entities;
using System.Collections.Generic;

namespace Sorte.Business.Services
{
    public class CartaoApostaServico : ICartaoApostaServico
    {
        private ICartaoApostaRepositorio _cartaoApostaRepository;

        public CartaoApostaServico(ICartaoApostaRepositorio cartaoApostaRepository)
        {
            _cartaoApostaRepository = cartaoApostaRepository;

        }


        public List<CartaoAposta> Listar()
        {
          return _cartaoApostaRepository.Listar();
        }

        public CartaoAposta Criar(CartaoAposta cartaoAPosta)
        {
           return _cartaoApostaRepository.Criar(cartaoAPosta);
        }

        public List<CartaoAposta> ListarGanhadores()
        {
            return _cartaoApostaRepository.ListaGanhadores();
        }

        public void Atualizar(CartaoAposta aposta)
        {
            _cartaoApostaRepository.Atualziar(aposta);
        }

    }
}
