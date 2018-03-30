using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
	class AreaComum_Reserva
	{
		public int ID_RESERVA_AREA_COMUM { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_CONDOMINIO { get; set; }
		public int ID_AREA_COMUM { get; set; }
		public int ID_PESSOA { get; set; }
		public int SITUACAO { get; set; }
		public int PERIODO { get; set; }
	}
}
