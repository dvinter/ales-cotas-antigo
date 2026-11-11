using AlesCotas.Application.DTOs;
using AlesCotas.Application.DTOs.Cadastro;
using AlesCotas.Application.DTOs.Filtros;
using AlesCotas.Application.DTOs.Users;
using AlesCotas.Domain.Entities;
using AlesCotas.Domain.Filtros;
using AutoMapper;

namespace AlesCotas.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            // Produto Tipo
            CreateMap<ProdutoTipo, ProdutoTipoDTO>().ReverseMap();
            CreateMap<ProdutoTipoFiltroDTO, ProdutoTipoFiltro>();

            // Produto
            CreateMap<ProdutoCadastroDTO, Produto>();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<ProdutoFiltroDTO, ProdutoFiltro>();

            // Solicitacao
            CreateMap<SolicitacaoCadastroDTO, Solicitacao>();
            CreateMap<SolicitacaoItemCadastroDTO, SolicitacaoItem>();
            CreateMap<Solicitacao, SolicitacaoDTO>().ReverseMap();
            CreateMap<SolicitacaoItem, SolicitacaoItemDTO>().ReverseMap();
            CreateMap<SolicitacaoFiltroDTO, SolicitacaoFiltro>();

            CreateMap<SolicitacaoItemArquivoDTO, SolicitacaoItemArquivo>().ReverseMap();
            CreateMap<SolicitacaoItemCRDTO, SolicitacaoItemCR>().ReverseMap();

            // Solicitacao - Copia Reprográfica
            CreateMap<GrampeamentoTipo, GrampeamentoTipoDTO>();


            //Usuario
            CreateMap<UsuarioFiltroDto, UsuarioFiltro>();
            CreateMap<UsuarioFiltro , UsuarioFiltroDto>();
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<Usuario , UsuarioDto>().ForMember(p => p.GabineteName, opt => opt.MapFrom(src=> src.Gabinete.Nome));


            //Usuario
            CreateMap<GabineteFiltroDto, GabineteFiltro>();
            CreateMap<GabineteFiltro, GabineteFiltroDto>();
            CreateMap<GabineteDto, Gabinete>();
            CreateMap<Gabinete, GabineteDto>();



        }
    }
}
