using Microsoft.EntityFrameworkCore;
using Senai.ShirtStore.WebApi.Domains;
using Senai.ShirtStore.WebApi.Interfaces;
using Senai.ShirtStore.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (ShirtStoreContext ctx = new ShirtStoreContext())
            {
                Usuarios usuario = ctx.Usuarios.Include(x => x.IdPerfilNavigation).FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuario == null)
                    return null;
                return usuario;
            }
        }


        public void Cadastrar(Usuarios usuarios)
        {
            using (ShirtStoreContext ctx = new ShirtStoreContext())
            {
                ctx.Usuarios.Add(usuarios);
                ctx.SaveChanges();
            }
        }


        public void Deletar(int id)
        {
            using (ShirtStoreContext ctx = new ShirtStoreContext())
            {
                ctx.Usuarios.Find(id);
                ctx.SaveChanges();
            }
        }
    }
}
