using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
	class Endereco
	{
		public int ID_ENDERECO { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public string CEP { get; set; }
		public string LOGRADOURO { get; set; }
		public string NUMERO { get; set; }
		public string BAIRRO { get; set; }
		public string CIDADE { get; set; }
		public string ESTADO { get; set; }

	}
}
