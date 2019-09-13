using System;
using System.Collections.Generic;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class Camisetas
    {
        public Camisetas()
        {
            Empresas = new HashSet<Empresas>();
            Estoques = new HashSet<Estoques>();
        }

        public int IdCamiseta { get; set; }
        public string Descriçao { get; set; }

        public ICollection<Empresas> Empresas { get; set; }
        public ICollection<Estoques> Estoques { get; set; }
    }
}
