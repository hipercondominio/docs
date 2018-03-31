using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class ModuloCondominio
    {
        public int IdModuloCondominio { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdCondominio { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DtaRenovacao { get; set; }

        public Condominio IdCondominioNavigation { get; set; }
    }
}
