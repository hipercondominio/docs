using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
	class Agenda
	{
		public int ID_AGENDA { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_PESSOA { get; set; }
		public int ID_CONDOMINIO { get; set; }
		public int ID_AGENDA_PERIODO { get; set; }
		public string ATIVIDADE { get; set; }
		public DateTime DTA_COMECO { get; set; }
		public DateTime DTA_TERMINO { get; set; }
		public string DESCRICAO { get; set; }
		public int SITUACAO { get; set; }
		public string COR { get; set; }
		public bool OCUPADO { get; set; }
	}
}
