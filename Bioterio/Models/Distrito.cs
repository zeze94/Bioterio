﻿using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class Distrito
    {
        public Distrito()
        {
            Conselho = new HashSet<Conselho>();
        }

        public int Id { get; set; }
        public string NomeDistrito { get; set; }

        public ICollection<Conselho> Conselho { get; set; }
    }
}
