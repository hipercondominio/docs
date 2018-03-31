using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class PessoaUnidade
    {
        public int IdPessoaUnidade { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdPessoa { get; set; }
        public int IdUnidade { get; set; }
        public bool Situacao { get; set; }

        public Pessoa IdPessoaNavigation { get; set; }
        public Unidade IdUnidadeNavigation { get; set; }
    }
}
