using AutoMapper;
using TarefasApi.models;
using TarefasApi.Dto;
using TarefasApi.Dto.Categoria;

namespace TarefasApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Tarefa, TarefasDto>();
            //.ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria != null?src.Categoria.Nome : string.Empty));

        CreateMap<TarefasDto, Tarefa>().ForMember(dest => dest.Categoria, opt => opt.Ignore());

        CreateMap<CriarTarefaDto, Tarefa>();

        CreateMap<AtualizaTarefaDto, Tarefa>();

        CreateMap<Categoria, CategoriasDto>();
    }
}

