using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class Modulo
    {
        public Modulo()
        {
            Submodulo = new HashSet<Submodulo>();
        }

        public int IdModulo { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Plano { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorPlano { get; set; }

        public ICollection<Submodulo> Submodulo { get; set; }
    }
}
