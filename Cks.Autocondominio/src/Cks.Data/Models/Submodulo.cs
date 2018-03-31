using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class Submodulo
    {
        public Submodulo()
        {
            Permissao = new HashSet<Permissao>();
        }

        public int IdSubmodulo { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdModulo { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public Modulo IdModuloNavigation { get; set; }
        public ICollection<Permissao> Permissao { get; set; }
    }
}
