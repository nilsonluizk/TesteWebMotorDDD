using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DDD.Domain.CommandHandlers.Model.Responses;
using DDD.Domain.Commands;
using DDD.Domain.Commands.Anuncio;
using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Notifications;
using DDD.Domain.Events;
using DDD.Domain.Events.Anuncio;
using DDD.Domain.Interfaces;
using DDD.Domain.Models;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace DDD.Domain.CommandHandlers
{
    public class AnuncioCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewAnuncioCommand, bool>,
        IRequestHandler<UpdateAnuncioCommand, bool>,
        IRequestHandler<RemoveAnuncioCommand, bool>
    {
        private readonly IMediatorHandler Bus;
        private readonly IAnuncioRepository _anuncioRepository;
        private readonly IConfiguration _configuration;

        public AnuncioCommandHandler(IConfiguration configuration,
                                      IAnuncioRepository anuncioRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _configuration = configuration;
            _anuncioRepository = anuncioRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewAnuncioCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var customer = new Anuncio(Guid.NewGuid(), message.Marca, message.Modelo, message.Versao, message.Ano, message.Quilometragem, message.Observacao);
            //Consumo de APIs, como não foi descrito o que deveria fazer com estas respostas, apenas chamo as APIs e desserializo.
            RestClient clientMarca = new RestClient(_configuration.GetSection("WebMotorsRequestsLinks:Marca").Get<string>());
            IRestRequest requestMarca = new RestRequest(Method.GET);
            IRestResponse responseMarca = clientMarca.Execute(requestMarca);
            var jsonMarca = JsonConvert.DeserializeObject<List<MarcaResponse>>(responseMarca.Content);

            RestClient clientModelo = new RestClient(_configuration.GetSection("WebMotorsRequestsLinks:Modelo").Get<string>());
            IRestRequest requestModelo = new RestRequest(Method.GET);
            IRestResponse responseModelo = clientModelo.Execute(requestModelo);
            var jsonModelo = JsonConvert.DeserializeObject<List<ModeloResponse>>(responseModelo.Content);

            RestClient clientVersao = new RestClient(_configuration.GetSection("WebMotorsRequestsLinks:Versao").Get<string>());
            IRestRequest requestVersao = new RestRequest(Method.GET);
            IRestResponse responseVersao = clientVersao.Execute(requestVersao);
            var jsonVersao = JsonConvert.DeserializeObject<List<VersaoResponse>>(responseVersao.Content);

            _anuncioRepository.Add(customer);

            if (Commit())
            {
                Bus.RaiseEvent(new AnuncioRegisteredEvent(customer.Id, customer.Marca, customer.Modelo, customer.Versao, customer.Ano, customer.Quilometragem, customer.Observacao));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateAnuncioCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var customer = new Anuncio(message.Id, message.Marca, message.Modelo, message.Versao, message.Ano, message.Quilometragem, message.Observacao);

            _anuncioRepository.Update(customer);

            if (Commit())
            {
                Bus.RaiseEvent(new AnuncioUpdatedEvent(customer.Id, customer.Marca, customer.Modelo, customer.Versao, customer.Ano, customer.Quilometragem, customer.Observacao));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveAnuncioCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _anuncioRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new AnuncioRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _anuncioRepository.Dispose();
        }
    }
}
