using LotusStyle.API.Entities;

namespace LotusStyle.API.Interfaces
{
    public interface IEscritaProduto
    {
        void CriarProduto(Produto produto);
        Task AtualizarProduto(Produto produto);
        Task RemoverProduto(int id);
    }
}
