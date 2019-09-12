using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
    public class FuncionariosController : ControllerBase
    {
        FuncionarioRepository FuncionarioRepository = new FuncionarioRepository();

        [Authorize]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            var aa = HttpContext.User.Identity as ClaimsIdentity;
            var id = Convert.ToInt32(aa.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
            var role = aa.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;


            if (role == "COMUM")
            {
            return Ok(FuncionarioRepository.ListarPorId(id));
            }
            else
            {
                return Ok(FuncionarioRepository.ListarTodos());
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Funcionarios Funcionario = FuncionarioRepository.BuscarPorId(id);
            if (Funcionario == null)
                return NotFound();
            return Ok(Funcionario);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Funcionarios funcionario)
        {
            try
            {
                FuncionarioRepository.Cadastrar(funcionario);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(new { mensagem = "Erro ao cadastrar!" });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Funcionarios funcionario)
        {
            try
            {
                Funcionarios FuncionarioBuscado = FuncionarioRepository.BuscarPorId(funcionario.IdFuncionario);
                if (FuncionarioBuscado == null)
                    return NotFound();
                FuncionarioRepository.Atualizar(funcionario);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(new { mensagem = "Erro ao atualizar!" });
            }
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            FuncionarioRepository.Deletar(id);
            return Ok();
        }
    }
}