﻿using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class AgenteTrat
    {
        public AgenteTrat()
        {
            RegTratamento = new HashSet<RegTratamento>();
        }

        public int IdAgenTra { get; set; }
        public string NomeAgenTra { get; set; }

        public ICollection<RegTratamento> RegTratamento { get; set; }
    }
}
