namespace LotusStyle.API.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public int CodProduto { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Marca { get; set; }
        public string? Tipo { get; set; }
        public string? LinhaProduto { get; set; }
        public string? NacionalImportado { get; set; }
        public string? Imagem { get; set; }
        public decimal Preco { get; set; }
        public ProdutoVendido? Vendido { get; set; }
    }
}
