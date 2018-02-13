##  sorteio-loteria-dotnetcore-angular
Projeto para simular sorteio de cartões de loteria em .NET e Angular.


#Lib's
- FluentValidator e Notifiable para validações e mensagens;
- LiteDB embarcado (Certifique que na raiz do disco exista a pasta c:\temp)

## BACK-END
- DDD
- Domain notifications
- LiteBd Embarcado para demonstração


## FRONT-END
- Baseado no projeto Material Dashboard Angular creative-tim
- [Download from Creative Tim](http://www.creative-tim.com/product/material-dashboard-angular2).
- 

## Terminal Commands
Front-End gerado com [Angular CLI](https://github.com/angular/angular-cli) version 1.0.0 and angular 4.x.
1. Instale NodeJs em [NodeJs Official Page](https://nodejs.org/en).
2. Abra terminal
3. Navegue até a pasta do projeto de FRONT-END
4. Certifique-se de ter instalado [Angular CLI](https://github.com/angular/angular-cli) já. Se não, por favor instale.
5. Nor terminal execute: ```npm install```
6. Rode o servidor  `ng serve` com npm start. Navegue para `http://localhost:4200/`. A APlicação atualiza automaticamente as alterações feitas nos arquivos.

7. para ajustar a porta da api alterar o endereço no arquivo environment.prod.ts 
>...\sorteio-loteria-angular2-dotnetfull\SorteFront\src\environments\environment.prod.ts


Para obter ajuda com o Angular CLI utilize `ng help` ou acesse a pagina do git [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
### O que está incluido no Front-End
Projeto está estrutura da seguinte forma:

```
md-free-angular-cli
├── CHANGELOG.md
├── LICENSE.md
├── README.md
├── angular-cli.json
├── documentation
├── e2e
├── karma.conf.js
├── package.json
├── protractor.conf.js
├── src
│   ├── app
│   │   ├── app.component.css
│   │   ├── app.component.html
│   │   ├── app.component.spec.ts
│   │   ├── app.component.ts
│   │   ├── app.module.ts
│   │   ├── app.routing.ts
│   │   ├── components
│   │   │   ├── components.module.ts
│   │   │   ├── footer
│   │   │   │   ├── footer.component.css
│   │   │   │   ├── footer.component.html
│   │   │   │   ├── footer.component.spec.ts
│   │   │   │   └── footer.component.ts
│   │   │   ├── navbar
│   │   │   │   ├── navbar.component.css
│   │   │   │   ├── navbar.component.html
│   │   │   │   ├── navbar.component.spec.ts
│   │   │   │   └── navbar.component.ts
│   │   │   └── sidebar
│   │   │       ├── sidebar.component.css
│   │   │       ├── sidebar.component.html
│   │   │       ├── sidebar.component.spec.ts
│   │   │       └── sidebar.component.ts
│   │   ├── dashboard
│   │   │   ├── dashboard.component.css
│   │   │   ├── dashboard.component.html
│   │   │   ├── dashboard.component.spec.ts
│   │   │   └── dashboard.component.ts
│   │   ├── icons
│   │   │   ├── icons.component.css
│   │   │   ├── icons.component.html
│   │   │   ├── icons.component.spec.ts
│   │   │   └── icons.component.ts
│   │   ├── maps
│   │   │   ├── maps.component.css
│   │   │   ├── maps.component.html
│   │   │   ├── maps.component.spec.ts
│   │   │   └── maps.component.ts
│   │   ├── notifications
│   │   │   ├── notifications.component.css
│   │   │   ├── notifications.component.html
│   │   │   ├── notifications.component.spec.ts
│   │   │   └── notifications.component.ts
│   │   ├── table-list
│   │   │   ├── table-list.component.css
│   │   │   ├── table-list.component.html
│   │   │   ├── table-list.component.spec.ts
│   │   │   └── table-list.component.ts
│   │   ├── typography
│   │   │   ├── typography.component.css
│   │   │   ├── typography.component.html
│   │   │   ├── typography.component.spec.ts
│   │   │   └── typography.component.ts
│   │   ├── upgrade
│   │   │   ├── upgrade.component.css
│   │   │   ├── upgrade.component.html
│   │   │   ├── upgrade.component.spec.ts
│   │   │   └── upgrade.component.ts
│   │   └── user-profile
│   │       ├── user-profile.component.css
│   │       ├── user-profile.component.html
│   │       ├── user-profile.component.spec.ts
│   │       └── user-profile.component.ts
│   ├── assets
│   │   ├── css
│   │   ├── img
│   │   └── sass
│   │       ├── material-dashboard.scss
│   │       └── md
│   ├── environments
│   ├── favicon.ico
│   ├── index.html
│   ├── main.ts
│   ├── polyfills.ts
│   ├── styles.css
│   ├── test.ts
│   ├── tsconfig.app.json
│   ├── tsconfig.spec.json
│   └── typings.d.ts
├── tsconfig.json
├── tslint.json
└── typings

```


