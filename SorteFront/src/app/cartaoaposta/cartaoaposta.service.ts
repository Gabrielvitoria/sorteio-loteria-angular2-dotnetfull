/*# Injectable: Emite metadados para angular2 para identificar as outras dependencias 
    do contatoService e fazer a injeção de dependencia  */

/*# Style guide angular2 pede que seja decorada a classe mesmo que não tenha outras dependencias */

import { Injectable } from '@angular/core';

import { CartaoAposta } from './cartaoapostas.model';

import "rxjs/add/operator/toPromise";

import { Http } from '@angular/http';
import { porta } from 'environments/environment.prod';

@Injectable()
export class CartaoApostaService {

    private cartaoApostaUrl: string = 'localhost:'+ porta.endereco +'/api/aposta';

    constructor(
        private http: Http

    ) { }

    getApostas(): Promise<CartaoAposta[]> {
        return this.http.get(this.cartaoApostaUrl)
            .toPromise()
            .then(response => response.json().data as CartaoAposta[])
            .catch(this.handleErro);
    }

    postApostas(cartao: CartaoAposta): Promise<CartaoAposta> {
        return this.http.post(this.cartaoApostaUrl,cartao)
            .toPromise()
            .then(response => response.json().data as CartaoAposta)
            .catch(this.handleErro);
    }
 
    private handleErro(err: any): Promise<any> {
        console.log('Error: ', err);
        return Promise.reject(err.menssage || err);
    }
}