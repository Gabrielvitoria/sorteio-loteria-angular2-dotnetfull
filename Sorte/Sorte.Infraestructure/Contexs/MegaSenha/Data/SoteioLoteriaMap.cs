using Sorteio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorte.Infraestructure.Contexs.MegaSenha.Data
{
    public class SoteioLoteriaMap : EntityTypeConfiguration<SorteioLoteria>
    {
        public SoteioLoteriaMap()
        {
            ToTable("SORTEIOLOTERIAS");

            Property(x => x.Id)
            .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.CodigoSorteio)
            .IsOptional();

            Property(x => x.NumerosSorteados)
            .IsOptional();

            Property(x => x.DataSorteio)
            .IsOptional();
        }
    }
}
