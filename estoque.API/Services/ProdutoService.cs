namespace estoque.API.Services;
using estoque.API.Models;
using System;

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

    public bool DarBaixa(string nome, int quantidade)
    {
        var produto = produtos.FirstOrDefault(p => p.Nome == nome);
        if (produto == null)
            return false;

        if (quantidade > produto.Quantidade)
            throw new Exception("Estoque insuficiente");

        produto.Quantidade -= quantidade;
        return true;
    }
}
