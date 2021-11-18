using System;
using DDD.Domain.Core.Events;

namespace DDD.Domain.Events.Anuncio
{
    public class AnuncioUpdatedEvent : Event
    {
        public AnuncioUpdatedEvent(Guid id, string marca, string modelo, string versao, int ano, int quilometragem, string observacao)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Versao = versao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = observacao;
            AggregateId = id;
        }
        public Guid Id { get; protected set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Observacao { get; set; }
    }
}
