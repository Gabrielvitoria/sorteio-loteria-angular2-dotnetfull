using Sorteio.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Sorte.Domain.ContextMega.Repositories
{
    public interface ISorteioLoteriaRepositorio 
    {
        SorteioLoteria Criar(SorteioLoteria sorteio);

        SorteioLoteria UltimoSoterio();

        List<SorteioLoteria> Listar();
    }
}
