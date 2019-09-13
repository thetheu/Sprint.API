using System;
using System.Collections.Generic;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Empresas = new HashSet<Empresas>();
        }

        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? IdPerfil { get; set; }

        public Perfis IdPerfilNavigation { get; set; }
        public ICollection<Empresas> Empresas { get; set; }
    }
}
