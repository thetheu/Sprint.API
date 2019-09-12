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
    public class DepartamentosController : ControllerBase
    {
        DepartamentoRepository DepartamentoRepository = new DepartamentoRepository();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(DepartamentoRepository.Listar());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Departamentos Departamento = DepartamentoRepository.BuscarPorId(id);
            if (Departamento == null)
                return NotFound();
            return Ok(Departamento);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Departamentos Departamento)
        {
            try
            {
                DepartamentoRepository.Cadastrar(Departamento);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(new { menagem = "Não foi possível Cadastrar" });
            }
        }
    }
}