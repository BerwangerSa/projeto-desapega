using Servidor.Models;

namespace Servidor.DTOs
{
    public class VendaDTO
    {

        public int? Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }

        public string? Imagem { get; set; }
        public double? Preco { get; set; }
        public string? LocalVenda { get; set; }

        public string? Status { get; set; }
        public DateTime? DataExpiracao { get; set; }
 
        public int? IdCategoria { get; set; }

        public string? NomeVendedor { get; set; }
        public string? DescricaoCategoria { get; set; }

        public float? NotaVendedor { get; set; }
        public bool ? ehParaComprar { get; set; }
        public bool ? ehParaCancelar { get; set; }
        public bool ? ehParaRejeitar { get; set; }
        public bool? ehCriadorDaVenda { get; set; }
        public int? IdStatus { get; set; }
        public  List<Questionamento>? Questionamentos { get; set; }
        public  Avaliacao? Avaliacao { get; set; }
    }
}
