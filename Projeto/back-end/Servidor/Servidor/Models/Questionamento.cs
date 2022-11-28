namespace Servidor.Models
{
    public class Questionamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual Resposta? Resposta { get; set; }
        public virtual Usuario Usuario { get; set; }

        public Questionamento() 
        { 
        }

        public Questionamento(string descricao, Usuario usuario)
        {
            Descricao = descricao;
            Usuario = usuario;
        }
    }
}
