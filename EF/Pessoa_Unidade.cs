using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
    class Pessoa_Unidade
    {
		public int ID_PESSOA_UNIDADE {get;set;}
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_PESSOA { get; set; }
		public int ID_UNIDADE { get; set; }
		public bool SITUACAO { get; set; }
	}
}
