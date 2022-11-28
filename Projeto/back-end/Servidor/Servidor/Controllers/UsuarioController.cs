using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servidor.DataAcess;
using Servidor.DTOs;
using Servidor.Models;
using Servidor.Security;
using Servidor.Services;

namespace Servidor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService usuarioService;

        private readonly VendaService vendaService;
        public UsuarioController(DataContext dataContext)
        {
            usuarioService = new UsuarioService(dataContext);
            vendaService = new VendaService(dataContext);
        }
        [HttpPost]
        [Route("Logout")]
        [Authorize]
        public ActionResult Logout()
        {
            return Ok("Deslogado");

        }

        [HttpPost]
        [Route("Cadastrar")]
        [AllowAnonymous]
        public ActionResult Cadastrar([FromBody] UsuarioDTO usuarioDTO)
        {


            if(usuarioService.VerificaExisteUsuarioLogado(usuarioDTO) != null)
            {
                return Ok(new { ErrorCode = System.Net.HttpStatusCode.NotFound, msgErro = "Usuário já existe!" }); ;

            }

            Usuario usuario = new Usuario(usuarioDTO.Login, usuarioDTO.Senha, usuarioDTO.Email, false, usuarioDTO.Nome);
            usuarioService.Add(usuario);

            return Ok("OK");
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ActionResult Login([FromBody] UsuarioDTO usuarioDTO)
        {

            Usuario usuario = usuarioService.VerificaLoginESenha(usuarioDTO);

            if (usuario == null)
                return Ok(new { ErrorCode = System.Net.HttpStatusCode.NotFound, msgErro = "Login ou Senha incorretos!" });

            var dataExpiracaoToken = DateTime.Now.AddHours(3).AddMinutes(45);

            usuarioDTO.IsAdmin = usuario.IsAdmin;
            usuarioDTO.Senha = "";
            usuarioDTO.Email = usuario.Email;

            var token = TokenService.GenerateToken(usuario);
            return Ok(new
            {
                dataExpiracaoToken = dataExpiracaoToken,
                usuario = usuarioDTO,
                token = token,
            });


        }

        [HttpPost]
        [Route("getinfoadmin")]
        [Authorize]
        public ActionResult GetInfoAdmin()
        {
            var usuarios = usuarioService.GetAll().ToList();

            InfoAdminDTO infoAdmin = new InfoAdminDTO()
            {
                TotalCancelado = vendaService.GetTotalCancelado(),
                TotalExpirado = vendaService.GetTotalExpirados(),
                TotalVendas = vendaService.GetTotalVendas(),
                TotalVendido = vendaService.GetTotalVendidos(),
                infoVendedores = vendaService.GetInfoAdminVendedores(usuarios)

            };

            return Ok(infoAdmin);
        }

    }
}