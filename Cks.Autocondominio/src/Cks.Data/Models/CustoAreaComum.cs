using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class CustoAreaComum
    {
        public CustoAreaComum()
        {
            AreaComum = new HashSet<AreaComum>();
        }

        public int IdCustoAreaComum { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int? IdContaCategoria { get; set; }
        public decimal Valor { get; set; }
        public DateTime PgtoDia { get; set; }
        public bool PgtoTaxaCondominial { get; set; }

        public ICollection<AreaComum> AreaComum { get; set; }
    }
}
