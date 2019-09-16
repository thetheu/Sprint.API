using Senai.ShirtStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuarios> Listar();
        void Cadastrar(Usuarios usuarios);
        Usuarios BuscarPorId(int id);
        void Atualizar(int id,Usuarios usuarios);
        void Deletar(int id);
    }
}
