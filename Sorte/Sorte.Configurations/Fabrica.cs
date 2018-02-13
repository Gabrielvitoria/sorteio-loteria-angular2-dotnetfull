using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorte.Configurations
{
    public static class Fabrica
    {
        private static StandardKernel StandardKernel { get; set; }

        static Fabrica()
        {
            StandardKernel = new StandardKernel(new Modulos());
        }

        public static TEntidade Obter<TEntidade>()
        {
            return StandardKernel.Get<TEntidade>();
        }

    }

   
}
