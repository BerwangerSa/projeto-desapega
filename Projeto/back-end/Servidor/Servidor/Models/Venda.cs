namespace Servidor.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public string Imagem { get; set; }
        public double Preco { get; set; }
        public string LocalVenda { get; set; }
        public DateTime? DataExpiracao { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public DateTime DataCadastro { get; set; }


        public virtual Categoria Categoria { get; set; }

        public virtual Usuario Vendedor { get; set; }
        public virtual Usuario? Comprador { get; set; }

        public virtual StatusVenda StatusVenda { get; set; }

        public virtual List<Questionamento> Questionamentos { get; set; }
        public virtual Avaliacao? Avaliacao { get; set; }

        public Venda()
        {

        }
        public Venda(string titulo, string descricao, string imagem, double preco, string localVenda, Categoria categoria, Usuario vendedor, StatusVenda statusVenda, DateTime dataCadastro)
        {
            Titulo = titulo;
            Descricao = descricao;
            Imagem = imagem;
            Preco = preco;
            LocalVenda = localVenda;
            Categoria = categoria;
            Vendedor = vendedor;
            StatusVenda = statusVenda;
            DataCadastro = dataCadastro;
        }
    }
}
