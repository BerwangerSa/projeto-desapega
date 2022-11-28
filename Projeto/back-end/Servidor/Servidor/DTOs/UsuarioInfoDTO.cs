namespace Servidor.DTOs
{
    public class UsuarioInfoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Avaliacao { get; set; }
        public int TotalProdutosOfertados { get; set; }
        public int TotalRespostas { get; set; }
        public int TotalQuestionamentos { get; set; }
        public int TotalProdutosVendidos { get; set; }
    }
}
