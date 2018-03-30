using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
    class Conselho_Condominio
	{
		public int ID_CONSELHO_CONDOMINIO { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_CONDOMINIO { get; set; }
		public int ID_PESSOA { get; set; }
		public DateTime DTA_MANDATO { get; set; }
		public DateTime DTA_TERMINO { get; set; }
		public int TIPO { get; set; }
	}
}
