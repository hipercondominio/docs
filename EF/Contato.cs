using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
	class Contato
	{
		public int ID_CONTATO { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_PESSOA { get; set; }
		public int TIPO { get; set; }
		public string DDD { get; set; }
		public string TELEFONE { get; set; }
	}
}
