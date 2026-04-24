namespace estoque.API.Controllers;

using estoque.API.DTOs;
using estoque.API.Models;
using estoque.API.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly ProdutoService _service;

    public ProdutoController(ProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        var produtos = _service.Listar()
            .Select(p => new ProdutoResponse
            {
                Nome = p.Nome,
                Quantidade = p.Quantidade,
                Preco = p.Preco
            });

        return Ok(produtos);
    }

    [HttpPost]
    public IActionResult Adicionar([FromBody] ProdutoRequest request)
    {
        var produto = new Produto
        {
            Nome = request.Nome,
            Quantidade = request.Quantidade,
            Preco = request.Preco
        };

        _service.Adicionar(produto);

        return Created("", new
        {
            mensagem = "Produto criado com sucesso",
            sucesso = true
        });
    }

    [HttpPut("baixa")]
    public IActionResult DarBaixa(string nome, int quantidade)
    {
        try
        {
            var resultado = _service.DarBaixa(nome, quantidade);
            if (!resultado)
                return NotFound("Produto não encontrado.");

            return Ok(new
            {
                mensagem = "Baixa realizada com sucesso",
                sucesso = true
            });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
