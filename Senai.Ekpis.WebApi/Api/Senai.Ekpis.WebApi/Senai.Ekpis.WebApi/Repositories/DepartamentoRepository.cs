using Senai.Ekpis.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekpis.WebApi.Repositories
{
    public class DepartamentoRepository
    {
        public List<Departamentos> Listar()
        {
            using (EkpisContext ctx = new EkpisContext())
            {
                return ctx.Departamentos.ToList();
            }
        }

        public Departamentos BuscarPorId(int id)
        {
            using (EkpisContext ctx = new EkpisContext())
            {
                return ctx.Departamentos.FirstOrDefault(x => x.IdDepartamento == id);
            }
        }

        public void Cadastrar (Departamentos Departamento)
        {
            using (EkpisContext ctx = new EkpisContext())
            {
                ctx.Departamentos.Add(Departamento);
                ctx.SaveChanges();
            }
        }
    }
}
