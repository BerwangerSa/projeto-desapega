using Servidor.DataAcess;
using Servidor.DTOs;
using Servidor.Models;
using Servidor.Repository;
using Servidor.Services.Base;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;

namespace Servidor.Services
{
    public class VendaService : Service<Venda>

    {
        public VendaService(DataContext context) : base(new VendaRepository(context))
        {
            

        }
        public List<VendaDTO> GetVendas(int IdUsuarioLogado)
        {
            return this.GetAll().Where(v =>  v.StatusVenda.Id < 3).Select(v => new VendaDTO()
            {
                Id = v.Id,
                Titulo = v.Titulo,
                IdStatus = v.StatusVenda.Id,
                Descricao = v.Descricao,
                Imagem = v.Imagem,
                Preco = v.Preco,
                NotaVendedor = v.Vendedor.Vendas.Where(v => v.Avaliacao != null).Select(v => v.Avaliacao)?.Sum(a => a?.Nota) / v.Vendedor.Vendas.Where(v => v.Avaliacao != null).Select(v => v.Avaliacao).Count() > 0 ? v.Vendedor.Vendas.Where(v => v.Avaliacao != null).Select(v => v.Avaliacao).Count() : 1,
                ehCriadorDaVenda = v.Vendedor.Id == IdUsuarioLogado,
                LocalVenda = v.LocalVenda,
                DataExpiracao = v.DataExpiracao,
                DescricaoCategoria = v.Categoria.Descricao,
                Questionamentos = v.Questionamentos,
                Avaliacao = v.Avaliacao,
                Status = v.StatusVenda.Descricao,
                NomeVendedor = v.Vendedor.Nome,
                ehParaComprar = v.Vendedor.Id != IdUsuarioLogado && v.Comprador == null && v.StatusVenda.Id != 3,
                ehParaCancelar =  v.Comprador?.Id == IdUsuarioLogado && v.StatusVenda.Id != 3,
                ehParaRejeitar = v.Comprador?.Id != IdUsuarioLogado && v.Vendedor.Id == IdUsuarioLogado && v.StatusVenda.Id != 3

            }).ToList();

        }

        public VendaDTO GetVendaById(int IdVenda)
        {
            return this.GetAll().Where(v => v.Id == IdVenda).Select(v => new VendaDTO()
            {
                Id = v.Id,
                Titulo = v.Titulo,
                Descricao = v.Descricao,
                Imagem = v.Imagem,
                Preco = v.Preco,
                NotaVendedor = v.Vendedor.Vendas.Where(v => v.Avaliacao != null).Select(v => v.Avaliacao)?.Sum(a => a?.Nota) / v.Vendedor.Vendas.Where(v => v.Avaliacao != null).Select(v => v.Avaliacao).Count() > 0 ? v.Vendedor.Vendas.Where(v => v.Avaliacao != null).Select(v => v.Avaliacao).Count() : 1,
                LocalVenda = v.LocalVenda,
                DataExpiracao = v.DataExpiracao,
                DescricaoCategoria = v.Categoria.Descricao,
                Questionamentos = v.Questionamentos,
                Avaliacao = v.Avaliacao,
                Status = v.StatusVenda.Descricao,
                IdStatus = v.StatusVenda.Id,
                NomeVendedor = v.Vendedor.Nome,

            }).FirstOrDefault();

        }

        public List<VendaDTO> GetVendasComFiltro(int IdUsuarioLogado, string filtro)
        {
            return this.GetAll().Where(v => v.StatusVenda.Id < 3 && 
                (v.StatusVenda.Descricao.Contains(filtro) || v.Titulo.Contains(filtro) || v.Categoria.Descricao.Contains(filtro) ||
                 v.Descricao.Contains(filtro) || v.Preco.ToString().Equals(filtro.Replace(".", ",")) || v.LocalVenda.Contains(filtro)                
                
                )
                
            ).Select(v => new VendaDTO()
            {
                Id = v.Id,
                Titulo = v.Titulo,
                Descricao = v.Descricao,
                Imagem = v.Imagem,
                Preco = v.Preco,
                NotaVendedor = v.Vendedor.Vendas.Where(v => v.Avaliacao != null).Select(v => v.Avaliacao)?.Sum(a => a?.Nota) / v.Vendedor.Vendas.Where(v => v.Avaliacao != null).Select(v => v.Avaliacao).Count() > 0 ? v.Vendedor.Vendas.Where(v => v.Avaliacao != null).Select(v => v.Avaliacao).Count() : 1,
                ehCriadorDaVenda = v.Vendedor.Id == IdUsuarioLogado,
                LocalVenda = v.LocalVenda,
                IdStatus = v.StatusVenda.Id,
                DataExpiracao = v.DataExpiracao,
                DescricaoCategoria = v.Categoria.Descricao,
                Questionamentos = v.Questionamentos,
                Avaliacao = v.Avaliacao,
                Status = v.StatusVenda.Descricao,
                NomeVendedor = v.Vendedor.Nome,
                ehParaComprar = v.Vendedor.Id != IdUsuarioLogado && v.Comprador == null && v.StatusVenda.Id != 3,
                ehParaCancelar = v.Comprador != null && v.Comprador.Id == IdUsuarioLogado && v.StatusVenda.Id != 3,
                ehParaRejeitar = v.Comprador != null && v.Vendedor.Id == IdUsuarioLogado && v.StatusVenda.Id != 3

            }).ToList();

        }


