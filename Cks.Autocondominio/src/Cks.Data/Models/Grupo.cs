using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            GrupoPessoa = new HashSet<GrupoPessoa>();
        }

        public int IdGrupo { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdCondominio { get; set; }
        public string NomeGrupo { get; set; }

        public Condominio IdCondominioNavigation { get; set; }
        public ICollection<GrupoPessoa> GrupoPessoa { get; set; }
    }
}
