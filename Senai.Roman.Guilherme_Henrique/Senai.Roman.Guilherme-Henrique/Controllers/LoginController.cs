using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Roman.Guilherme_Henrique.Domains;
using Senai.Roman.Guilherme_Henrique.Interfaces;
using Senai.Roman.Guilherme_Henrique.Repositories;
using Senai.Roman.Guilherme_Henrique.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Senai.Roman.Guilherme_Henrique.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IProfessoresRepository professoresRepository;
        public LoginController()
        {
            professoresRepository = new ProfessoresRepository();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel dadosLogin)
        {
            try
            {
                Professores usuarioBuscado = professoresRepository.BuscarPorNomeESenha(dadosLogin);
                if (usuarioBuscado == null)
                    return NotFound(new { mensagem = "Nome ou Senha Inválidos." });

                // informacoes referentes ao usuarios
                var claims = new[]
               {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Nome),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdProfessor.ToString()),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("roman-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Roman.WebApi",
                    audience: "Roman.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao cadastrar." + ex.Message });
            }
        }
    }
}
