import { Component, OnInit } from '@angular/core';
import { CartaoAposta } from 'app/cartaoaposta/cartaoapostas.model';
import { NgModel } from '@angular/forms';

import "rxjs/add/operator/toPromise";
import { Http } from '@angular/http';
import { porta } from 'environments/environment.prod';


declare var $: any;
@Component({
  selector: 'app-cartaoaposta',
  templateUrl: './cartaoaposta-novo.component.html',
  styleUrls: ['./cartaoaposta.componente.css']
})

export class CartaoapostaNovoComponent implements OnInit {
  private cartaoApostaUrl: string = 'http://localhost:'+ porta.endereco +'/api/aposta';

  numerosSelecionados: Array<number>[];
  numeros: Array<number>[];
  tipoCartaoApostaMega: boolean;
  tipoCartaoApostaSuper: boolean;
  cartaoaposta: CartaoAposta;
  cartaoapostaRetorno: CartaoAposta;

  constructor(
    private http: Http
  ) {
    this.cartaoaposta = new CartaoAposta('', null, '', '', '', 0, false);
    this.cartaoapostaRetorno = new CartaoAposta('', null, '', '', '', 0, false);
  }

  ngOnInit(): void {
    this.numerosSelecionados = [];
    this.numeros = [];

    var ctr = 0;

    for (var i = 0; i < 6; i++) {
      var row = [];
      for (var j = 0; j < 10; j++) {
        ctr++;
        row.push({ val: ctr })
      }
      this.numeros.push(row);
    }
  }

  onSelecionaTipoCartao(tipo): void {

    if (tipo.toElement.defaultValue == 'mega') {
      this.tipoCartaoApostaMega = true;
      this.tipoCartaoApostaSuper = false;
      this.cartaoaposta.Surpresinha = false;
    }
    else if (tipo.toElement.defaultValue == 'super') {
      this.tipoCartaoApostaMega = false;
      this.tipoCartaoApostaSuper = true;
      this.cartaoaposta.NumerosApostados = '';
      this.numerosSelecionados = [];
      this.cartaoaposta.Surpresinha = true;
    }
  }


  limparFormulario(): void {
    this.tipoCartaoApostaMega = false;
    this.tipoCartaoApostaSuper = false;
    this.cartaoaposta = new CartaoAposta('', null, '', '', '', 0, false);
    this.numerosSelecionados = [];
  }


  selecionarNumero(event, valorSelecao) {
    if (event.toElement.checked) {
      if (this.numerosSelecionados.length < 6) {
        this.numerosSelecionados.push(valorSelecao);
      }
      else {
        event.toElement.checked = false;
        this.showNotification("top", "right", "Ops'  Já selecionou 6 numeros.")
      }
    } else {
      this.numerosSelecionados.splice(this.numerosSelecionados.indexOf(valorSelecao), 1);
    }
  }

  confirmarCartao() {
    this.cartaoaposta.NumerosApostados = this.numerosSelecionados.length != 0 ? this.numerosSelecionados.toString() : '';
    this.PostApostas(this.cartaoaposta)
      .then((cartaoApostaRespose: CartaoAposta) => {
        this.cartaoapostaRetorno = cartaoApostaRespose;
        this.limparFormulario();
        this.showNotification("top", "right", "Cartao de aposta criado com sucesso!.", 2)
      });
  }

  PostApostas(cartao: CartaoAposta): Promise<CartaoAposta> {
    return this.http.post(this.cartaoApostaUrl, cartao)
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

  onSubmit(): void {
    this.confirmarCartao();
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
