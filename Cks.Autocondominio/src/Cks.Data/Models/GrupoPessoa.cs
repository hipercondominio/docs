using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class GrupoPessoa
    {
        public int IdGrupoPessoa { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdPessoa { get; set; }
        public int IdGrupo { get; set; }

        public Grupo IdGrupoNavigation { get; set; }
        public Pessoa IdPessoaNavigation { get; set; }
    }
}
