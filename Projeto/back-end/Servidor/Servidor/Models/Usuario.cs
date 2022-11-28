namespace Servidor.Models
{
    public class Usuario
    {

        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public bool IsAdmin { get; set; }
        public virtual List<Venda> Vendas { get; set; }
        public Usuario(string Login, string Senha, string Email, bool isAdmin, string Nome)
        {
            this.Login = Login;
            this.Senha = Senha;
            this.Email = Email;
            this.IsAdmin = IsAdmin;
            this.Nome = Nome;
        }

        public Usuario()
        {

        }


    }
}
