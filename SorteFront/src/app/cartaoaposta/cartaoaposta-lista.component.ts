import { Component, OnInit } from '@angular/core';
import { CartaoAposta } from 'app/cartaoaposta/cartaoapostas.model';
import "rxjs/add/operator/toPromise";
import { Http } from '@angular/http';
import { porta } from 'environments/environment.prod';
declare var $: any;

@Component({
  selector: 'app-cartaoaposta',
  templateUrl: './cartaoaposta-lista.componente.html',
  styleUrls: ['./cartaoaposta.componente.css']
})

export class CartaoApostaListaComponent implements OnInit {
  private cartaoApostaUrl: string = 'http://localhost:' + porta.endereco + '/api/aposta';
  cartaoApostas: CartaoAposta[];

  constructor(
    private http: Http
  ) {
  }

  ngOnInit() {


    this.GetApostas().then((cartaoAposta: CartaoAposta[]) => {
      this.cartaoApostas = cartaoAposta;
    }).catch(err => {
      console.log('Aconteceu um erro:', err);
    })


  }

  GetApostas(): Promise<CartaoAposta[]> {
    return this.http.get(this.cartaoApostaUrl)
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
