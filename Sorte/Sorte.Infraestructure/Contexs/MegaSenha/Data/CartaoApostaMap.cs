using Sorteio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorte.Infraestructure.Contexs.MegaSenha.Data
{
    public class CartaoApostaMap : EntityTypeConfiguration<CartaoAposta>
    {
        public CartaoApostaMap()
        {
            ToTable("CARTAOAPOSTA");

            Property(x => x.Id)
            .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.QuantidadeNumerosAcetados)
              .IsOptional();

            Property(x => x.DataAposta)
            .IsOptional();

            Property(x => x.NomeApostador)
            .IsOptional();

            Property(x => x.NumerosApostados)
            .IsOptional();

            Property(x => x.NumerosAcertados)
            .IsOptional();

        }
    }
}
