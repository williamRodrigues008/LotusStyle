using LotusStyle.API.Entities;

namespace LotusStyle.API.Interfaces
{
    public interface ILeituraProduto
    {
        List<Produto> BuscarTodosProdutos();
        List<Produto> BuscarProdutosPorMarca(string marca);
        List<Produto> BuscarProdutosPorTipo(string tipo);
        List<Produto> BuscarProdutosPorNome(string nome);
        List<Produto> BuscarProdutosPedidosPorUltimo();
        Produto BuscarProdutosPorId(int id);
        List<Produto> BuscarProdutosMaisPedidos();

    }
}
