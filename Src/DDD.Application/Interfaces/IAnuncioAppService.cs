using System;
using System.Collections.Generic;
using DDD.Application.ViewModels;

namespace DDD.Application.Interfaces
{
    public interface IAnuncioAppService : IDisposable
    {
        void Register(AnuncioViewModel AnuncioViewModel);
        IEnumerable<AnuncioViewModel> GetAll();
        AnuncioViewModel GetById(Guid id);
        void Update(AnuncioViewModel AnuncioViewModel);
        void Remove(Guid id);
    }
}
