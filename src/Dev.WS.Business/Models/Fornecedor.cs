using System.Collections.Generic;

namespace Dev.WS.Business.Models
{
    public class Fornecedor : Entity
    {        
        public string Nome { get; set; }        
        public string Documento { get; set; }
        public int TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }       
        public bool Ativo { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }    
}
