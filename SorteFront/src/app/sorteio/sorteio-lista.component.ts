import { Component, OnInit } from '@angular/core';

import "rxjs/add/operator/toPromise";
import { Http } from '@angular/http';
import { Sorteio } from 'app/sorteio/sorteio.model';
import { porta } from 'environments/environment.prod';

declare var $: any;

@Component({
  selector: 'app-sorteio',
  templateUrl: './sorteio-lista.component.html',
  styleUrls: ['./sorteio.componente.css']
})

export class SorteioListaListaComponent implements OnInit {

  private sorteiosUrl: string = 'http://localhost:' + porta.endereco + '/api/sorteio';
  private UltimoSorteiosUrl: string = 'http://localhost:' + porta.endereco + '/api/ultimosorteio';
  private SortearUrl: string = 'http://localhost:' + porta.endereco + '/api/sorteio';

  sorteios: Sorteio[];
  ultimoSorteios: Sorteio;

  constructor(
    private http: Http
  ) {
  }

  ngOnInit() {
    this.ultimoSorteios = new Sorteio("", "", null, "");
    this.RecuperarSorteios();
    this.RecuperarUltimoSorteio();
  }

  Sortear() {

    this.PostSortear()
      .then((sorteio: Sorteio) => {
        this.ultimoSorteios = sorteio;
        this.showNotification("top", "right", "Sorteio de aposta criado com sucesso!.", 2);
        this.RecuperarSorteios();
        this.RecuperarUltimoSorteio();
      });
  }

  RecuperarSorteios(): void {
    this.GetSorteios().then((sorteio: Sorteio[]) => {
      this.sorteios = sorteio;
    }).catch(err => {
      console.log('Aconteceu um erro:', err);
    })
  }

  RecuperarUltimoSorteio(): void {
    this.GetUltimoSorteio().then((response: Sorteio) => {
      this.ultimoSorteios = response;
    }).catch(err => {
      console.log('Aconteceu um erro:', err);
    })
  };

  private GetSorteios(): Promise<Sorteio[]> {
    return this.http.get(this.sorteiosUrl)
      .toPromise()
      .then(function (response) {
        return response.json();
      })
      .catch(this.handleErro);
  }

  private GetUltimoSorteio(): Promise<Sorteio> {
    return this.http.get(this.UltimoSorteiosUrl)
      .toPromise()
      .then(function (response) {
        return response.json();
      })
      .catch(this.handleErro);
  }

  private PostSortear(): Promise<Sorteio> {
    return this.http.post(this.SortearUrl, null)
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
