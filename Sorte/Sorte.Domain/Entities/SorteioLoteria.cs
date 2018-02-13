using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using FluentValidator.Validation;

namespace Sorteio.Domain.Entities
{
    public class SorteioLoteria : Notifiable
    {
        public SorteioLoteria()
        {

            this.CodigoSorteio = Guid.NewGuid();
            this.DataSorteio = DateTime.Now;
            this.NumerosSorteados = GerarNumerosSorteio();

            if (string.IsNullOrEmpty(this.NumerosSorteados))
                AddNotifications(new ValidationContract()
                                .HasMaxLen(this.NumerosSorteados, 0, "Sorteio", "Sorteio não gerou números."));
        }

        public int Id { get; set; }
        public Guid CodigoSorteio { get; private set; }
        public DateTime DataSorteio { get; private set; }
        public string NumerosSorteados { get; private set; }


        internal string GerarNumerosSorteio()
        {
            //int Min = 1;
            //int Max = 60;

            //int[] retorno = new int[6];

            //Random randNum = new Random();
            //for (int i = 0; i < 6; i++)
            //{
            //    retorno[i] = randNum.Next(Min, Max);
            //}

            //return String.Join(",", retorno.Select(p => p.ToString()).ToArray());

            int qtd = 6;
            Random rd = new Random();
            List<int> numeros = new List<int>();
            int number = 0;
            for (int i = 0; i < qtd; i++)
            {
                number = rd.Next(1, qtd + 1);
                while (numeros.Contains(number))
                {
                    if (numeros.Count >= qtd) // quando ficar em loop infinito vou quebrar o laço                        
                        break;
                    else
                        number = rd.Next(1, qtd + 1);
                }
                numeros.Add(number);
            }

            int[] retorno = numeros.ToArray();

            return String.Join(",", retorno.Select(p => p.ToString()).ToArray());;
        }

        public int[] ConvertarNumerosArray()
        {
            int[] array = !string.IsNullOrEmpty(this.NumerosSorteados) ? this.NumerosSorteados.Split(',').Select(n => Convert.ToInt32(n)).ToArray() : new int[] { };

            return array;
        }

    }



}