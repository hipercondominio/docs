using System;
using System.Collections.Generic;

namespace Cks.Data.Models
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Agenda = new HashSet<Agenda>();
            ConselhoCondominio = new HashSet<ConselhoCondominio>();
            Contato = new HashSet<Contato>();
            GrupoPessoa = new HashSet<GrupoPessoa>();
            Permissao = new HashSet<Permissao>();
            PessoaUnidade = new HashSet<PessoaUnidade>();
            RegraAreaComum = new HashSet<RegraAreaComum>();
            ReservaAreaComum = new HashSet<ReservaAreaComum>();
            ResidenteIdPessoaResidenteNavigation = new HashSet<Residente>();
            ResidenteIdPessoaUnidadeNavigation = new HashSet<Residente>();
            SindicoCondominio = new HashSet<SindicoCondominio>();
            SindicoEndereco = new HashSet<SindicoEndereco>();
        }

        public int IdPessoa { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaUpdate { get; set; }
        public bool Delet { get; set; }
        public int IdResponsavel { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public bool Sexo { get; set; }
        public DateTime DtaNascimeno { get; set; }
        public string Mail { get; set; }
        public string Senha { get; set; }

        public ICollection<Agenda> Agenda { get; set; }
        public ICollection<ConselhoCondominio> ConselhoCondominio { get; set; }
        public ICollection<Contato> Contato { get; set; }
        public ICollection<GrupoPessoa> GrupoPessoa { get; set; }
        public ICollection<Permissao> Permissao { get; set; }
        public ICollection<PessoaUnidade> PessoaUnidade { get; set; }
        public ICollection<RegraAreaComum> RegraAreaComum { get; set; }
        public ICollection<ReservaAreaComum> ReservaAreaComum { get; set; }
        public ICollection<Residente> ResidenteIdPessoaResidenteNavigation { get; set; }
        public ICollection<Residente> ResidenteIdPessoaUnidadeNavigation { get; set; }
        public ICollection<SindicoCondominio> SindicoCondominio { get; set; }
        public ICollection<SindicoEndereco> SindicoEndereco { get; set; }
    }
}
