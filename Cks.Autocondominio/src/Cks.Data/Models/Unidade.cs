using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class Unidade
    {
        public Unidade()
        {
            Infracao = new HashSet<Infracao>();
            PessoaUnidade = new HashSet<PessoaUnidade>();
        }

        public int IdUnidade { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdCondominio { get; set; }
        public int TipoLote { get; set; }
        public int NumeroTipoLote { get; set; }
        public int NumeroAndar { get; set; }
        public int NumeroUnidade { get; set; }
        public int Situacao { get; set; }

        public Condominio IdCondominioNavigation { get; set; }
        public ICollection<Infracao> Infracao { get; set; }
        public ICollection<PessoaUnidade> PessoaUnidade { get; set; }
    }
}
