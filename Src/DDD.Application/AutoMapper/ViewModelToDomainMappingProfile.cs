using AutoMapper;
using DDD.Application.ViewModels;
using DDD.Domain.Commands;
using DDD.Domain.Commands.Anuncio;

namespace DDD.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {

            CreateMap<AnuncioViewModel, RegisterNewAnuncioCommand>()
               .ConstructUsing(c => new RegisterNewAnuncioCommand(c.Marca, c.Modelo, c.Versao, c.Ano, c.Quilometragem, c.Observacao));
            CreateMap<AnuncioViewModel, UpdateAnuncioCommand>()
                .ConstructUsing(c => new UpdateAnuncioCommand(c.Id, c.Marca, c.Modelo, c.Versao, c.Ano, c.Quilometragem, c.Observacao));
        }
    }
}
