using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
	class Submodulo
	{
		public int ID_SUBMODULO { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_MODULO { get; set; }
		public string TITULO { get; set; }
		public string DESCRICAO { get; set; }
	}
}
