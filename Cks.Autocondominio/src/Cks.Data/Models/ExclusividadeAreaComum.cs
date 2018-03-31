using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class ExclusividadeAreaComum
    {
        public ExclusividadeAreaComum()
        {
            AreaComum = new HashSet<AreaComum>();
        }

        public int IdExclusividadeAreaComum { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int TipoLote { get; set; }
        public string Complemento { get; set; }

        public ICollection<AreaComum> AreaComum { get; set; }
    }
}
