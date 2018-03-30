using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
	class Agenda_Periodo
	{
		public int ID_AGENDA_PERIODO { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_CONDOMINIO { get; set; }
		public int QTDE_REPETICAO { get; set; }
		public int TIPO_REPETICAO { get; set; }
		public int QTDE_OCORRENCIA { get; set; }
		public DateTime DTA_TERMINO { get; set; }
	}
}
