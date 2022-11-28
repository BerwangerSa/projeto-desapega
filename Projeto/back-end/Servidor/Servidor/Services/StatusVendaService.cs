using Servidor.DataAcess;
using Servidor.Models;
using Servidor.Repository;
using Servidor.Services.Base;

namespace Servidor.Services
{
    public class StatusVendaService: Service<StatusVenda>
    {
        public StatusVendaService(DataContext data): base(new StatusVendaRepository(data))
        {

        }
        public StatusVenda GetStatusVendaInicial()
        {
            return this.GetAll().Where(sv => sv.Id.Equals(1)).FirstOrDefault();
        }
        public StatusVenda GetStatusVendaEmNegociacao()
        {
            return this.GetAll().Where(sv => sv.Id.Equals(2)).FirstOrDefault();
        }
        public StatusVenda GetStatusVendaVendido()
        {
            return this.GetAll().Where(sv => sv.Id.Equals(3)).FirstOrDefault();
        }

        public StatusVenda GetStatusVendaCancelado()
        {
            return this.GetAll().Where(sv => sv.Id.Equals(4)).FirstOrDefault();
        }

        public StatusVenda GetStatusVendaExpirado()
        {
            return this.GetAll().Where(sv => sv.Id.Equals(5)).FirstOrDefault();
        }
    }
}
