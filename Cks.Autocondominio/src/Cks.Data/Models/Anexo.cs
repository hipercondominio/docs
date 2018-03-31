using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class Anexo
    {
        public int IdAnexo { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public string Nome { get; set; }
        public string Tags { get; set; }
        public string Conteudo { get; set; }
        public string Pasta { get; set; }
        public string Documento { get; set; }
        public string Extensao { get; set; }
    }
}
