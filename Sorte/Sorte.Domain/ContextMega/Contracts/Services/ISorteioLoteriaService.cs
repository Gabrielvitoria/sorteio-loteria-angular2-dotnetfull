using Sorteio.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Sorte.Domain.ContextMega.Contracts.Services
{

    public interface ISorteioLoteriaServico 
    {
        SorteioLoteria Criar();
        SorteioLoteria UltimoSoterio();       
        List<SorteioLoteria> ListarSorteios();
    }
}
