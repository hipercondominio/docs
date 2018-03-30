using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
	class Permissao
	{
		public int ID_PERMISSAO { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_CONDOMINIO { get; set; }
		public int ID_PESSOA { get; set; }
		public int ID_SUBMODULO { get; set; }
		public bool LEITURA { get; set; }
		public bool ESCRITA { get; set; }
		public bool REMOCAO { get; set; }
		public bool ACESSO { get; set; }
	}
}
