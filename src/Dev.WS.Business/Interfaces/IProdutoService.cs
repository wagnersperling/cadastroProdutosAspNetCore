using Dev.WS.Business.Models;
using System;
using System.Threading.Tasks;

namespace Dev.WS.Business.Interfaces
{
    public interface IProdutoService
    {
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
    }
}
