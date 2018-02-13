import { Data } from "@angular/router/src/config";

export class Sorteio{
    /*Dessa forma não precisa realizar o mapeamento de cada prop
    O TS ja faz o processo de bing.  */
        constructor(
            public Id:string,
            public CodigoSorteio:string,
            public DataSorteio: Date,            
            public NumerosSorteados:string
        ){}

   }