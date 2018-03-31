using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            Usuario = new HashSet<Usuario>();
        }

        public Guid Id { get; set; }
        public string Cidade1 { get; set; }
        public string Uf { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
