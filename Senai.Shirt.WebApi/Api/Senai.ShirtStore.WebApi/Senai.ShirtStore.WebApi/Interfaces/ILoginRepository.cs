using Senai.ShirtStore.WebApi.Domains;
using Senai.ShirtStore.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Interfaces
{
    interface ILoginRepository
    {
        Usuarios BuscarPorEmailESenha(LoginViewModel login);
        void Cadastrar(Usuarios usuarios);
        void Deletar(int id);
    }
}
