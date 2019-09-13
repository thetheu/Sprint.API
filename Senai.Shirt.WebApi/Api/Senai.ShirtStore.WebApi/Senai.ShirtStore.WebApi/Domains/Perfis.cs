using System;
using System.Collections.Generic;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class Perfis
    {
        public Perfis()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdPerfil { get; set; }
        public string Perfil { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
