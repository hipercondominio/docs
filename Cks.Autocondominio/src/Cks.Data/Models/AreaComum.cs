using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class AreaComum
    {
        public AreaComum()
        {
            ReservaAreaComum = new HashSet<ReservaAreaComum>();
        }

        public int IdAreaComum { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdCondominio { get; set; }
        public int IdCustoAreaComum { get; set; }
        public int IdRegraAreaComum { get; set; }
        public int IdExclusividadeAreaComum { get; set; }
        public string Nome { get; set; }
        public decimal Capacidade { get; set; }
        public string Descricao { get; set; }
        public string RegrasUso { get; set; }

        public Condominio IdCondominioNavigation { get; set; }
        public CustoAreaComum IdCustoAreaComumNavigation { get; set; }
        public ExclusividadeAreaComum IdExclusividadeAreaComumNavigation { get; set; }
        public RegraAreaComum IdRegraAreaComumNavigation { get; set; }
        public ICollection<ReservaAreaComum> ReservaAreaComum { get; set; }
    }
}
