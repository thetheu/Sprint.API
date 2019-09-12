using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.Repositories;

namespace Senai.AutoPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PecasController : ControllerBase
    {
        private IPecaRepository PecasRepository { get; set; }

        public PecasController()
        {
            PecasRepository = new PecasRepository();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PecasRepository.Listar());
        }


        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Pecas Pecas = PecasRepository.BuscarPorId(id);
            if (Pecas == null)
                return NotFound();
            return Ok(Pecas);
        }


        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Pecas peca)
        {
            try
            {
                PecasRepository.Cadastrar(peca);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Tá errado" + ex.Message });
            }
        }


        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Pecas pecas)
        {
            try
            {
                Pecas PecaBuscada = PecasRepository.BuscarPorId(pecas.IdPeca);
                if (PecaBuscada == null)
                    return NotFound();

                PecasRepository.Atualizar(pecas);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = "Erro ao Atualizar" });
            }
        }


        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            PecasRepository.Deletar(id);
            return Ok();
        }


   
    }
}