using PharmaVida.Model;

namespace PharmaVida.Service;

public interface IProdutoService
{
    Task<IEnumerable<Produto>> GetAll();
    
    Task<Produto?> GetById(long id);
    
    Task<IEnumerable<Produto>> GetByTitulo(string titulo);
    
    Task<Produto?> Create(Produto produto);
    
    Task<Produto?> Update(Produto produto);
    
    Task Delete(Produto produto);
}