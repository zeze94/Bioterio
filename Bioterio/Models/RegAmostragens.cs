﻿using System;
using System.Collections.Generic;

namespace Bioterio.Models
{
    public partial class RegAmostragens
    {
        public int IdRegAmo { get; set; }
        public DateTime Data { get; set; }
        public double PesoMedio { get; set; }
        public int NroIndividuos { get; set; }
        public double PesoTotal { get; set; }
        public int TanqueIdTanque { get; set; }

        public Tanque TanqueIdTanqueNavigation { get; set; }
    }
}
