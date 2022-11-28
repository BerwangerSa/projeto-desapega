namespace Servidor.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int Nota { get; set; }
        public virtual Usuario Usuario { get; set; }

        public Avaliacao() { }

        public Avaliacao(int nota, Usuario usuario)
        {
            Nota = nota;
            Usuario = usuario;
        }
    }
}
