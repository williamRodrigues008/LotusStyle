using LotusStyle.API.Datas;
using LotusStyle.API.Entities;
using LotusStyle.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace LotusStyle.API.Services
{
    public class ProdutosService : ILeituraEscritaProduto
    {
        private readonly DbContexto _ctx;

        public ProdutosService(DbContexto ctx)
        {
            _ctx = ctx;
        }

        public List<Produto> BuscarProdutosMaisPedidos()
        {
            List<Produto> listaProduto = new List<Produto>();
            var vendido = _ctx.ProdutoVendido
                .Select(p => new
                {
                    p.Id,
                    p.IdProduto,
                    p.Produto,
                    p.DataVenda
                })
                .Take(12)
                .GroupBy(p => p.Produto.Nome);

            var prod = JsonConvert.DeserializeObject<List<ProdutoVendido>>(vendido.ToString())!;
            foreach (var item in prod) 
            {
                listaProduto.Add(item.Produto!);
            }
            return listaProduto;
        }

        public List<Produto> BuscarProdutosPedidosPorUltimo()
        {
            List<Produto> listaProduto = new List<Produto>();
            var vendido = _ctx.ProdutoVendido
                .Select(p => new
                {
                    p.Id,
                    p.Produto,
                    p.DataVenda
                })
                .Take(10)
                .OrderByDescending(p=> p.DataVenda);

            return listaProduto;
        }

        public Produto BuscarProdutosPorId(int id)
        {
            return _ctx.Produto.FirstOrDefault(p => p.Id == id)!;
        }

        public List<Produto> BuscarProdutosPorMarca(string marca)
        {
            var listaProdutosMarca = _ctx.Produto.Where(p => p.Marca == marca).Select(p => new
            {
                p.Nome,
                p.Imagem,
                p.Preco,
                p.LinhaProduto,
                p.CodProduto,
                p.Descricao,
                p.NacionalImportado,
                p.Tipo,
                p.Marca
            });
            return JsonConvert.DeserializeObject<List<Produto>>(listaProdutosMarca.ToString())!;
        }

        public List<Produto> BuscarProdutosPorNome(string nome)
        {
            var listaProdutosNome = _ctx.Produto.Where(p => p.Nome == nome).Select(p => new
            {
                p.Nome,
                p.Imagem,
                p.Preco,
                p.LinhaProduto,
                p.CodProduto,
                p.Descricao,
                p.NacionalImportado,
                p.Tipo,
                p.Marca
            });
            return JsonConvert.DeserializeObject<List<Produto>>(listaProdutosNome.ToString())!;
        }

        public List<Produto> BuscarProdutosPorTipo(string tipo)
        {
            var listaProdutosTipo = _ctx.Produto.Where(p => p.Tipo == tipo).Select(p => new
            {
                p.Nome,
                p.Imagem,
                p.Preco,
                p.LinhaProduto,
                p.CodProduto,
                p.Descricao,
                p.NacionalImportado,
                p.Tipo,
                p.Marca
            });
            return JsonConvert.DeserializeObject<List<Produto>>(listaProdutosTipo.ToString())!;
        }

        public List<Produto> BuscarTodosProdutos()
        {
            return _ctx.Produto.ToList();
        }

        public async void CriarProduto(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.Nome)) return;

            await _ctx.Produto.AddAsync(produto);
        }

        public async Task AtualizarProduto(Produto produto)
        {
            var prodFound = BuscarProdutosPorId(produto.Id);
            if (string.IsNullOrEmpty(prodFound.Nome))
                return;

            prodFound.Nome = produto.Nome;
            prodFound.Imagem = produto.Imagem;
            prodFound.LinhaProduto = produto.LinhaProduto;
            prodFound.CodProduto = produto.CodProduto;
            prodFound.Preco = prodFound.Preco;
            prodFound.Descricao = produto.Descricao;
            prodFound.NacionalImportado = produto.NacionalImportado;
            prodFound.Tipo = produto.Tipo;
            prodFound.Marca = produto.Marca;

            _ctx.Update(prodFound);
            await _ctx.SaveChangesAsync();
        }

        public async Task RemoverProduto(int id)
        {
            Produto? prod = BuscarProdutosPorId(id);
            if (string.IsNullOrEmpty(prod.Nome)) return;

            _ctx.Produto.Remove(prod);
            
        }
    }
}
