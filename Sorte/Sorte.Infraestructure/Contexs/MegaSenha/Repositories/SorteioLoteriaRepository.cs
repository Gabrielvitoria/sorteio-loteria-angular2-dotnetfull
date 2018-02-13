
using LiteDB;
using Sorte.Domain.ContextMega.Repositories;
using Sorteio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorte.Infraestructure.Contexs.MegaSenha.Repositories
{
    public class SorteioLoteriaRepositorio : ISorteioLoteriaRepositorio
    {
        public SorteioLoteria Criar(SorteioLoteria sorteio)
        {
            return TabelaSorteio.Criar(sorteio);
        }

        public List<SorteioLoteria> Listar()
        {
            return TabelaSorteio.Listar();
        }

        public SorteioLoteria UltimoSoterio()
        {
            return TabelaSorteio.UltimoSoterio();
        }
    }


    internal class TabelaSorteio
    {
        public static SorteioLoteria Criar(SorteioLoteria sorteio)
        {
            using (var db = new LiteDatabase(@"C:\Temp\Loteria.db"))
            {
                var sorteioDb = db.GetCollection<SorteioLoteria>("SorteioLoteria");
                sorteioDb.Insert(sorteio);
            }
            return sorteio;
        }

        public static List<SorteioLoteria> Listar()
        {
            var lista = new List<SorteioLoteria>();

            using (var db = new LiteDatabase(@"C:\Temp\Loteria.db"))
            {
                var sorteios = db.GetCollection<SorteioLoteria>("SorteioLoteria");

                foreach (var item in sorteios.FindAll())
                {
                    lista.Add(item);
                }
            }
            return lista;
        }

        public static SorteioLoteria UltimoSoterio()
        {
            using (var db = new LiteDatabase(@"C:\Temp\Loteria.db"))
            {
                var sorteio = db.GetCollection<SorteioLoteria>("SorteioLoteria")
                           .FindAll().FirstOrDefault(x => x.DataSorteio <= DateTime.Now)
;

                return sorteio;
            }
        }
    }
}
