using System;
using DDD.Domain.Commands;
using DDD.Domain.Commands.Anuncio;
using FluentValidation;


namespace DDD.Domain.Validations.Anuncio
{
    public abstract class AnuncioValidation<T> : AbstractValidator<T> where T : AnuncioCommand
    {
        protected void ValidateMarca()
        {
            RuleFor(c => c.Marca)
                .NotEmpty().WithMessage("Por favor, insira uma marca");
        }

        protected void ValidateModelo()
        {
            RuleFor(c => c.Modelo)
                .NotEmpty()
                .NotEmpty().WithMessage("Por favor, insira um modelo");
        }
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