        public List<VendaDTO> GetMinhasCompras(int IdUsuarioLogado)
        {
            return this.GetAll().Where(v => v.Comprador?.Id == IdUsuarioLogado && v.StatusVenda.Id == 3).Select(v => new VendaDTO()
            {
                Id = v.Id,
                Titulo = v.Titulo,
                Descricao = v.Descricao,
                Imagem = v.Imagem,
                Preco = v.Preco,
                ehCriadorDaVenda = v.Vendedor.Id == IdUsuarioLogado,
                NotaVendedor = v.Vendedor.Vendas.Where(v => v.Avaliacao != null).Select(v => v.Avaliacao)?.Sum(a => a?.Nota) /  v.Vendedor.Vendas.Where(v=> v.Avaliacao != null).Select(v => v.Avaliacao).Count() > 0? v.Vendedor.Vendas.Where(v => v.Avaliacao != null).Select(v => v.Avaliacao).Count(): 1,
                LocalVenda = v.LocalVenda,
                DataExpiracao = v.DataExpiracao,
                DescricaoCategoria = v.Categoria.Descricao,
                Questionamentos = v.Questionamentos,
                Avaliacao = v.Avaliacao,
                IdStatus = v.StatusVenda.Id,
                Status = v.StatusVenda.Descricao,
                NomeVendedor = v.Vendedor.Nome,
                ehParaComprar = v.Vendedor.Id != IdUsuarioLogado && v.Comprador == null && v.StatusVenda.Id != 3,
                ehParaCancelar = v.Comprador != null && v.Comprador.Id == IdUsuarioLogado && v.StatusVenda.Id != 3,
                ehParaRejeitar = v.Comprador != null && v.Vendedor.Id == IdUsuarioLogado && v.StatusVenda.Id != 3

            }).ToList();

        }

        public void DesativarVendasDosUltimos45Dias(StatusVenda statusVendaCancelado)
        {
            var vendas = GetAll().Where(v => v.StatusVenda.Id < 3 &&  v.DataCadastro >= DateTime.Now.AddDays(45));
            foreach(var venda in vendas)
            {
                venda.DataExpiracao = DateTime.Now;
                venda.StatusVenda = statusVendaCancelado;
            }

            UpdateRange(vendas);

        }

        public int GetTotalVendas()
        {
            return GetAll().Count();
        }

        public int GetTotalExpirados()
        {
            return GetAll().Where(v=> v.StatusVenda.Id == 5).Count();
        }

        public int GetTotalCancelado()
        {
            return GetAll().Where(v => v.StatusVenda.Id == 4).Count();
        }

        public int GetTotalVendidos()
        {
            return GetAll().Where(v => v.StatusVenda.Id == 3).Count();
        }

        public List<UsuarioInfoDTO> GetInfoAdminVendedores(List<Usuario> vendedores)
        {

            List<UsuarioInfoDTO> infoVendedores = new List<UsuarioInfoDTO>();
            foreach(var vendedor in vendedores)
            {

                infoVendedores.Add(new UsuarioInfoDTO()
                {
                    Id = vendedor.Id,
                    Nome = vendedor.Nome,
                    Avaliacao = (float)(vendedor.Vendas.Where(v => v.Avaliacao != null).Select(v => v.Avaliacao)?.Sum(a => a?.Nota) / (vendedor.Vendas.Where(v => v.Avaliacao != null).Select(v => v.Avaliacao).Count() > 0 ? vendedor.Vendas.Where(v => v.Avaliacao != null).Select(v => v.Avaliacao).Count() : 1)),
                    TotalProdutosOfertados = vendedor.Vendas.Count(),
                    TotalProdutosVendidos = vendedor.Vendas.Where(v=> v.StatusVenda.Id == 3).Count(),
                    TotalQuestionamentos = vendedor.Vendas.Select(v=> v.Questionamentos).Count(),
                    TotalRespostas = vendedor.Vendas.SelectMany(v=> v.Questionamentos.Where(q=> q.Resposta != null).Select(q=> q.Resposta)).Count()

                });

            }

            return infoVendedores;
        }

    }
}