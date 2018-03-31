using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class CondominioEndereco
    {
        public int IdCondominioEndereco { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdCondominio { get; set; }
        public int IdEndereco { get; set; }

        public Condominio IdCondominioNavigation { get; set; }
        public Endereco IdEnderecoNavigation { get; set; }
    }
}
