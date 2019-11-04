using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Roman.Guilherme_Henrique.Domains;
using Senai.Roman.Guilherme_Henrique.Repositories;

namespace Senai.Roman.Guilherme_Henrique.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        IProjetosRepository projetosRepository;
        public ProjetosController()
        {
            projetosRepository = new ProjetosRepository();
        }


        [Authorize]
        [HttpGet]
        public IActionResult ListarProjetos()
        {
            try
            {
                return Ok(projetosRepository.ListarProjetos());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult CadastrarProjeto(Projetos novoProjeto)
        {
            try
            {
                projetosRepository.CadastrarProjeto(novoProjeto);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}