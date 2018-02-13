using Sorte.Domain.ContextMega.Contracts.Services;
using Sorte.Domain.ContextMega.Repositories;
using Sorteio.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Sorte.Business.Services
{
    public class SorteioLoteriaServico : ISorteioLoteriaServico
    {
        private ISorteioLoteriaRepositorio _sorteioLoteriaRepository;

        public SorteioLoteriaServico(ISorteioLoteriaRepositorio sorteioLoteriaRepository)
        {
            _sorteioLoteriaRepository = sorteioLoteriaRepository;
        }

        public SorteioLoteria Criar()
        {
            return _sorteioLoteriaRepository.Criar(new SorteioLoteria());
        }

        public List<SorteioLoteria> ListarSorteios()
        {
            return _sorteioLoteriaRepository.Listar();
        }

        public SorteioLoteria UltimoSoterio()
        {
         return   _sorteioLoteriaRepository.UltimoSoterio();
        }
    }
}
