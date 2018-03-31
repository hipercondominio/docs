using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class ReservaAreaComum
    {
        public int IdReservaAreaComum { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdCondominio { get; set; }
        public int IdAreaComum { get; set; }
        public int IdPessoa { get; set; }
        public int Situacao { get; set; }
        public int Periodo { get; set; }

        public AreaComum IdAreaComumNavigation { get; set; }
        public Condominio IdCondominioNavigation { get; set; }
        public Pessoa IdPessoaNavigation { get; set; }
    }
}
