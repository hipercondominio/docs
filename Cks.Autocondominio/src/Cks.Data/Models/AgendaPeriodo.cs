using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class AgendaPeriodo
    {
        public AgendaPeriodo()
        {
            Agenda = new HashSet<Agenda>();
            AgendaSemana = new HashSet<AgendaSemana>();
        }

        public int IdAgendaPeriodo { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdCondominio { get; set; }
        public int QtdeRepeticao { get; set; }
        public int TipoRepeticao { get; set; }
        public int QtdeOcorrencia { get; set; }
        public DateTime DtaTermino { get; set; }

        public Condominio IdCondominioNavigation { get; set; }
        public ICollection<Agenda> Agenda { get; set; }
        public ICollection<AgendaSemana> AgendaSemana { get; set; }
    }
}
