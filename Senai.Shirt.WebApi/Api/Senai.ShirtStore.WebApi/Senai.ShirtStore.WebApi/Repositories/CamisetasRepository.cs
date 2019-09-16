using Senai.ShirtStore.WebApi.Domains;
using Senai.ShirtStore.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Repositories
{
    public class CamisetasRepository : ICamisetasRepository
    {
        public void Atualizar(Camisetas camisetas)
        {
            using (ShirtStoreContext ctx = new ShirtStoreContext())
            {
                Camisetas CamisetasBuscadas = ctx.Camisetas.FirstOrDefault(x => x.IdCamiseta == camisetas.IdCamiseta);
                CamisetasBuscadas.Empresas = camisetas.Empresas;
                CamisetasBuscadas.Descriçao = camisetas.Descriçao;
                CamisetasBuscadas.Estoques = camisetas.Estoques;
                ctx.Camisetas.Update(CamisetasBuscadas);
                ctx.SaveChanges();
            }
        }


        public Camisetas BuscarPorId(int id)
        {
            using (ShirtStoreContext ctx = new ShirtStoreContext())
            {
                return ctx.Camisetas.FirstOrDefault(x => x.IdCamiseta == id);
            }
        }


        public void Cadastrar(Camisetas camisetas)
        {
            using (ShirtStoreContext ctx = new ShirtStoreContext())
            {
                ctx.Add(camisetas);
                ctx.SaveChanges();
            }
        }


        public void Deletar(int id)
        {
            using (ShirtStoreContext ctx = new ShirtStoreContext())
            {
                Camisetas camisetas = ctx.Camisetas.Find(id);
                ctx.Camisetas.Remove(camisetas);
                ctx.SaveChanges();
            }
        }


        public List<Camisetas> Listar()
        {
            using (ShirtStoreContext ctx = new ShirtStoreContext())
            {
                return ctx.Camisetas.ToList();

            }
        }
    }
}
