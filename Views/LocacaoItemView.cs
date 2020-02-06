﻿
using Locadora.Entities;

namespace Locadora.Models
{
    public class LocacaoItemView
    {
        public LocacaoItemView()
        {

        }

        public LocacaoItemView(LocacaoItem LocacaoItem)
        {
            Id = LocacaoItem.Id;
            IdFilme = LocacaoItem.IdFilme;
            Descricao = LocacaoItem.Descricao;
            Excluido = false;
        }

        public long Id { get; set; }
        public long IdFilme { get; set; }
        public string Descricao { get; set; }
        public bool Excluido { get; set; }

        public LocacaoItem ToLocacaoItem()
        {
            return new LocacaoItem()
            {
                Id = Id,
                IdFilme = IdFilme,
                Descricao = Descricao,
                Excluido = Excluido
            };
        }

        public LocacaoItem ToLocacaoItem(long pIdLocacao)
        {
            return new LocacaoItem()
            {
                IdLocacao = pIdLocacao,
                Id = Id,
                IdFilme = IdFilme,
                Descricao = Descricao,
                Excluido = Excluido
            };
        }

    }
}