using System.Collections.Generic;

namespace Locadora.Entities
{
    public partial class Locacao : BaseEntity
    {

        public Locacao()
        {
            LocacaoItems = new HashSet<LocacaoItem>();
        }

        public long IdCliente { get; set; }

        public Cliente Clientes { get; set; }

        public ICollection<LocacaoItem> LocacaoItems { get; set; }
    } 
}
