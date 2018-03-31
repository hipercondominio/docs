using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class SindicoCondominio
    {
        public SindicoCondominio()
        {
            Infracao = new HashSet<Infracao>();
        }

        public int IdSindicoCondominio { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdCondominio { get; set; }
        public int IdPessoa { get; set; }
        public DateTime DtaMandato { get; set; }
        public DateTime DtaTermino { get; set; }

        public Condominio IdCondominioNavigation { get; set; }
        public Pessoa IdPessoaNavigation { get; set; }
        public ICollection<Infracao> Infracao { get; set; }
    }
}
