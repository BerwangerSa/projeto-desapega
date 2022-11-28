using Servidor.DTOs;

namespace Servidor.Models
{
    public class Resposta
    {
        public int Id { get; set; }

        public string? Imagem { get; set; }
        public string Descricao { get; set; }
        
        public Resposta() { }

        public Resposta(RespostaDTO respostaDTO)
        {
            Imagem = respostaDTO.Imagem;
            Descricao = respostaDTO.Resposta;
        }
    }
}
