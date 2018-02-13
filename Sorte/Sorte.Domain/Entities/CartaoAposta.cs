using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Linq;

namespace Sorteio.Domain.Entities
{

    public class CartaoAposta : Notifiable
    {
    
        public string Id { get; private set; }
        public DateTime DataAposta { get; private set; }
        public string NomeApostador { get; private set; }
        public string NumerosApostados { get; private set; }
        public string NumerosAcertados { get; private set; }
        public int QuantidadeNumerosAcetados { get; private set; }

        public CartaoAposta()
        {

        }

        public CartaoAposta(bool surpresinha, string nomeApostador)
        {
            if (surpresinha)
            {
                this.Id = Guid.NewGuid().ToString();
                this.DataAposta = DateTime.Now;
                this.NomeApostador = nomeApostador;
                this.NumerosApostados = GerarNumerosSurpresinha();
            }
            else
            {
                AddNotifications(new ValidationContract()
                                      .HasMaxLen("", 0, "Surpresinha", "Falha ao gerar surpresinha"));
            }
        }

        public void DefinirQuantidadeAcertos(int quantidade)
        {
            this.QuantidadeNumerosAcetados = quantidade;
        }

        public CartaoAposta(string numeros, string nomeApostador)
        {
            var numerosApostados = ConvertarNumerosArray(numeros);

            var duplicados = numerosApostados.GroupBy(x => x)
                        .Where(x => x.Count() > 1)
                        .Select(x => x.Key)
                        .ToList();

            if (duplicados.Count > 0)
            {
                AddNotifications(new ValidationContract()
                                      .HasMaxLen(duplicados.Count.ToString(), 0, "Números", "Números repetidos não são permitidos"));

            }
            else if (numerosApostados.Count() == 0 || numerosApostados.Count() > 6)
            {
                AddNotifications(new ValidationContract()
                      .HasMinLen(numerosApostados.Count().ToString(), 0, "Números", "Quantidade de números mínimo não permitido de 1 - 6.")
                      .HasMaxLen(numerosApostados.Count().ToString(), 0, "Números", "Quantidade de números máxima não permitido de 1 - 6."));
            }
            else
            {
                this.Id = Guid.NewGuid().ToString();
                this.DataAposta = DateTime.Now;
                this.NomeApostador = nomeApostador;
                this.NumerosApostados = numeros;
            }
        }


        internal string GerarNumerosSurpresinha()
        {
            int Min = 1;
            int Max = 60;

            int[] retorno = new int[6];

            Random randNum = new Random();
            for (int i = 0; i < 6; i++)
            {
                retorno[i] = randNum.Next(Min, Max);
            }

            return String.Join(",", retorno.Select(p => p.ToString()).ToArray());
        }

        public int[] ConvertarNumerosArray(string numeros)
            {

            int[] array = !string.IsNullOrEmpty(numeros) ? numeros.Split(',').Select(n => Convert.ToInt32(n)).ToArray() : new int[] { };

            return array;
        }
        public int[] ConvertarNumerosArray()
        {

            int[] array = !string.IsNullOrEmpty(this.NumerosApostados) ? this.NumerosApostados.Split(',').Select(n => Convert.ToInt32(n)).ToArray() : new int[] { };

            return array;
        }


    }


}