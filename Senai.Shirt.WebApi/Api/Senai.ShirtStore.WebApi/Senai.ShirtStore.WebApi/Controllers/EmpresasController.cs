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
    public class EmpresasController : ControllerBase
    {
        private IEmpresasRepository EmpresasRepository { get; set; }

        public EmpresasController()
        {
            EmpresasRepository = new EmpresasRepository();
        }


        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(EmpresasRepository.Listar());
        }



        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Empresas Empresas = EmpresasRepository.BuscarPorId(id);
            if (Empresas == null)
                return NotFound();
            return Ok(Empresas);
        }



        [HttpPost]
        public IActionResult Cadastrar(Empresas Empresas)
        {
            try
            {
                EmpresasRepository.Cadastrar(Empresas);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = "Erro ao Cadastrar" + ex });

            }
        }



        [HttpPut]
        public IActionResult Atualizar(Empresas empresas)
        {
            try
            {
                Empresas EmpresasBuscada = EmpresasRepository.BuscarPorId(empresas.IdEmpresa);
                if (EmpresasBuscada == null)
                    return NotFound();

                EmpresasRepository.Atualizar(empresas);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao Atualizar" + ex });

            }
        }



        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            EmpresasRepository.Deletar(id);
            return Ok();
        }
    }
}