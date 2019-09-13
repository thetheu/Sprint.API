using System;
using System.Collections.Generic;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class Tamanhos
    {
        public Tamanhos()
        {
            Estoques = new HashSet<Estoques>();
        }

        public int IdTamanho { get; set; }
        public string Tamanho { get; set; }

        public ICollection<Estoques> Estoques { get; set; }
    }
}
