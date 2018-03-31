using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class TipoLeitura
    {
        public TipoLeitura()
        {
            Leitura = new HashSet<Leitura>();
        }

        public int IdTipoLeitura { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdCondominio { get; set; }
        public string Nome { get; set; }
        public string Unidade { get; set; }
        public DateTime DtaFechamento { get; set; }

        public Condominio IdCondominioNavigation { get; set; }
        public ICollection<Leitura> Leitura { get; set; }
    }
}
