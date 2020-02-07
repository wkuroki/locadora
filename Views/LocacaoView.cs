using Locadora.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Models
{
    public class LocacaoView
    {
        public LocacaoView()
        {
            LocacaoItems = new List<LocacaoItemView>();

        }
        public LocacaoView(Locacao Locacao)
        {
            this.Id = Locacao.Id;
            this.IdCliente = Locacao.IdCliente;


            this.Nome = Locacao.Clientes.Nome.ToString();
            this.LocacaoItems = Locacao.LocacaoItems.Select(e => new LocacaoItemView(e)).ToList();
        }

        public long Id { get; set; }
        public long IdCliente { get; set; }
        public string Nome { get; set; }

        public List<LocacaoItemView> LocacaoItems { get; set; }

        public Locacao ToLocacao()
        {
            return new Locacao()
            {
                Id = this.Id,
                IdCliente = this.IdCliente,
                LocacaoItems = LocacaoItems.Select(e => e.ToLocacaoItem(this.Id)).ToList(),
            };
        }

    }
}
