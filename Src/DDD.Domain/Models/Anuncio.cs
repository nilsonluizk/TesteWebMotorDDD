using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Domain.Core.Models;

namespace DDD.Domain.Models
{
    public class Anuncio : EntityAudit
    {
        public Anuncio(Guid id, string marca, string modelo, string versao, int ano, int quilometragem, string observacao)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Versao = versao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = observacao;
        }

        // Empty constructor for EF
        protected Anuncio() { }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }
    }
}
