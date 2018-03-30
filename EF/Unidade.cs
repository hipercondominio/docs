using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
    class Unidade
    {

		public int ID_UNIDADE { get; set; }
		public DateTime  DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool  DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int  ID_CONDOMINIO { get; set; }
		public int TIPO_LOTE { get; set; }
		public int  NUMERO_TIPO_LOTE { get; set; }
		public int NUMERO_ANDAR { get; set; }
		public int  NUMERO_UNIDADE { get; set; }
		public int SITUACAO { get; set; }

	}
}
