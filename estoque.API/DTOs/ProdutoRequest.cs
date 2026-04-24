namespace estoque.API.DTOs;

public class ProdutoRequest
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
}
