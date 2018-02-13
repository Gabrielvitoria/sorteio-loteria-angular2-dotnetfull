using Ninject.Modules;
using Sorte.Business.Services;
using Sorte.Domain.ContextMega.Contracts.Services;
using Sorte.Domain.ContextMega.Repositories;
using Sorte.Infraestructure.Contexs.MegaSenha.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorte.Configurations
{
    public class Modulos : NinjectModule
    {
        public override void Load()
        {
            Servicos();
            Repositorios();
        }    

        public void Servicos()
        {
            Bind<IMegaSenaServico>().To<MegaSenaServico>();
            Bind<ISorteioLoteriaServico>().To<SorteioLoteriaServico>();
            Bind<ICartaoApostaServico>().To<CartaoApostaServico>();
        }

        public void Repositorios()
        {
            Bind<ICartaoApostaRepositorio>().To<CartaoApostaRepositorio>();
            Bind<ISorteioLoteriaRepositorio>().To<SorteioLoteriaRepositorio>();
        }


    }
}

