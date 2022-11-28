using Servidor.DataAcess;
using Servidor.Models;
using Servidor.Repository.Base;

namespace Servidor.Repository
{
    public class VendaRepository : Repository<Venda>
    {
        public VendaRepository(DataContext context) : base(context)
        {
        }
    }
}
