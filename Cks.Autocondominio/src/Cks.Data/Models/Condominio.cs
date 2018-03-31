using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class Condominio
    {
        public Condominio()
        {
            Agenda = new HashSet<Agenda>();
            AgendaPeriodo = new HashSet<AgendaPeriodo>();
            AgendaSemana = new HashSet<AgendaSemana>();
            AreaComum = new HashSet<AreaComum>();
            CondominioEndereco = new HashSet<CondominioEndereco>();
            ConselhoCondominio = new HashSet<ConselhoCondominio>();
            ContaBancaria = new HashSet<ContaBancaria>();
            Grupo = new HashSet<Grupo>();
            Infracao = new HashSet<Infracao>();
            Leitura = new HashSet<Leitura>();
            ModuloCondominio = new HashSet<ModuloCondominio>();
            Permissao = new HashSet<Permissao>();
            ReservaAreaComum = new HashSet<ReservaAreaComum>();
            Residente = new HashSet<Residente>();
            SindicoCondominio = new HashSet<SindicoCondominio>();
            TipoLeitura = new HashSet<TipoLeitura>();
            Unidade = new HashSet<Unidade>();
            Veiculo = new HashSet<Veiculo>();
        }

        public int IdCondominio { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public string Nome { get; set; }
        public string Aplido { get; set; }
        public decimal Cnpj { get; set; }

        public ICollection<Agenda> Agenda { get; set; }
        public ICollection<AgendaPeriodo> AgendaPeriodo { get; set; }
        public ICollection<AgendaSemana> AgendaSemana { get; set; }
        public ICollection<AreaComum> AreaComum { get; set; }
        public ICollection<CondominioEndereco> CondominioEndereco { get; set; }
        public ICollection<ConselhoCondominio> ConselhoCondominio { get; set; }
        public ICollection<ContaBancaria> ContaBancaria { get; set; }
        public ICollection<Grupo> Grupo { get; set; }
        public ICollection<Infracao> Infracao { get; set; }
        public ICollection<Leitura> Leitura { get; set; }
        public ICollection<ModuloCondominio> ModuloCondominio { get; set; }
        public ICollection<Permissao> Permissao { get; set; }
        public ICollection<ReservaAreaComum> ReservaAreaComum { get; set; }
        public ICollection<Residente> Residente { get; set; }
        public ICollection<SindicoCondominio> SindicoCondominio { get; set; }
        public ICollection<TipoLeitura> TipoLeitura { get; set; }
        public ICollection<Unidade> Unidade { get; set; }
        public ICollection<Veiculo> Veiculo { get; set; }
    }
}
