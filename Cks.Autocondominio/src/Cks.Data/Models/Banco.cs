using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class Banco
    {
        public Banco()
        {
            ContaBancaria = new HashSet<ContaBancaria>();
        }

        public int IdBanco { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int CodBano { get; set; }
        public string Nome { get; set; }
        public string Website { get; set; }

        public ICollection<ContaBancaria> ContaBancaria { get; set; }
    }
}
