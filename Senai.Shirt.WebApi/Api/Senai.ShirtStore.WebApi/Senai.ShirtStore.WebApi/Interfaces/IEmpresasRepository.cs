using Senai.ShirtStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Interfaces
{
    interface IEmpresasRepository
    {
        List<Empresas> Listar();
        void Cadastrar(Empresas empresas);
        Empresas BuscarPorId(int id);
        void Atualizar(Empresas empresas);
        void Deletar(int id);
    }
}
