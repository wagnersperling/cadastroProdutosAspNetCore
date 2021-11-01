using AutoMapper;
using Dev.WS.Business.Models;
using DevWS.App.ViewModels;

namespace DevWS.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}


//Instalar o automapper
//Install-Package automapper.extensions.microsoft.dependencyinjection -v 6.1.0