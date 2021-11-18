using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain.Validations.Anuncio;

namespace DDD.Domain.Commands.Anuncio
{
    public class RemoveAnuncioCommand : AnuncioCommand
    {
        public RemoveAnuncioCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveAnuncioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
