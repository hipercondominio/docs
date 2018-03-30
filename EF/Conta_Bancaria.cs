using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
	class Conta_Bancaria
	{
		public int ID_CONTA_BANCARIA { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public int ID_CONDOMINIO { get; set; }
		public int ID_BANCO { get; set; }
		public string NOME { get; set; }
		public int TIPO { get; set; }
		public string AGENCIA { get; set; }
		public string CONTA { get; set; }
		public DateTime INICIO{ get; set; }
		public decimal SALDO { get; set; }
		public int ORDEM { get; set; }
		public bool PRINCIPAL { get; set; }
	}
}
