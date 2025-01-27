namespace LotusStyle.API.Entities
{
    public class ProdutoVendido
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public Produto? Produto { get; set; }
        public DateTime? DataVenda { get; set; }
    }
}
