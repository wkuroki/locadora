using Locadora.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Models
{
    public class LocacaoView
    {
        public LocacaoView()
        {
            Locacao = new List<LocacaoItemView>();

        }
        public LocacaoView(Locacao Locacao)
        {
            this.Id = Locacao.Id;
            this.IdCliente = Locacao.IdCliente;


            this.NomeCliente = Locacao.Clientes.Nome.ToString();
            this.Locacao = Locacao.LocacaoItems.Select(e => new LocacaoItemView(e)).ToList();
        }

        public long Id { get; set; }
        public long IdCliente { get; set; }
        public string NomeCliente { get; set; }

        public List<LocacaoItemView> Locacao { get; set; }

        public Locacao ToLocacao()
        {
            return new Locacao()
            {
                Id = this.Id,
                IdCliente = this.IdCliente,
                LocacaoItems = Locacao.Select(e => e.ToLocacaoItem(this.Id)).ToList(),
            };
        }
    }
}
