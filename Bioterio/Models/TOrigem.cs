﻿using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class TOrigem
    {
        public TOrigem()
        {
            RegNovosAnimais = new HashSet<RegNovosAnimais>();
        }

        public int IdTOrigem { get; set; }
        public string Descrição { get; set; }

        public ICollection<RegNovosAnimais> RegNovosAnimais { get; set; }
    }
}
