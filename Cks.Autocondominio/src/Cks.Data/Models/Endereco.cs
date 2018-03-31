using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class Endereco
    {
        public Endereco()
        {
            CondominioEndereco = new HashSet<CondominioEndereco>();
            SindicoEndereco = new HashSet<SindicoEndereco>();
        }

        public int IdEndereco { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public ICollection<CondominioEndereco> CondominioEndereco { get; set; }
        public ICollection<SindicoEndereco> SindicoEndereco { get; set; }
    }
}
