using Servidor.DataAcess;
using Servidor.DTOs;
using Servidor.Models;
using Servidor.Repository;
using Servidor.Services.Base;

namespace Servidor.Services
{

    public class UsuarioService : Service<Usuario>
    {
        public UsuarioService(DataContext context) : base(new UsuarioRepository(context))
        {

        }

        public Usuario VerificaExisteUsuarioLogado(UsuarioDTO usuario)
        {

            return GetAll().Where(u => u.Login == usuario.Login).FirstOrDefault();
        }

        public Usuario VerificaLoginESenha(UsuarioDTO usuario)
        {
            return GetAll().Where(u =>  u.Login == usuario.Login && usuario.Senha == u.Senha).FirstOrDefault();
        }

        public Usuario GetUSuarioByLogin(string login)
        {
            return GetAll().Where(u =>  u.Login == login).FirstOrDefault();
        }

    }
}