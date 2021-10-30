using Dev.WS.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dev.WS.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        Task<Produto> ObterProdutoFornecedores(Guid id);
    }
}
