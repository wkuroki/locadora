using System;
using System.Collections.Generic;

namespace Locadora.Entities
{
    public partial class LocacaoItem : BaseEntity

    {
        public LocacaoItem()
        {

        }

        public long IdLocacao { get; set; }
        public long IdFilme { get; set; }
        public string Descricao { get; set; }
        public Locacao Locacao { get; set; }

    }
}
