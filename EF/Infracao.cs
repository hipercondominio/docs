using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
	class Infracao
	{
		public int ID_INFRACAO { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_CONDOMINIO { get; set; }
		public int ID_SINDICO_CONDOMINIO { get; set; }
		public int ID_UNIDADE { get; set; }
		public int TIPO_INFRACAO { get; set; }
		public string DESCRICAO { get; set; }
		public decimal VALOR { get; set; }
		public bool ENVIAR_MAIL { get; set; }

	}
}
