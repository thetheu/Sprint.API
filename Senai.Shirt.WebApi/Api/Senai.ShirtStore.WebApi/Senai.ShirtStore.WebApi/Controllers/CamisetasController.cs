using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.ShirtStore.WebApi.Domains;
using Senai.ShirtStore.WebApi.Interfaces;
using Senai.ShirtStore.WebApi.Repositories;

namespace Senai.ShirtStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CamisetasController : ControllerBase
    {
        private ICamisetasRepository CamisetasRepository { get; set; }

        public CamisetasController()
        {
            CamisetasRepository = new CamisetasRepository();
        }


        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(CamisetasRepository.Listar());
        }



        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Camisetas camisetas = CamisetasRepository.BuscarPorId(id);
            if (camisetas == null)
                return NotFound();
            return Ok(camisetas);
        }



        [HttpPost]
        public IActionResult Cadastrar(Camisetas camisetas)
        {
            try
            {
                CamisetasRepository.Cadastrar(camisetas);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = "Erro ao Cadastrar" + ex});
                
            }
        }



        [HttpPut]
        public IActionResult Atualizar(Camisetas camisetas)
        {
            try
            {
                Camisetas CamisetasBuscada = CamisetasRepository.BuscarPorId(camisetas.IdCamiseta);
                if (CamisetasBuscada == null)
                    return NotFound();

                CamisetasRepository.Atualizar(camisetas);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao Atualizar" + ex});
                
            }
        }



        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            CamisetasRepository.Deletar(id);
            return Ok();
        }
    }
}