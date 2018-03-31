using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class Contato
    {
        public int IdContato { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdPessoa { get; set; }
        public int Tipo { get; set; }
        public string Ddd { get; set; }
        public string Telefone { get; set; }

        public Pessoa IdPessoaNavigation { get; set; }
    }
}
