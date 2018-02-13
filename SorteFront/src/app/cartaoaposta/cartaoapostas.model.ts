import { Data } from "@angular/router/src/config";

export class CartaoAposta{
    /*Dessa forma não precisa realizar o mapeamento de cada prop
    O TS ja faz o processo de bing.  */
        constructor(
            public Id:string,
            public DataAposta: Date,            
            public NomeApostador:string,
            public NumerosApostados:string,
            public NumerosAcertados:string,
            public quantidadeNumerosAcetados:number,            
            public Surpresinha:boolean 
        ){}

   }