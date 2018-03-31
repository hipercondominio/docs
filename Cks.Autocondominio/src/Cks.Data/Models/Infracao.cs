using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class Infracao
    {
        public int IdInfracao { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdCondominio { get; set; }
        public int IdSindicoCondominio { get; set; }
        public int IdUnidade { get; set; }
        public int TipoInfracao { get; set; }
        public string Descricao { get; set; }
        public decimal? Valor { get; set; }
        public bool? EnviarMail { get; set; }

        public Condominio IdCondominioNavigation { get; set; }
        public SindicoCondominio IdSindicoCondominioNavigation { get; set; }
        public Unidade IdUnidadeNavigation { get; set; }
    }
}
