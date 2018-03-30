using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
    class Residente
    {
		public int ID_RESIDENTE { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_CONDOMINIO { get; set; }
		public int ID_PESSOA_UNIDADE { get; set; }
		public int ID_PESSOA_RESIDENTE { get; set; }
	}
}
