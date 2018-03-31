using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class Permissao
    {
        public int IdPermissao { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdCondominio { get; set; }
        public int IdPessoa { get; set; }
        public int IdSubmodulo { get; set; }
        public bool? Leitura { get; set; }
        public bool? Escrita { get; set; }
        public bool? Remocao { get; set; }
        public bool? Acesso { get; set; }

        public Condominio IdCondominioNavigation { get; set; }
        public Pessoa IdPessoaNavigation { get; set; }
        public Submodulo IdSubmoduloNavigation { get; set; }
    }
}
