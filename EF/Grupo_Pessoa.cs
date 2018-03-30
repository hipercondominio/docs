using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
	class Grupo_Pessoa
	{
		public int ID_GRUPO_PESSOA { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_PESSOA { get; set; }
		public int ID_GRUPO { get; set; }
	}
}
