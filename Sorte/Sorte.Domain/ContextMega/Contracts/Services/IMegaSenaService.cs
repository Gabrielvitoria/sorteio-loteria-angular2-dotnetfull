using Sorteio.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Sorte.Domain.ContextMega.Contracts.Services
{
    public interface IMegaSenaServico 
    {
        CartaoAposta CriarCartaoAposta(bool surpresinha, string numeros, string nomeApostador);

        List<CartaoAposta> RodarSorteioDefinindoGanhadores();

        List<CartaoAposta> ListarApostas();

        List<CartaoAposta> ListarGanhadores();

        List<SorteioLoteria> ListarSorteios();

        SorteioLoteria UltimoSorteio();
    }
}
