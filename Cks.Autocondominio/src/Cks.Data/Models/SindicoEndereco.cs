﻿using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class SindicoEndereco
    {
        public int IdSindicoEndereco { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdSindicoCondominio { get; set; }
        public int IdEndereco { get; set; }

        public Endereco IdEnderecoNavigation { get; set; }
        public Pessoa IdSindicoCondominioNavigation { get; set; }
    }
}
