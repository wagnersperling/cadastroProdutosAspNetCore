using Dev.WS.Business.Interfaces;
using Dev.WS.Business.Models;
using Dev.WS.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace Dev.WS.Business.Services
{
    public class FornecedoresService : BaseService, IFornecedoresService
    {
        public async Task Adicionar(Fornecedor fornecedor)
        {
            //var validator = new FornecedorValidation();
            //var result = validator.Validate(fornecedor);
            //if (!result.IsValid)
            //{
            //    //result.Errors;
            //}
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)
                && !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;

            return;
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;
        }

        public async Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
