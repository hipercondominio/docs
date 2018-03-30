using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
	class Sindico_Endereco
	{
		public int ID_SINDICO_ENDERECO { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_SINDICO_CONDOMINIO { get; set; }
		public int ID_ENDERECO { get; set; }
	}
}
