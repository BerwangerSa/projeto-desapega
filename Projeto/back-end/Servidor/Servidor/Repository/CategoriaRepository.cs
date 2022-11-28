using Servidor.DataAcess;
using Servidor.Models;
using Servidor.Repository.Base;

namespace Servidor.Repository
{
    public class CategoriaRepository: Repository<Categoria>
    {
        public CategoriaRepository(DataContext context) : base(context)
        {
        }
    }
}
