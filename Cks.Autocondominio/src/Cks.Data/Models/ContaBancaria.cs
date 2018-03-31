using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class ContaBancaria
    {
        public int IdContaBancaria { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public int IdCondominio { get; set; }
        public int IdBanco { get; set; }
        public string Nome { get; set; }
        public int Tipo { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public DateTime Inicio { get; set; }
        public decimal Saldo { get; set; }
        public int Ordem { get; set; }
        public bool Principal { get; set; }

        public Banco IdBancoNavigation { get; set; }
        public Condominio IdCondominioNavigation { get; set; }
    }
}
