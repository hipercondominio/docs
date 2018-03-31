using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class Agenda
    {
        public int IdAgenda { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdPessoa { get; set; }
        public int IdCondominio { get; set; }
        public int IdAgendaPeriodo { get; set; }
        public string Atividade { get; set; }
        public DateTime DtaComeco { get; set; }
        public DateTime DtaTermino { get; set; }
        public string Descricao { get; set; }
        public int Situacao { get; set; }
        public string Cor { get; set; }
        public bool Ocupado { get; set; }

        public AgendaPeriodo IdAgendaPeriodoNavigation { get; set; }
        public Condominio IdCondominioNavigation { get; set; }
        public Pessoa IdPessoaNavigation { get; set; }
    }
}
