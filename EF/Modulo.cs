using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
	class Modulo
	{
		public int ID_MODULO { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public string NOME { get; set; }
		public string DESCRICAO { get; set; }
		public string PLANO { get; set; }
		public decimal VALOR { get; set; }
		public decimal VALOR_PLANO { get; set; }
	}
}
