using System;
using System.Collections.Generic;
using System.Text;

namespace EF
{
    class Pessoa
    {
		public int ID_PESSOA{ get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_UPDATE { get; set; }
		public bool DELET { get; set; }
		public int ID_RESPONSAVEL { get; set; }
		public string NOME { get; set; }
		public string CPF { get; set; }
		public string RG { get; set; }
		public bool SEXO { get; set; }
		public DateTime DTA_NASCIMENTO { get; set; }
		public string MAIL { get; set; }
		public string SENHA { get; set; }


	}
}
