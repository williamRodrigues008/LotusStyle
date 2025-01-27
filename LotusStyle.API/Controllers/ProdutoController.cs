using LotusStyle.API.Datas;
using LotusStyle.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace LotusStyle.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly ILeituraEscritaProduto _leituraEscritaProduto;
        private readonly DbContexto _dbContexto;

        public ProdutoController(ILeituraEscritaProduto leituraEscritaProduto, DbContexto dbContexto)
        {
            _leituraEscritaProduto = leituraEscritaProduto;
            _dbContexto = dbContexto;
        }

        [HttpGet("BuscarProdutos")]
        public IActionResult GetAll()
        {
            var listaProdutos = _leituraEscritaProduto.BuscarTodosProdutos();
            if(listaProdutos == null) 
                return NotFound("Produtos não localizados na base de dados");

            return Ok(listaProdutos);
        }

        [HttpGet("BuscarProdutosPorNome/{nome}")]
        public IActionResult BuscarProdutosPorNome(string nome) 
        {
            var listaProdutos = _leituraEscritaProduto.BuscarProdutosPorNome(nome);
            if (listaProdutos == null)
                return NotFound("Não existem produtos com este nome.");

            return Ok(listaProdutos);
        }

        [HttpGet("BuscarProdutosPorMarca/{marca}")]
        public IActionResult BuscarProdutosPorMarca(string marca) 
        {
            var listaProdutos = _leituraEscritaProduto.BuscarProdutosPorMarca(marca);
            if (listaProdutos == null)
                return NotFound("Não existem produtos desta marca.");

            return Ok(listaProdutos);
        }

        [HttpGet("BuscarProdutoPorId/{id}")]
        public IActionResult BuscarProdutosPorId(int id) 
        {
            var listaProdutos = _leituraEscritaProduto.BuscarProdutosPorId(id);
            if (listaProdutos == null)
                return NotFound("Falha na busca do item selecionado.");

            return Ok(listaProdutos);
        }

        [HttpGet("BuscarProdutosPorTipo/{tipo}")]
        public IActionResult BuscarProdutosPorTipo(string tipo) 
        {
            var listaProdutos = _leituraEscritaProduto.BuscarProdutosPorTipo(tipo);
            if (listaProdutos == null)
                return NotFound("Não localizei nenhum produto desse tipo");

            return Ok(listaProdutos);
        }

        [HttpGet("PedidosPorUltimo")]
        public IActionResult PedidosPorUltimo() 
        {
            var listaProdutos = _leituraEscritaProduto.BuscarProdutosPedidosPorUltimo();
            if (listaProdutos == null)
                return NotFound("Não existem produtos com este nome.");

            return Ok(listaProdutos);
        }

        [HttpGet("MaisPedidos")]
        public IActionResult MaisPedidos() 
        {
            var listaProdutos = _leituraEscritaProduto.BuscarProdutosMaisPedidos();
            if (listaProdutos == null)
                return NotFound("Não existem produtos com este nome.");

            return Ok(listaProdutos);
        }
    }
}
