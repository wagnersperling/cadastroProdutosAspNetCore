using Dev.WS.Business.Models;
using System;
using System.Threading.Tasks;

namespace Dev.WS.Business.Interfaces
{
    public interface IFornecedorService : IDisposable
    {
        Task Adicionar(Fornecedor fornecedor);
        Task Atualizar(Fornecedor fornecedor);
        Task Remover(Guid id);
        Task AtualizarEndereco(Endereco endereco);
    }
}
