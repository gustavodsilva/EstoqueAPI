namespace estoque.API.Controllers;
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
        return Ok(_service.Listar());
    }

    [HttpPost]
    public IActionResult Adicionar([FromBody] Produto produto)
    {
        _service.Adicionar(produto);
        return Ok("Produto adicionado com sucesso");
    }
}
