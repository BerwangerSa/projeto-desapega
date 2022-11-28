using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servidor.DataAcess;
using Servidor.DTOs;
using Servidor.Services;

namespace Servidor.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CategoriaController: ControllerBase
    {


        private readonly CategoriaService categoriaService;

        public CategoriaController(DataContext dataContext)
        {
            categoriaService = new CategoriaService(dataContext);
        }

        [HttpGet]
        [Route("All")]
        [AllowAnonymous]
        public ActionResult All()
        {
            return Ok(categoriaService.GetAll().Select(c => new CategoriaDTO()
            {
                Id = c.Id,
                Descricao = c.Descricao,
            }
            ).ToList());

        }
    }
}
