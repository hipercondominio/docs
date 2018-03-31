using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class AgendaSemana
    {
        public int IdAgendaSemana { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdCondominio { get; set; }
        public int IdAgendaPeriodo { get; set; }
        public bool Seg { get; set; }
        public bool Ter { get; set; }
        public bool Qua { get; set; }
        public bool Qui { get; set; }
        public bool Sex { get; set; }
        public bool Sáb { get; set; }
        public bool Dom { get; set; }

        public AgendaPeriodo IdAgendaPeriodoNavigation { get; set; }
        public Condominio IdCondominioNavigation { get; set; }
    }
}
