using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
    class Condominio_Endereco
    {
		public int ID_CONDOMINIO_ENDERECO { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_CONDOMINIO { get; set; }
		public int ID_ENDERECO { get; set; }
	}
}
