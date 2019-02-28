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
    public class EstudiosController : ControllerBase
    {
        private IEstudiosRepoitory EstudiosRepository;

        public EstudiosController(){
            EstudiosRepository = new EstudiosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
               
                return Ok(EstudiosRepository.Listar());
            }
            catch (Exception ex)
            {

                return BadRequest(new {
                    mensagem="DEU ERRO IRMAO"
                });
            }
            
        }
    }
}
