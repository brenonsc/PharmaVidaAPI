using Microsoft.EntityFrameworkCore;
using PharmaVida.Data;
using PharmaVida.Model;

namespace PharmaVida.Service.Implements;

public class ProdutoService : IProdutoService
{
    private readonly AppDbContext _context;
    
    public ProdutoService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Produto>> GetAll()
    {
        return await _context.Produtos
            .ToListAsync();
    }

    public async Task<Produto?> GetById(long id)
    {
        try
        {
            var produto = await _context.Produtos
                .FirstAsync(i => i.Id == id);
            return produto;
        }
        catch
        {
            return null;
        }
    }

    public async Task<IEnumerable<Produto>> GetByTitulo(string titulo)
    {
        var produto = await _context.Produtos
            .Where(t => t.Titulo.Contains(titulo)).ToListAsync();
        return produto;
    }

    public async Task<Produto?> Create(Produto produto)
    {
        await _context.Produtos.AddAsync(produto);
        await _context.SaveChangesAsync();
        
        return produto;
    }

    public async Task<Produto?> Update(Produto produto)
    {
        var produtoUpdate = await _context.Produtos.FindAsync(produto.Id);

        if (produtoUpdate == null)
            return null;
        
        _context.Entry(produtoUpdate).State = EntityState.Detached;
        _context.Entry(produto).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return produto;
    }

    public async Task Delete(Produto produto)
    {
        _context.Remove(produto);
        
        await _context.SaveChangesAsync();
    }
}