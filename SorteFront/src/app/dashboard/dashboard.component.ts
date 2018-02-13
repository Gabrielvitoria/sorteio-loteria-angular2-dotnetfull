import { Component, OnInit } from '@angular/core';
import * as Chartist from 'chartist';
declare var $: any;

import "rxjs/add/operator/toPromise";
import { Http } from '@angular/http';
import { CartaoAposta } from 'app/cartaoaposta/cartaoapostas.model';
import { forEach } from '@angular/router/src/utils/collection';
import { porta } from 'environments/environment.prod';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  private ganhadoresUrl: string = 'http://localhost:' + porta.endereco + '/api/ganhadores';

  ganhadores: CartaoAposta[];

  sena: number;
  quadra: number;
  quina: number;

  constructor(private http: Http) { }


  ngOnInit() {

    this.sena = 0;
    this.quadra = 0;
    this.quina = 0;

    this.RecuperarGanhadores();
  }


  RecuperarGanhadores(): void {

    this.GetGanhadores().then((response: CartaoAposta[]) => {
      this.ganhadores = response;
      
      for (var aposta of this.ganhadores) {
        if (aposta.quantidadeNumerosAcetados == 6)
          this.sena = +1;
        if (aposta.quantidadeNumerosAcetados == 5)
          this.quina = +1;
        if (aposta.quantidadeNumerosAcetados == 4)
            this.quadra =+ 1;
      }

    }).catch(err => {
      console.log('Aconteceu um erro:', err);
    })
  }



  private GetGanhadores(): Promise<CartaoAposta[]> {
    debugger;
    return this.http.get(this.ganhadoresUrl)
      .toPromise()
      .then(function (response) {
        return response.json();
      })
      .catch(this.handleErro);
  }

  private handleErro(err: any): Promise<any> {
    console.log('Error: ', err);
    return Promise.reject(err.menssage || err);
  }

  private showNotification(from, align, msg, tipo = 0): void {
    const type = ['', 'info', 'success', 'warning', 'danger'];

    const color = tipo == 0 ? Math.floor((Math.random() * 4) + 1) : tipo;

    $.notify({
      icon: "notifications",
      message: "Aviso <b>Loterias da sorte</b> </br> " + msg

    }, {
        type: type[color],
        timer: 100,
        placement: {
          from: from,
          align: align
        }
      });
  }

}
