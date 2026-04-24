namespace estoque.API.Services;
using estoque.API.Models;

public class ProdutoService
{
    private List<Produto> produtos = new List<Produto>();
    public List<Produto> Listar() => produtos;
    public void Adicionar(Produto produto)
    {
        produtos.Add(produto);
    }
    public Produto? BuscarPorNome(string nome)
    {
        return produtos.FirstOrDefault(p => p.Nome == nome);
    }
}
