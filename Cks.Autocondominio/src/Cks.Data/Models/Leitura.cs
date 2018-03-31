using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class Leitura
    {
        public int IdLeitura { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdCondominio { get; set; }
        public int IdTipoLeitura { get; set; }
        public int IdUnidade { get; set; }
        public DateTime DtaLeitura { get; set; }
        public decimal Valor { get; set; }

        public Condominio IdCondominioNavigation { get; set; }
        public TipoLeitura IdTipoLeituraNavigation { get; set; }
    }
}
