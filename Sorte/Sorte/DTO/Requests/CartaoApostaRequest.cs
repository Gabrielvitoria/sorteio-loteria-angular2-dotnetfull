using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sorte.DTO.Requests
{
    public class CartaoApostaRequest
    {
        public string NomeApostador { get; set; }
        public string NumerosApostados { get; set; }
        public bool Surpresinha { get; set; }
    }
}