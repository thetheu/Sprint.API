using Senai.ShirtStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Interfaces
{
    interface ITamanhoRepository
    {
        List<Tamanhos> Listar();
    }
}
