using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DDD.Application.Interfaces;
using DDD.Application.ViewModels;
using DDD.Domain.Commands;
using DDD.Domain.Commands.Anuncio;
using DDD.Domain.Core.Bus;
using DDD.Domain.Interfaces;
using DDD.Domain.Specifications;
using DDD.Infra.Data.Repository.EventSourcing;


namespace DDD.Application.Services
{
    public class AnuncioAppService : IAnuncioAppService
    {
        private readonly IMapper _mapper;
        private readonly IAnuncioRepository _anuncioRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public AnuncioAppService(IMapper mapper,
                                  IAnuncioRepository anuncioRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _anuncioRepository = anuncioRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<AnuncioViewModel> GetAll()
        {
            return _anuncioRepository.GetAll().ProjectTo<AnuncioViewModel>(_mapper.ConfigurationProvider);
        }

        public AnuncioViewModel GetById(Guid id)
        {
            return _mapper.Map<AnuncioViewModel>(_anuncioRepository.GetById(id));
        }

        public void Register(AnuncioViewModel AnuncioViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewAnuncioCommand>(AnuncioViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(AnuncioViewModel AnuncioViewModel)
        {
            var updateCommand = _mapper.Map<UpdateAnuncioCommand>(AnuncioViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveAnuncioCommand(id);
            Bus.SendCommand(removeCommand);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
