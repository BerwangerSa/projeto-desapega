using Servidor.DataAcess;
using Servidor.Models;
using Servidor.Repository.Base;

namespace Servidor.Repository
{
    public class UsuarioRepository : Repository<Usuario>
    {
        public UsuarioRepository(DataContext context) : base(context)
        {
        }

    }
}