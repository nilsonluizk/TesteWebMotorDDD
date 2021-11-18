using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain.Commands;
using DDD.Domain.Commands.Anuncio;

namespace DDD.Domain.Validations.Anuncio
{
    class RemoveAnuncioCommandValidation : AnuncioValidation<RemoveAnuncioCommand>
    {
        public RemoveAnuncioCommandValidation()
        {
            ValidateId();
        }
    }
}
