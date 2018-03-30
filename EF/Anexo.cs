using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
	class Anexo
	{
		public int ID_ANEXO { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public string NOME { get; set; }
		public string TAGS { get; set; }
		public string CONTEUDO { get; set; }
		public string PASTA { get; set; }
		public string DOCUMENTO { get; set; }
		public string EXTENSAO { get; set; }
	}
}
