using System.Dynamic;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using FluentAssertions;
using Newtonsoft.Json;
using PharmaVida.Model;
using PharmaVidaTest.Factory;
using Xunit.Extensions.Ordering;

namespace PharmaVidaTest.Controller;

public class ProdutoControllerTest : IClassFixture<WebAppFactory>
{
    protected readonly WebAppFactory _factory;
    protected HttpClient _client;
    
    private string Id { get; set; } = string.Empty;
    
    public ProdutoControllerTest(WebAppFactory factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Fact, Order(1)]
    public async Task DeveListarTodosOsProdutos()
    {
        var resposta = await _client.GetAsync("/api/produtos/");

        resposta.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact, Order(2)]
    public async Task DeveCriarUmProduto()
    {
        var novoProduto = new Dictionary<string, string>()
        {
            { "titulo", "Paracetamol" },
            { "fabricante", "Medley" }, 
            { "dosagememmg", "1000" },
            { "precisareceita", "true" },
            { "datavencimento", "2025-10-10"},
            { "preco", "23.00" },
            { "categoriaId", "1" }
        };
        
        var produtoJson = JsonConvert.SerializeObject(novoProduto);
        var corpoRequisicao = new StringContent(produtoJson, Encoding.UTF8, "application/json");
        
        var resposta = await _client.PostAsync("/api/produtos/", corpoRequisicao);
        resposta.EnsureSuccessStatusCode();
        resposta.StatusCode.Should().Be(HttpStatusCode.Created);
    }
    
    [Fact, Order(3)]
    public async Task DeveListarUmProduto()
    {
        Id = "1";
        
        var resposta = await _client.GetAsync($"/api/produtos/{Id}");

        resposta.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Fact, Order(4)]
    public async Task DeveAtualizarUmProduto()
    {
        var novoProduto = new Dictionary<string, string>()
        {
            { "titulo", "Omeprazol" },
            { "fabricante", "Genérico" }, 
            { "dosagememmg", "300" },
            { "precisareceita", "true" },
            { "datavencimento", "2025-10-10"},
            { "preco", "13.00" },
            { "categoriaId", "1" }
        };
        
        var produtoJson = JsonConvert.SerializeObject(novoProduto);
        var corpoRequisicao = new StringContent(produtoJson, Encoding.UTF8, "application/json");
        
        var resposta = await _client.PostAsync("/api/produtos/", corpoRequisicao);
        
        var corpoRespostaPost = await resposta.Content.ReadFromJsonAsync<Produto>();
        
        if(corpoRespostaPost != null)
            Id = corpoRespostaPost.Id.ToString();

        var produtoAtualizado = new Dictionary<string, string>()
        {
            { "id", Id },
            { "titulo", "Omeprazol" },
            { "fabricante", "Genérico" }, 
            { "dosagememmg", "300" },
            { "precisareceita", "true" },
            { "datavencimento", "2025-10-10"},
            { "preco", "15.00" },
            { "categoriaId", "1" }
        };
        
        var produtoJsonAtualizado = JsonConvert.SerializeObject(produtoAtualizado);
        var corpoRequisicaoAtualizado = new StringContent(produtoJsonAtualizado, Encoding.UTF8, "application/json");
        
        var respostaPut = await _client.PutAsync("/api/produtos/", corpoRequisicaoAtualizado);
        
        respostaPut.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Fact, Order(5)]
    public async Task DeveListarUmProdutoPorTitulo()
    {
        var titulo = "Para";
        
        var resposta = await _client.GetAsync($"/api/produtos/titulo/{titulo}");

        resposta.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact, Order(6)]
    public async Task NaoDeveCadastrarProdutoPorTituloComMuitosCaracteres()
    {
        var novoProduto = new Dictionary<string, string>()
        {
            { "titulo", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." },
            { "fabricante", "Genérico" }, 
            { "dosagememmg", "300" },
            { "precisareceita", "true" },
            { "datavencimento", "2025-10-10"},
            { "preco", "13.00" },
            { "categoriaId", "1" }
        };
        
        var produtoJson = JsonConvert.SerializeObject(novoProduto);
        var corpoRequisicao = new StringContent(produtoJson, Encoding.UTF8, "application/json");
        
        var resposta = await _client.PostAsync("/api/produtos/", corpoRequisicao);
        
        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact, Order(7)]
    public async Task DeveDeletarUmProduto()
    {
        Id = "1";
        
        var resposta = await _client.DeleteAsync($"/api/produtos/{Id}");

        resposta.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}