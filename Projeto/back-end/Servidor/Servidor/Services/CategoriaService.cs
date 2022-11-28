using Servidor.DataAcess;
using Servidor.Models;
using Servidor.Repository;
using Servidor.Services.Base;

namespace Servidor.Services
{
    public class CategoriaService : Service<Categoria>
    {
        public CategoriaService(DataContext context) : base(new CategoriaRepository(context))
        {

        }
    }
}
