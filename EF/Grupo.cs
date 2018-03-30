using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
	class Grupo
	{
		public int ID_GRUPO { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_CONDOMINIO { get; set; }
		public string NOME_GRUPO { get; set; }
	}
}
