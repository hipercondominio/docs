using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
	class AreaComum_Custo
	{
		public int ID_CUSTO_AREA_COMUM { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_CONTA_CATEGORIA { get; set; }
		public decimal VALOR { get; set; }
		public DateTime PGTO_DIA { get; set; }
		public bool PGTO_TAXA_CONDOMINIAL { get; set; }
	}
}
