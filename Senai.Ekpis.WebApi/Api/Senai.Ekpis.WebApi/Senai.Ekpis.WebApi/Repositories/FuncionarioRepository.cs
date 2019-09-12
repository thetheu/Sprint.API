using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Senai.Ekpis.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekpis.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        
        public List<Funcionarios> ListarTodos()
        {
            using (EkpisContext ctx = new EkpisContext())
            {
                return ctx.Funcionarios.Include(x => x.IdDepartamentoNavigation).Include(x => x.IdCargoNavigation).ToList();
              
            }
        }

        public Funcionarios ListarPorId(int id)
        {
            using (EkpisContext ctx = new EkpisContext())
            {
                return ctx.Funcionarios.Include(x => x.IdDepartamentoNavigation).Include(x => x.IdCargoNavigation).FirstOrDefault(x => x.IdUsuario == id);
            }
        }

        public Funcionarios BuscarPorId(int id)
        {
            using (EkpisContext ctx = new EkpisContext())
            {
                return ctx.Funcionarios.FirstOrDefault(x => x.IdFuncionario == id);
            }
        }

        public void Cadastrar(Funcionarios Funcionario)
        {
            using (EkpisContext ctx = new EkpisContext())
            {
                ctx.Funcionarios.Add(Funcionario);
                ctx.SaveChanges();

            }
        }

        public void Atualizar(Funcionarios funcionario)

        {
            using (EkpisContext ctx = new EkpisContext())
            {
                Funcionarios FuncionarioBuscado = ctx.Funcionarios.FirstOrDefault(x => x.IdFuncionario == funcionario.IdFuncionario);
                FuncionarioBuscado.Nome = funcionario.Nome;
                ctx.Funcionarios.Update(FuncionarioBuscado);
                ctx.SaveChanges();

            }
        }

        public void Deletar(int id)
        {
            using (EkpisContext ctx = new EkpisContext())
            {
                Funcionarios Funcionario = ctx.Funcionarios.Find(id);
                ctx.Funcionarios.Remove(Funcionario);
                ctx.SaveChanges();
            }
        }
    }
}
