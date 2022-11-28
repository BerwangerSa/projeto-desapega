using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servidor.DataAcess;
using Servidor.DTOs;
using Servidor.Models;
using Servidor.Services;
using System.Reflection.Metadata;

namespace Servidor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly UsuarioService usuarioService;
        private readonly CategoriaService categoriaService;
        private readonly StatusVendaService statusVendaService;
        private readonly VendaService vendaService;

        public VendaController(DataContext dataContext)
        {
            usuarioService = new UsuarioService(dataContext);
            statusVendaService = new StatusVendaService(dataContext);
            categoriaService = new CategoriaService(dataContext);
            vendaService = new VendaService(dataContext);
        }

        [HttpGet("{IdVenda}")]
        [Route("get")]
        [Authorize]
        public ActionResult Get([FromQuery] int IdVenda)
        {
            VendaDTO venda = vendaService.GetVendaById(IdVenda);

            return Ok(venda);
        }

        [HttpPost]
        [Route("adicionar")]
        [Authorize]
        public ActionResult Adicionar(VendaDTO vendaDTO)
        {
            Venda venda = new Venda(vendaDTO.Titulo, vendaDTO.Descricao, vendaDTO.Imagem, vendaDTO.Preco.Value,vendaDTO.LocalVenda, categoriaService.GetById(vendaDTO.IdCategoria.Value),usuarioService.GetUSuarioByLogin(User.Identity.Name), statusVendaService.GetStatusVendaInicial(), DateTime.Now);
            vendaService.Add(venda);

            return Ok("Venda adicionada com sucesso!!!");
        }


        [HttpGet]
        [Route("all")]
        [Authorize]
        public ActionResult Todos()
        {

            var IdUsuarioLogado = usuarioService.GetUSuarioByLogin(User.Identity.Name).Id;

            return Ok(vendaService.GetVendas(IdUsuarioLogado));
        }

        [HttpGet]
        [Route("minhascompras")]
        [Authorize]
        public ActionResult MinhasCompras()
        {

            var IdUsuarioLogado = usuarioService.GetUSuarioByLogin(User.Identity.Name).Id;

            return Ok(vendaService.GetMinhasCompras(IdUsuarioLogado));
        }

        [HttpGet("{Filtro}")]
        [Route("Filtrar")]
        [Authorize]
        public ActionResult Filtrar([FromQuery] string Filtro)
        {

            var IdUsuarioLogado = usuarioService.GetUSuarioByLogin(User.Identity.Name).Id;

            List<VendaDTO> vendas;

            if (string.IsNullOrEmpty(Filtro))
                vendas = vendaService.GetVendas(IdUsuarioLogado);
            else
                vendas = vendaService.GetVendasComFiltro(IdUsuarioLogado, Filtro);

            return Ok(vendas);
        }

        [HttpPut("{IdVenda}")]
        [Route("pedircompra")]
        [Authorize]
        public ActionResult PedirCompra([FromQuery]int IdVenda, [FromBody]string QrCode)
        {
            var venda = vendaService.GetById(IdVenda);
            venda.Comprador = usuarioService.GetUSuarioByLogin(User.Identity.Name);
            venda.StatusVenda = statusVendaService.GetStatusVendaEmNegociacao();
            vendaService.Update(venda);


            EmailService.Send(venda.Comprador.Email, "Solicitação de compra", "Olá " + venda.Comprador.Nome + "<br> A sua solicitação de compra foi feita com sucesso! Acompanhe o status pelo QrCode: <br>" + "<img src=" + QrCode + " />");
            EmailService.Send(venda.Vendedor.Email, "Solicitação de compra", "Olá " + venda.Vendedor.Nome + "<br> O usuário " + venda.Comprador.Nome + " deseja comprar o seu produto " + venda.Titulo + "!" );


            return Ok("Solicitação de compra feita com sucesso");
        }

        [HttpPut("{IdVenda}")]
        [Route("cancelarpedido")]
        [Authorize]
        public ActionResult CancelarPedido([FromQuery]int IdVenda)
        {
            var venda = vendaService.GetById(IdVenda);
            var comprador = venda.Comprador;
            comprador = null;
            venda.Comprador = comprador;
            venda.StatusVenda = statusVendaService.GetStatusVendaInicial();
            vendaService.Update(venda);

            EmailService.Send(venda.Vendedor.Email, "Cancelamento de compra", "Olá " + venda.Vendedor.Nome + "<br> O pedido de compra do seu produto foi cancelado!");



            return Ok("Pedido cancelado com sucesso");
        }

        [HttpPut("{IdVenda}")]
        [Route("rejeitarpedido")]
        [Authorize]
        public ActionResult RejeitarPedido([FromQuery] int IdVenda)
        {
            var venda = vendaService.GetById(IdVenda);

            EmailService.Send(venda.Comprador?.Email, "Solicitação de compra", "Olá " + venda?.Comprador.Nome + "<br> A sua solicitação de compra foi rejeitada!");

            var comprador = venda.Comprador;
            comprador = null;
            venda.Comprador = comprador;

            venda.StatusVenda = statusVendaService.GetStatusVendaInicial();
            vendaService.Update(venda);
            return Ok("Pedido rejeitado com sucesso");
        }

        [HttpPut("{IdVenda}")]
        [Route("aceitarcompra")]
        [Authorize]
        public ActionResult AceitarCompra([FromQuery] int IdVenda)
        {
            var venda = vendaService.GetById(IdVenda);
            venda.StatusVenda = statusVendaService.GetStatusVendaVendido();
            vendaService.Update(venda);

            EmailService.Send(venda?.Comprador.Email, "Venda realizada", "Olá " + venda?.Comprador.Nome + "<br> A sua compra foi feita com sucesso! Não esqueça de deixar uma avaliação!");


            return Ok("Pedido aceito com sucesso");
        }

        [HttpPut("{IdVenda, Comentario}")]
        [Route("adicionarcomentario")]
        [Authorize]
        public ActionResult AdicionarComentario([FromQuery] int IdVenda, [FromQuery] string Comentario)
        {
            var venda = vendaService.GetById(IdVenda);

            venda.Questionamentos?.Add(new Questionamento(Comentario, usuarioService.GetUSuarioByLogin(User.Identity.Name)));
            vendaService.Update(venda);
            return Ok("Comentário adicionado com sucesso");
        }

        [HttpPut("{IdVenda, IdQuestionamento}")]
        [Route("respondercomentario")]
        [Authorize]
        public ActionResult ResponderComentario([FromQuery] int IdVenda, [FromQuery] int IdQuestionamento, [FromBody] RespostaDTO respostaDTO)
        {
            var venda = vendaService.GetById(IdVenda);
            venda.Questionamentos.Find(q=> q.Id == IdQuestionamento).Resposta = new Resposta(respostaDTO);
            vendaService.Update(venda);
            return Ok("Resposta adicionada com sucesso");
        }

        [HttpPost("{IdVenda}")]
        [Route("avaliar")]
        [Authorize]
        public ActionResult Avaliar([FromQuery] int IdVenda, [FromBody] AvaliacaoDTO avaliacaoDTO)
        {
            var venda = vendaService.GetById(IdVenda);

            Avaliacao avaliacao = new Avaliacao(avaliacaoDTO.Nota, usuarioService.GetUSuarioByLogin(User.Identity.Name));

            venda.Avaliacao = avaliacao;
            vendaService.Update(venda);

            EmailService.Send(venda.Vendedor.Email, "Avaliação", "Olá " + venda.Vendedor.Nome + "<br> O usuário " + venda.Comprador.Nome + " avaliou o seu produto " + venda.Titulo + " com a nota de " + avaliacaoDTO.Nota + "!");


            return Ok("Solicitação de compra feita com sucesso");
        }

        [HttpPut("{IdVenda}")]
        [Route("cancelarvenda")]
        [Authorize]
        public ActionResult CancelarVenda([FromQuery] int IdVenda)
        {

            var venda = vendaService.GetById(IdVenda);
            venda.StatusVenda = statusVendaService.GetStatusVendaCancelado();
            venda.DataCancelamento = DateTime.Now;
            vendaService.Update(venda);


            return Ok("Venda cancelada com sucesso");
        }

        [HttpPost]
        [Route("desativarVendasUltimos45Dias")]
        [Authorize]
        public ActionResult DesativarVendasUltimos45Dias()
        {
            vendaService.DesativarVendasDosUltimos45Dias(statusVendaService.GetStatusVendaExpirado());
            return Ok("Vendas dos últimos 45 dias canceladas com sucesso");
        }



    }
}
