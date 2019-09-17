using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.ShirtStore.WebApi.Interfaces;
using Senai.ShirtStore.WebApi.Repositories;

namespace Senai.ShirtStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TamanhosController : ControllerBase
    {
        private ITamanhoRepository TamanhosRepository { get; set; }

        public TamanhosController()
        {
            TamanhosRepository = new TamanhosRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(TamanhosRepository.Listar());
        }
    }
}