using Servidor.DataAcess;
using Servidor.Models;
using Servidor.Repository.Base;

namespace Servidor.Repository
{
    public class StatusVendaRepository: Repository<StatusVenda>
    {
        public StatusVendaRepository(DataContext data): base(data)
        {

        }
    }
}
