using Sorte.Business.Services;
using Sorte.Domain.ContextMega.Contracts.Services;
using Sorte.Domain.ContextMega.Repositories;
using Sorte.Infraestructure.Contexs.MegaSenha;
using Sorte.Infraestructure.Contexs.MegaSenha.Repositories;
using Sorteio.Domain.Entities;
using Unity;
using Unity.Lifetime;

namespace Sorte.Startup
{
    public class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {

            container.RegisterType<IMegaSenaService, MegaSenhaService>();

            #region Contexs
            //container.RegisterType<MegaSenaContext, MegaSenaContext>(new HierarchicalLifetimeManager());
            #endregion

            #region Entidades
            //container.RegisterType<CartaoAposta, CartaoAposta>(new HierarchicalLifetimeManager());
            //container.RegisterType<SorteioLoteria, SorteioLoteria>(new HierarchicalLifetimeManager());

            #endregion

            #region Services Business
            container.RegisterType<IMegaSenaService, MegaSenhaService>(new HierarchicalLifetimeManager());
            container.RegisterType<ISorteioLoteriaService, SorteioLoteriaService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICartaoApostaService, CartaoApostaService>(new HierarchicalLifetimeManager());
            #endregion

            #region Repositories
            //container.RegisterType<ICartaoApostaRepository, CartaoApostaRepository>(new HierarchicalLifetimeManager());
            //container.RegisterType<ISorteioLoteriaRepository, SorteioLoteriaRepository>(new HierarchicalLifetimeManager());
            #endregion



        }
    }
}
