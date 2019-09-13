using System;
using System.Collections.Generic;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class Empresas
    {
        public int IdEmpresa { get; set; }
        public string NomeEmpresa { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdCamiseta { get; set; }

        public Camisetas IdCamisetaNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
