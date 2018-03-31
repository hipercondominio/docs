using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class RegraAreaComum
    {
        public RegraAreaComum()
        {
            AreaComum = new HashSet<AreaComum>();
        }

        public int IdRegraAreaComum { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int QtdeVezes { get; set; }
        public int QtdePeriodo { get; set; }
        public int Tempo { get; set; }
        public int IdPessoa { get; set; }

        public Pessoa IdPessoaNavigation { get; set; }
        public ICollection<AreaComum> AreaComum { get; set; }
    }
}
