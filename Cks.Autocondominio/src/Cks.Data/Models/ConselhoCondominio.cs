using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class ConselhoCondominio
    {
        public int IdConselhoCondominio { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdCondominio { get; set; }
        public int IdPessoa { get; set; }
        public DateTime DtaMandato { get; set; }
        public DateTime DtaTermino { get; set; }
        public int Tipo { get; set; }

        public Condominio IdCondominioNavigation { get; set; }
        public Pessoa IdPessoaNavigation { get; set; }
    }
}
