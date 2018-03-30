using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
    class Veiculo
    {
		public int ID_VEICULO { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_CONDOMINIO { get; set; }
		public int ID_MARCA { get; set; }
		public string MODELO { get; set; }
		public string PLACA { get; set; }
		public string ANO { get; set; }
		public string VAGA { get; set; }

	}
}
