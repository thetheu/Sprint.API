using Microsoft.EntityFrameworkCore;
using Senai.ShirtStore.WebApi.Domains;
using Senai.ShirtStore.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Repositories
{
    public class EmpresasRepository : IEmpresasRepository
    {

        public void Atualizar(Empresas empresas)
        {
            using (ShirtStoreContext ctx = new ShirtStoreContext())
            {
                Empresas EmpresaBuscadas = ctx.Empresas.FirstOrDefault(x => x.IdEmpresa == empresas.IdEmpresa);
                EmpresaBuscadas.IdCamiseta = empresas.IdCamiseta;
                EmpresaBuscadas.IdUsuario = empresas.IdUsuario;
                EmpresaBuscadas.NomeEmpresa = empresas.NomeEmpresa;
                ctx.Empresas.Update(EmpresaBuscadas);
                ctx.SaveChanges();
            }
        }
        

        public void Cadastrar(Empresas empresas)
        {
            using (ShirtStoreContext ctx = new ShirtStoreContext())
            {
                ctx.Add(empresas);
                ctx.SaveChanges();
            }
        }


        public void Deletar(int id)
        {
            using (ShirtStoreContext ctx = new ShirtStoreContext())
            {
                Empresas empresas = ctx.Empresas.Find(id);
                ctx.Empresas.Remove(empresas);
                ctx.SaveChanges();
            }
        }


        public List<Empresas> Listar()
        {
            using (ShirtStoreContext ctx = new ShirtStoreContext())
            {
                return ctx.Empresas.Include(x => x.IdUsuarioNavigation).Include(x => x.IdCamisetaNavigation).ToList();

            }
        }


        Empresas IEmpresasRepository.BuscarPorId(int id)
        {
            using (ShirtStoreContext ctx = new ShirtStoreContext())
            {
                return ctx.Empresas.FirstOrDefault(x => x.IdEmpresa == id);
            }
        }
    }
}
