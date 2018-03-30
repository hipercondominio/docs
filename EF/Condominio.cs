using System;

namespace EF
{
	public class Condominio
	{
		public int ID_CONDOMINIO { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL {get;set;}
		public string NOME { get; set; }
		public string APELIDO { get; set; }
		public string CNPJ { get; set; }
		

	}
}
