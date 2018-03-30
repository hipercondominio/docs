﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
	class Leitura
	{
		public int ID_LEITURA { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_CONDOMINIO { get; set; }
		public int ID_TIPO_LEITURA { get; set; }
		public int ID_UNIDADE { get; set; }
		public DateTime DTA_LEITURA { get; set; }
		public decimal VALOR { get; set; }
	}
}
