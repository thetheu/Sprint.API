﻿using System;
using System.Collections.Generic;

namespace Senai.Ekpis.WebApi.Domains
{
    public partial class Cargos
    {
        public Cargos()
        {
            Funcionarios = new HashSet<Funcionarios>();
        }

        public int IdCargo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
