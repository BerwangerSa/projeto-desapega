namespace Servidor.DTOs
{
    public class InfoAdminDTO
    {
        public int TotalVendas { get; set; }
        public int TotalVendido { get; set; }
        public int TotalExpirado { get; set; }
        public int TotalCancelado { get; set; }
        public List<UsuarioInfoDTO> infoVendedores { get; set; }
    }
}
