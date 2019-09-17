using Senai.ShirtStore.WebApi.Domains;
using Senai.ShirtStore.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Repositories
{
    public class TamanhosRepository : ITamanhoRepository
    {
        public List<Tamanhos> Listar()
        {
            using (ShirtStoreContext ctx = new ShirtStoreContext())
            {
                return ctx.Tamanhos.ToList();
            }
        }
    }
}
