using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class Residente
    {
        public int IdResidente { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdCondominio { get; set; }
        public int IdPessoaUnidade { get; set; }
        public int IdPessoaResidente { get; set; }

        public Condominio IdCondominioNavigation { get; set; }
        public Pessoa IdPessoaResidenteNavigation { get; set; }
        public Pessoa IdPessoaUnidadeNavigation { get; set; }
    }
}
