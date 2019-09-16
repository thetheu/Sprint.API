using Senai.ShirtStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Interfaces
{
    interface ICamisetasRepository
    {
        List<Camisetas> Listar();
        void Cadastrar(Camisetas camisetas);
        Camisetas BuscarPorId(int id);
        void Atualizar(Camisetas camisetas);
        void Deletar(int id);
    }
}
