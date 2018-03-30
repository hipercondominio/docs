using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
	class AreaComum_Regra
	{
		public int ID_REGRA_AREA_COMUM { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int QTDE_VEZES { get; set; }
		public int QTDE_PERIODO { get; set; }
		public int TEMPO { get; set; }
		public int ID_PESSOA { get; set; }
	}
}
