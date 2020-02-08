﻿using System;
using System.Collections.Generic;

namespace Locadora.Entities
{
    public partial class Cliente : BaseEntity
    {
        public Cliente()
        {

        }

        public string Nome { get; set; }
        public string Apelido { get; set; }

        public ICollection<Locacao> Locacao { get; set; }
    }
}
