using System;
using DDD.Application.Interfaces;
using DDD.Application.ViewModels;
using DDD.Domain.Core.Bus;
using DDD.Domain.Core.Notifications;
using DDD.Infra.CrossCutting.Identity.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Services.Api.Controllers
{
    [Authorize]
    public class AnuncioController : ApiController
    {
        private readonly IAnuncioAppService _anuncioAppService;

        public AnuncioController(
            IAnuncioAppService anuncioAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _anuncioAppService = anuncioAppService;
        }

        [HttpGet]
        [Route("obtertodos")]
        public IActionResult Get()
        {
            return Response(_anuncioAppService.GetAll());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var customerViewModel = _anuncioAppService.GetById(id);

            return Response(customerViewModel);
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Post([FromBody] AnuncioViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            _anuncioAppService.Register(customerViewModel);

            return Response(customerViewModel);
        }

        [HttpPut]
        [Route("atualizar")]
        public IActionResult Put([FromBody] AnuncioViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(customerViewModel);
            }

            _anuncioAppService.Update(customerViewModel);

            return Response(customerViewModel);
        }

        [HttpDelete]
        [Route("deletar")]
        public IActionResult Delete(Guid id)
        {
            _anuncioAppService.Remove(id);

            return Response();
        }
    }
}
