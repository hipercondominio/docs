using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class MarcaVeiculo
    {
        public MarcaVeiculo()
        {
            Veiculo = new HashSet<Veiculo>();
        }

        public int IdMarcaVeiculo { get; set; }
        public string Marca { get; set; }

        public ICollection<Veiculo> Veiculo { get; set; }
    }
}
