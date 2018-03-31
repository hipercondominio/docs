using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class Veiculo
    {
        public int IdVeiculo { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdCondominio { get; set; }
        public int IdMarca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Ano { get; set; }
        public string Vaga { get; set; }

        public Condominio IdCondominioNavigation { get; set; }
        public MarcaVeiculo IdMarcaNavigation { get; set; }
    }
}
