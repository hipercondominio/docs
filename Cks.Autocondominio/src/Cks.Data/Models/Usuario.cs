using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class Usuario
    {
        public Guid Id { get; set; }
        public string Usuario1 { get; set; }
        public string Sexo { get; set; }
        public DateTime Nascimento { get; set; }
        public Guid? CidadeId { get; set; }

        public Cidade Cidade { get; set; }
    }
}
