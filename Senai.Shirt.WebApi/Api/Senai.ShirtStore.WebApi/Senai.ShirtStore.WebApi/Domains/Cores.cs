using System;
using System.Collections.Generic;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class Cores
    {
        public Cores()
        {
            Estoques = new HashSet<Estoques>();
        }

        public int IdCores { get; set; }
        public string Cor { get; set; }

        public ICollection<Estoques> Estoques { get; set; }
    }
}
