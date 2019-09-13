using System;
using System.Collections.Generic;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class Estoques
    {
        public int IdEstoque { get; set; }
        public string Unidades { get; set; }
        public int? IdCamiseta { get; set; }
        public int? IdTamanho { get; set; }
        public int? IdCores { get; set; }

        public Camisetas IdCamisetaNavigation { get; set; }
        public Cores IdCoresNavigation { get; set; }
        public Tamanhos IdTamanhoNavigation { get; set; }
    }
}
