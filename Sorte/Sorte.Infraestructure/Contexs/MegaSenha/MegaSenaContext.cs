using Sorte.Infraestructure.Contexs.MegaSenha.Data;
using Sorteio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorte.Infraestructure.Contexs.MegaSenha
{
    public class MegaSenaContext : DbContext
    {
        public MegaSenaContext()
            : base("MegaConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false; //resolve proxy do objeto para renderizar json na webapi com objeto concreto
        }

        #region Declara os DbSet's

        public DbSet<CartaoAposta> CartaoApostas { get; set; }
        public DbSet<SorteioLoteria> SorteiroLoterias { get; set; }

        #endregion


        #region Chama os Map de entidade
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CartaoApostaMap());
            modelBuilder.Configurations.Add(new SoteioLoteriaMap());
        }
        #endregion
    }
}

