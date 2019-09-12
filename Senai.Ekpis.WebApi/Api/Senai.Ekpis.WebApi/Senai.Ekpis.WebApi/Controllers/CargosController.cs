using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekpis.WebApi.Domains;
using Senai.Ekpis.WebApi.Repositories;

namespace Senai.Ekpis.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        CargoRepository CargoRepository = new CargoRepository();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(CargoRepository.Listar());
        }


        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Cargos cargo = CargoRepository.BuscarPorId(id);
            if(cargo == null)
                 return NotFound();
            return Ok(cargo);
        }


        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Cargos cargo)
        {
            try
            {
                CargoRepository.Cadastrar(cargo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao cadastrar" + ex.Message });
                
            }
        }

        [Authorize]
        [HttpPut]
        public IActionResult Atualizar(Cargos cargo)
        {
            try
            {
                Cargos CargoBuscado = CargoRepository.BuscarPorId(cargo.IdCargo);
                if (CargoBuscado == null)
                return NotFound();
            CargoRepository.Atualizar(cargo);
            return Ok();

            }
            catch (Exception)
            {

                return BadRequest(new { mensagem = "Erro ao Atualizar dados" });
            }
        }
    }
}