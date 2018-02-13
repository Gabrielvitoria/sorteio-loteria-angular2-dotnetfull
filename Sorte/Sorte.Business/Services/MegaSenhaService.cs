using Sorte.Domain.ContextMega.Contracts.Services;
using Sorteio.Domain.Entities;
using System.Collections.Generic;
using System;

namespace Sorte.Business.Services
{
    public class MegaSenaServico : IMegaSenaServico
    {
        private ISorteioLoteriaServico _sorteioLoteriaService;
        private ICartaoApostaServico _cartaoApostaService;

        public MegaSenaServico(ISorteioLoteriaServico sorteioLoteriaService, ICartaoApostaServico cartaoApostaService)
        {
            _sorteioLoteriaService = sorteioLoteriaService;
            _cartaoApostaService = cartaoApostaService;
        }

        public CartaoAposta CriarCartaoAposta(bool surpresinha, string numeros, string nomeApostador)
        {
            var aposta = surpresinha ? new CartaoAposta(true, nomeApostador) : new CartaoAposta(numeros, nomeApostador);
            _cartaoApostaService.Criar(aposta);
            return aposta;
        }

        internal SorteioLoteria CriarSorteioLoteria()
        {
            return _sorteioLoteriaService.Criar();
        }

        public List<CartaoAposta> ListarApostas()
        {
            return _cartaoApostaService.Listar();
        }

        public List<CartaoAposta> RodarSorteioDefinindoGanhadores()
        {
            //_sorteioLoteriaService.Criar();

            var ganhadores = new List<CartaoAposta>();
            var cartoes = _cartaoApostaService.Listar();
            var sorteio = _sorteioLoteriaService.UltimoSoterio();
            if (sorteio == null)
                sorteio = _sorteioLoteriaService.Criar();

            var numerosSorteados = sorteio.ConvertarNumerosArray();

            foreach (var item in cartoes)
            {
                var numerosCartao = item.ConvertarNumerosArray();
                var acertos = 0;

                foreach (var nSorteados in numerosSorteados)
                {
                    for (int i = 0; i < numerosCartao.Length; i++)
                    {
                        if (numerosCartao[i] == nSorteados)
                        {
                            acertos += 1;
                        }
                    }
                }               

              
                    item.DefinirQuantidadeAcertos(acertos);
                    _cartaoApostaService.Atualizar(item);
                    ganhadores.Add(item);
                                  
            }

            return ganhadores;
        }

        public List<CartaoAposta> ListarGanhadores()
        {
            return _cartaoApostaService.ListarGanhadores();
        }

        public List<SorteioLoteria> ListarSorteios()
        {
            return _sorteioLoteriaService.ListarSorteios();
        }

        public SorteioLoteria UltimoSorteio()
        {
            return _sorteioLoteriaService.UltimoSoterio();
        }
    }
}
