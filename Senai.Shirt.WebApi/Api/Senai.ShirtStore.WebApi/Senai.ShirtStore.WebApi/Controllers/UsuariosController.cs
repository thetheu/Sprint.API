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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }


        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(UsuarioRepository.Listar());
        }
            

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Usuarios usuarios = UsuarioRepository.BuscarPorId(id);
            if (usuarios == null)
                return NotFound();
            return Ok(usuarios);
        }


        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuarios)
        {
            try
            {
                UsuarioRepository.Cadastrar(usuarios);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao cadastrar" });
                
            }
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id,Usuarios usuarios)
        {
            try
            {
                Usuarios UsuarioBuscado = UsuarioRepository.BuscarPorId(id);
                if (UsuarioBuscado == null)
                    return NotFound();

                UsuarioRepository.Atualizar(id,usuarios);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao Atualizar" + ex});
                
            }
        }


        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            UsuarioRepository.Deletar(id);
            return Ok();
        }
    }
}