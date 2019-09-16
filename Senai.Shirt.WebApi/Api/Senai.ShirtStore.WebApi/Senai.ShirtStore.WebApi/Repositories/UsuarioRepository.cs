using Senai.ShirtStore.WebApi.Domains;
using Senai.ShirtStore.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Atualizar(int id,Usuarios usuarios)
        {
            using (ShirtStoreContext ctx = new ShirtStoreContext())
            {
                Usuarios UsuariosBuscado = ctx.Usuarios.Find(id);
                if(usuarios.Email != null)
                {
                    UsuariosBuscado.Email = usuarios.Email;
                }
                //UsuariosBuscado.Empresas = usuarios.Empresas;
                //UsuariosBuscado.Senha = usuarios.Senha;
                ctx.Usuarios.Update(UsuariosBuscado);
                ctx.SaveChanges();
            }
        }


        public Usuarios BuscarPorId(int id)
        {
            using (ShirtStoreContext ctx = new ShirtStoreContext())
            {
                return ctx.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
            }
        }


        public void Cadastrar(Usuarios usuarios)
        {
            using (ShirtStoreContext ctx = new ShirtStoreContext())
            {
                ctx.Add(usuarios);
                ctx.SaveChanges();
            }
        }


        public void Deletar(int id)
        {
            using (ShirtStoreContext ctx = new ShirtStoreContext())
            {
                Usuarios usuarios = ctx.Usuarios.Find(id);
                ctx.Usuarios.Remove(usuarios);
                ctx.SaveChanges();
            }
        }


        public List<Usuarios> Listar()
        {
            using (ShirtStoreContext ctx = new ShirtStoreContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
    }
}
