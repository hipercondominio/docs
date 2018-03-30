using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
	class AreaComum
	{
		public int ID_AREA_COMUM { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_CONDOMINIO { get; set; }
		public int ID_CUSTO_AREA_COMUM { get; set; }
		public int ID_REGRA_AREA_COMUM { get; set; }
		public int ID_EXCLUSIVIDADE_AREA_COMUM { get; set; }
		public string NOME { get; set; }
		public int CAPACIDADE { get; set; }
		public string DESCRICAO { get; set; }
		public string REGRAS_USO { get; set; }
	}
}
