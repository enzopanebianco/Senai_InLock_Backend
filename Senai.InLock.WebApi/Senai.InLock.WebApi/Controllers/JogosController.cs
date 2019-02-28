using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController:ControllerBase
    {
        private IJogosRepository JogosRepository;

        public JogosController()
        {
            JogosRepository = new JogosRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(JogosRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(new{
                    mensagem = "Deu erro"
                });

            }
        }


        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Post(JogosDomain jogos)
        {
            try
            {
                JogosRepository.Cadastrar(jogos);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new {
                    mensagem="ERRO"
                });
            }
        }

    }
}
