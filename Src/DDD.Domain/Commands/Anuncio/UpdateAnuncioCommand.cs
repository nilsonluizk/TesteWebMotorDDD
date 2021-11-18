using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain.Validations.Anuncio;

namespace DDD.Domain.Commands.Anuncio
{
    public class UpdateAnuncioCommand : AnuncioCommand
    {
        public UpdateAnuncioCommand(Guid id, string marca, string modelo, string versao, int ano, int quilometragem, string observacao)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Versao = versao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = observacao;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateAnuncioCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
