using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
	class Agenda_Semana
	{
		public int ID_AGENDA_SEMANA { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_CONDOMINIO { get; set; }
		public int ID_AGENDA_PERIODO { get; set; }
		public bool SEG { get; set; }
		public bool TER { get; set; }
		public bool QUA { get; set; }
		public bool QUI { get; set; }
		public bool SEX { get; set; }
		public bool SÁB { get; set; }
		public bool DOM { get; set; }
	}
}
