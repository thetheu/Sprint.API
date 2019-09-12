using Senai.Ekpis.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekpis.WebApi.Repositories
{
    public class CargoRepository
    {
        public List<Cargos> Listar()
        {
            using (EkpisContext ctx = new EkpisContext())
            {
                return ctx.Cargos.ToList();
            }
        }


        public Cargos BuscarPorId(int id)
        {
            using (EkpisContext ctx = new EkpisContext())
            {
                return ctx.Cargos.FirstOrDefault(x => x.IdCargo == id);
            }
        }


        public void Cadastrar (Cargos cargo)
        {
            using (EkpisContext ctx = new EkpisContext())
            {
                ctx.Cargos.Add(cargo);
                ctx.SaveChanges();
            }
        }


        public void Atualizar(Cargos cargo)
        {
            using (EkpisContext ctx = new EkpisContext())
            {
                Cargos CargoBuscado = ctx.Cargos.FirstOrDefault(x => x.IdCargo == cargo.IdCargo);
                CargoBuscado.Nome = cargo.Nome;
                ctx.Cargos.Update(CargoBuscado);
                ctx.SaveChanges();
            }
        }
    }
}
