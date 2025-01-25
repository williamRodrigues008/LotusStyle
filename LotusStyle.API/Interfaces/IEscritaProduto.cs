using LotusStyle.API.Entities;

namespace LotusStyle.API.Interfaces
{
    public interface IEscritaProduto
    {
        Produto CriarProduto(Produto produto);
        Produto AtualizarProduto(Produto produto);
        Produto RemoverProduto(int id);
    }
}
