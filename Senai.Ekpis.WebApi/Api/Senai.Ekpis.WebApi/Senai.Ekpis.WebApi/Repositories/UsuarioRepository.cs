using Senai.Ekpis.WebApi.Domains;
using Senai.Ekpis.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekpis.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (EkpisContext ctx = new EkpisContext())
            {
                Usuarios usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuario == null)
                    return null;
                return usuario;
            }
        }
    }
}