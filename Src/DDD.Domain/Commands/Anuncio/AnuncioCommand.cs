using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain.Core.Commands;

namespace DDD.Domain.Commands.Anuncio
{
    public abstract class AnuncioCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }
    }
}
