using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Cks.Data.Models;

namespace Cks.Data.Contexts
{
    public partial class DefaultContext : DbContext
    {
        public virtual DbSet<Agenda> Agenda { get; set; }
        public virtual DbSet<AgendaPeriodo> AgendaPeriodo { get; set; }
        public virtual DbSet<AgendaSemana> AgendaSemana { get; set; }
        public virtual DbSet<Anexo> Anexo { get; set; }
        public virtual DbSet<AreaComum> AreaComum { get; set; }
        public virtual DbSet<Banco> Banco { get; set; }
        public virtual DbSet<Condominio> Condominio { get; set; }
        public virtual DbSet<CondominioEndereco> CondominioEndereco { get; set; }
        public virtual DbSet<ConselhoCondominio> ConselhoCondominio { get; set; }
        public virtual DbSet<ContaBancaria> ContaBancaria { get; set; }
        public virtual DbSet<Contato> Contato { get; set; }
        public virtual DbSet<CustoAreaComum> CustoAreaComum { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<ExclusividadeAreaComum> ExclusividadeAreaComum { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<GrupoPessoa> GrupoPessoa { get; set; }
        public virtual DbSet<Infracao> Infracao { get; set; }
        public virtual DbSet<Leitura> Leitura { get; set; }
        public virtual DbSet<MarcaVeiculo> MarcaVeiculo { get; set; }
        public virtual DbSet<Modulo> Modulo { get; set; }
        public virtual DbSet<ModuloCondominio> ModuloCondominio { get; set; }
        public virtual DbSet<Permissao> Permissao { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<PessoaUnidade> PessoaUnidade { get; set; }
        public virtual DbSet<RegraAreaComum> RegraAreaComum { get; set; }
        public virtual DbSet<ReservaAreaComum> ReservaAreaComum { get; set; }
        public virtual DbSet<Residente> Residente { get; set; }
        public virtual DbSet<SindicoCondominio> SindicoCondominio { get; set; }
        public virtual DbSet<SindicoEndereco> SindicoEndereco { get; set; }
        public virtual DbSet<Submodulo> Submodulo { get; set; }
        public virtual DbSet<TipoLeitura> TipoLeitura { get; set; }
        public virtual DbSet<Unidade> Unidade { get; set; }
        public virtual DbSet<Veiculo> Veiculo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.DefaultConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agenda>(entity =>
            {
                entity.HasKey(e => e.IdAgenda);

                entity.ToTable("AGENDA");

                entity.Property(e => e.IdAgenda)
                    .HasColumnName("ID_AGENDA")
                    .ValueGeneratedNever();

                entity.Property(e => e.Atividade)
                    .IsRequired()
                    .HasColumnName("ATIVIDADE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Cor)
                    .IsRequired()
                    .HasColumnName("COR")
                    .HasColumnType("char(7)");

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.DtaComeco)
                    .HasColumnName("DTA_COMECO")
                    .HasColumnType("date");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaTermino)
                    .HasColumnName("DTA_TERMINO")
                    .HasColumnType("date");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdAgendaPeriodo).HasColumnName("ID_AGENDA_PERIODO");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.Ocupado).HasColumnName("OCUPADO");

                entity.Property(e => e.Situacao).HasColumnName("SITUACAO");

                entity.HasOne(d => d.IdAgendaPeriodoNavigation)
                    .WithMany(p => p.Agenda)
                    .HasForeignKey(d => d.IdAgendaPeriodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_ID_AGENDA_PERIODO_AGENDA");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.Agenda)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CONDOMINIO_AGENDA");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Agenda)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PESSOA_AGENDA");
            });

            modelBuilder.Entity<AgendaPeriodo>(entity =>
            {
                entity.HasKey(e => e.IdAgendaPeriodo);

                entity.ToTable("AGENDA_PERIODO");

                entity.Property(e => e.IdAgendaPeriodo)
                    .HasColumnName("ID_AGENDA_PERIODO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaTermino)
                    .HasColumnName("DTA_TERMINO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.QtdeOcorrencia).HasColumnName("QTDE_OCORRENCIA");

                entity.Property(e => e.QtdeRepeticao).HasColumnName("QTDE_REPETICAO");

                entity.Property(e => e.TipoRepeticao).HasColumnName("TIPO_REPETICAO");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.AgendaPeriodo)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CONDOMINIO_AGENDA_PERIODO");
            });

            modelBuilder.Entity<AgendaSemana>(entity =>
            {
                entity.HasKey(e => e.IdAgendaSemana);

                entity.ToTable("AGENDA_SEMANA");

                entity.Property(e => e.IdAgendaSemana)
                    .HasColumnName("ID_AGENDA_SEMANA")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.Dom).HasColumnName("DOM");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdAgendaPeriodo).HasColumnName("ID_AGENDA_PERIODO");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.Qua).HasColumnName("QUA");

                entity.Property(e => e.Qui).HasColumnName("QUI");

                entity.Property(e => e.Seg).HasColumnName("SEG");

                entity.Property(e => e.Sex).HasColumnName("SEX");

                entity.Property(e => e.Sáb).HasColumnName("SÁB");

                entity.Property(e => e.Ter).HasColumnName("TER");

                entity.HasOne(d => d.IdAgendaPeriodoNavigation)
                    .WithMany(p => p.AgendaSemana)
                    .HasForeignKey(d => d.IdAgendaPeriodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_AGENDA_PERIODO_AGENDA_SEMANA");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.AgendaSemana)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CONDOMINIO_AGENDA_SEMANA");
            });

            modelBuilder.Entity<Anexo>(entity =>
            {
                entity.HasKey(e => e.IdAnexo);

                entity.ToTable("ANEXO");

                entity.Property(e => e.IdAnexo)
                    .HasColumnName("ID_ANEXO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Conteudo)
                    .HasColumnName("CONTEUDO")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasColumnName("DOCUMENTO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Extensao)
                    .IsRequired()
                    .HasColumnName("EXTENSAO")
                    .HasColumnType("char(3)");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pasta)
                    .IsRequired()
                    .HasColumnName("PASTA")
                    .HasMaxLength(800)
                    .IsUnicode(false);

                entity.Property(e => e.Tags)
                    .HasColumnName("TAGS")
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AreaComum>(entity =>
            {
                entity.HasKey(e => e.IdAreaComum);

                entity.ToTable("AREA_COMUM");

                entity.Property(e => e.IdAreaComum)
                    .HasColumnName("ID_AREA_COMUM")
                    .ValueGeneratedNever();

                entity.Property(e => e.Capacidade)
                    .HasColumnName("CAPACIDADE")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.IdCustoAreaComum).HasColumnName("ID_CUSTO_AREA_COMUM");

                entity.Property(e => e.IdExclusividadeAreaComum).HasColumnName("ID_EXCLUSIVIDADE_AREA_COMUM");

                entity.Property(e => e.IdRegraAreaComum).HasColumnName("ID_REGRA_AREA_COMUM");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RegrasUso)
                    .IsRequired()
                    .HasColumnName("REGRAS_USO")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.AreaComum)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CONDOMINIO_AREA_COMUM");

                entity.HasOne(d => d.IdCustoAreaComumNavigation)
                    .WithMany(p => p.AreaComum)
                    .HasForeignKey(d => d.IdCustoAreaComum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CUSTO_AREA_COMUM_AREA_COMUM");

                entity.HasOne(d => d.IdExclusividadeAreaComumNavigation)
                    .WithMany(p => p.AreaComum)
                    .HasForeignKey(d => d.IdExclusividadeAreaComum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_EXCLUSIVIDADE_AREA_COMUM_AREA_COMUM");

                entity.HasOne(d => d.IdRegraAreaComumNavigation)
                    .WithMany(p => p.AreaComum)
                    .HasForeignKey(d => d.IdRegraAreaComum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_REGRA_AREA_COMUM_AREA_COMUM");
            });

            modelBuilder.Entity<Banco>(entity =>
            {
                entity.HasKey(e => e.IdBanco);

                entity.ToTable("BANCO");

                entity.Property(e => e.IdBanco)
                    .HasColumnName("ID_BANCO")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodBano).HasColumnName("COD_BANO");

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .IsRequired()
                    .HasColumnName("WEBSITE")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Condominio>(entity =>
            {
                entity.HasKey(e => e.IdCondominio);

                entity.ToTable("CONDOMINIO");

                entity.Property(e => e.IdCondominio)
                    .HasColumnName("ID_CONDOMINIO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Aplido)
                    .IsRequired()
                    .HasColumnName("APLIDO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj)
                    .HasColumnName("CNPJ")
                    .HasColumnType("numeric(14, 0)");

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CondominioEndereco>(entity =>
            {
                entity.HasKey(e => e.IdCondominioEndereco);

                entity.ToTable("CONDOMINIO_ENDERECO");

                entity.Property(e => e.IdCondominioEndereco)
                    .HasColumnName("ID_CONDOMINIO_ENDERECO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.IdEndereco).HasColumnName("ID_ENDERECO");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.CondominioEndereco)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CONDOMINIO_ENDERECO");

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.CondominioEndereco)
                    .HasForeignKey(d => d.IdEndereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_ENDERECO_CONDOMINIO_ENDERECO");
            });

            modelBuilder.Entity<ConselhoCondominio>(entity =>
            {
                entity.HasKey(e => e.IdConselhoCondominio);

                entity.ToTable("CONSELHO_CONDOMINIO");

                entity.Property(e => e.IdConselhoCondominio)
                    .HasColumnName("ID_CONSELHO_CONDOMINIO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaMandato)
                    .HasColumnName("DTA_MANDATO")
                    .HasColumnType("date");

                entity.Property(e => e.DtaTermino)
                    .HasColumnName("DTA_TERMINO")
                    .HasColumnType("date");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.Tipo).HasColumnName("TIPO");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.ConselhoCondominio)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CONDOMINIO_CONSELHO_CONDOMINIO");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.ConselhoCondominio)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PESSOA_CONSELHO_CONDOMINIO");
            });

            modelBuilder.Entity<ContaBancaria>(entity =>
            {
                entity.HasKey(e => e.IdContaBancaria);

                entity.ToTable("CONTA_BANCARIA");

                entity.Property(e => e.IdContaBancaria)
                    .HasColumnName("ID_CONTA_BANCARIA")
                    .ValueGeneratedNever();

                entity.Property(e => e.Agencia)
                    .IsRequired()
                    .HasColumnName("AGENCIA")
                    .HasColumnType("char(6)");

                entity.Property(e => e.Conta)
                    .IsRequired()
                    .HasColumnName("CONTA")
                    .HasColumnType("char(11)");

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdBanco).HasColumnName("ID_BANCO");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.Inicio)
                    .HasColumnName("INICIO")
                    .HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Ordem).HasColumnName("ORDEM");

                entity.Property(e => e.Principal).HasColumnName("PRINCIPAL");

                entity.Property(e => e.Saldo)
                    .HasColumnName("SALDO")
                    .HasColumnType("money");

                entity.Property(e => e.Tipo).HasColumnName("TIPO");

                entity.HasOne(d => d.IdBancoNavigation)
                    .WithMany(p => p.ContaBancaria)
                    .HasForeignKey(d => d.IdBanco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_BANCO_CONTA_BANCARIA");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.ContaBancaria)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CONDOMINIO_CONTA_BANCARIA");
            });

            modelBuilder.Entity<Contato>(entity =>
            {
                entity.HasKey(e => e.IdContato);

                entity.ToTable("CONTATO");

                entity.Property(e => e.IdContato)
                    .HasColumnName("ID_CONTATO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ddd)
                    .IsRequired()
                    .HasColumnName("DDD")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("TELEFONE")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Tipo).HasColumnName("TIPO");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Contato)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PESSOA_CONTATO");
            });

            modelBuilder.Entity<CustoAreaComum>(entity =>
            {
                entity.HasKey(e => e.IdCustoAreaComum);

                entity.ToTable("CUSTO_AREA_COMUM");

                entity.Property(e => e.IdCustoAreaComum)
                    .HasColumnName("ID_CUSTO_AREA_COMUM")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdContaCategoria).HasColumnName("ID_CONTA_CATEGORIA");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.PgtoDia)
                    .HasColumnName("PGTO_DIA")
                    .HasColumnType("date");

                entity.Property(e => e.PgtoTaxaCondominial).HasColumnName("PGTO_TAXA_CONDOMINIAL");

                entity.Property(e => e.Valor)
                    .HasColumnName("VALOR")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco);

                entity.ToTable("ENDERECO");

                entity.Property(e => e.IdEndereco)
                    .HasColumnName("ID_ENDERECO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("BAIRRO")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("CEP")
                    .HasColumnType("char(7)");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("CIDADE")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("ESTADO")
                    .HasColumnType("char(2)");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasColumnName("LOGRADOURO")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasColumnName("NUMERO")
                    .HasColumnType("char(5)");
            });

            modelBuilder.Entity<ExclusividadeAreaComum>(entity =>
            {
                entity.HasKey(e => e.IdExclusividadeAreaComum);

                entity.ToTable("EXCLUSIVIDADE_AREA_COMUM");

                entity.Property(e => e.IdExclusividadeAreaComum)
                    .HasColumnName("ID_EXCLUSIVIDADE_AREA_COMUM")
                    .ValueGeneratedNever();

                entity.Property(e => e.Complemento)
                    .IsRequired()
                    .HasColumnName("COMPLEMENTO")
                    .HasColumnType("char(4)");

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.TipoLote).HasColumnName("TIPO_LOTE");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.IdGrupo);

                entity.ToTable("GRUPO");

                entity.Property(e => e.IdGrupo)
                    .HasColumnName("ID_GRUPO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.NomeGrupo)
                    .IsRequired()
                    .HasColumnName("NOME_GRUPO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.Grupo)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CONDOMINIO_GRUPO");
            });

            modelBuilder.Entity<GrupoPessoa>(entity =>
            {
                entity.HasKey(e => e.IdGrupoPessoa);

                entity.ToTable("GRUPO_PESSOA");

                entity.Property(e => e.IdGrupoPessoa)
                    .HasColumnName("ID_GRUPO_PESSOA")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdGrupo).HasColumnName("ID_GRUPO");

                entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.GrupoPessoa)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_GRUPO_GRUPO_PESSOA");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.GrupoPessoa)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PESSOA_GRUPO_PESSOA");
            });

            modelBuilder.Entity<Infracao>(entity =>
            {
                entity.HasKey(e => e.IdInfracao);

                entity.ToTable("INFRACAO");

                entity.Property(e => e.IdInfracao)
                    .HasColumnName("ID_INFRACAO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EnviarMail).HasColumnName("ENVIAR_MAIL");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.IdSindicoCondominio).HasColumnName("ID_SINDICO_CONDOMINIO");

                entity.Property(e => e.IdUnidade).HasColumnName("ID_UNIDADE");

                entity.Property(e => e.TipoInfracao).HasColumnName("TIPO_INFRACAO");

                entity.Property(e => e.Valor)
                    .HasColumnName("VALOR")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.Infracao)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CONDOMINIO_INFRACAO");

                entity.HasOne(d => d.IdSindicoCondominioNavigation)
                    .WithMany(p => p.Infracao)
                    .HasForeignKey(d => d.IdSindicoCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_SINDICO_CONDOMINIO_INFRACAO");

                entity.HasOne(d => d.IdUnidadeNavigation)
                    .WithMany(p => p.Infracao)
                    .HasForeignKey(d => d.IdUnidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_UNIDADE_INFRACAO");
            });

            modelBuilder.Entity<Leitura>(entity =>
            {
                entity.HasKey(e => e.IdLeitura);

                entity.ToTable("LEITURA");

                entity.Property(e => e.IdLeitura)
                    .HasColumnName("ID_LEITURA")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaLeitura)
                    .HasColumnName("DTA_LEITURA")
                    .HasColumnType("date");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.IdTipoLeitura).HasColumnName("ID_TIPO_LEITURA");

                entity.Property(e => e.IdUnidade).HasColumnName("ID_UNIDADE");

                entity.Property(e => e.Valor)
                    .HasColumnName("VALOR")
                    .HasColumnType("numeric(4, 0)");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.Leitura)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CONDOMINIO_LEITURA");

                entity.HasOne(d => d.IdTipoLeituraNavigation)
                    .WithMany(p => p.Leitura)
                    .HasForeignKey(d => d.IdTipoLeitura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_TIPO_LEITURA_LEITURA");
            });

            modelBuilder.Entity<MarcaVeiculo>(entity =>
            {
                entity.HasKey(e => e.IdMarcaVeiculo);

                entity.ToTable("MARCA_VEICULO");

                entity.Property(e => e.IdMarcaVeiculo)
                    .HasColumnName("ID_MARCA_VEICULO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnName("MARCA")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.IdModulo);

                entity.ToTable("MODULO");

                entity.Property(e => e.IdModulo)
                    .HasColumnName("ID_MODULO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Plano)
                    .IsRequired()
                    .HasColumnName("PLANO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasColumnName("VALOR")
                    .HasColumnType("money");

                entity.Property(e => e.ValorPlano)
                    .HasColumnName("VALOR_PLANO")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<ModuloCondominio>(entity =>
            {
                entity.HasKey(e => e.IdModuloCondominio);

                entity.ToTable("MODULO_CONDOMINIO");

                entity.Property(e => e.IdModuloCondominio)
                    .HasColumnName("ID_MODULO_CONDOMINIO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaRenovacao)
                    .HasColumnName("DTA_RENOVACAO")
                    .HasColumnType("date");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.ValorTotal)
                    .HasColumnName("VALOR_TOTAL")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.ModuloCondominio)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CONDOMINIO_MODULO_CONDOMINIO");
            });

            modelBuilder.Entity<Permissao>(entity =>
            {
                entity.HasKey(e => e.IdPermissao);

                entity.ToTable("PERMISSAO");

                entity.Property(e => e.IdPermissao)
                    .HasColumnName("ID_PERMISSAO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Acesso).HasColumnName("ACESSO");

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Escrita).HasColumnName("ESCRITA");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.IdSubmodulo).HasColumnName("ID_SUBMODULO");

                entity.Property(e => e.Leitura).HasColumnName("LEITURA");

                entity.Property(e => e.Remocao).HasColumnName("REMOCAO");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.Permissao)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CONDOMINIO_PERMISSAO");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Permissao)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PESSOA_PERMISSAO");

                entity.HasOne(d => d.IdSubmoduloNavigation)
                    .WithMany(p => p.Permissao)
                    .HasForeignKey(d => d.IdSubmodulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_SUBMODULO_PERMISSAO");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa);

                entity.ToTable("PESSOA");

                entity.Property(e => e.IdPessoa)
                    .HasColumnName("ID_PESSOA")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasColumnType("char(11)");

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaNascimeno)
                    .HasColumnName("DTA_NASCIMENO")
                    .HasColumnType("date");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnName("MAIL")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasColumnName("RG")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasColumnType("char(8)");

                entity.Property(e => e.Sexo).HasColumnName("SEXO");
            });

            modelBuilder.Entity<PessoaUnidade>(entity =>
            {
                entity.HasKey(e => e.IdPessoaUnidade);

                entity.ToTable("PESSOA_UNIDADE");

                entity.Property(e => e.IdPessoaUnidade)
                    .HasColumnName("ID_PESSOA_UNIDADE")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.IdUnidade).HasColumnName("ID_UNIDADE");

                entity.Property(e => e.Situacao).HasColumnName("SITUACAO");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.PessoaUnidade)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PESSOA_PESSOA_UNIDADE");

                entity.HasOne(d => d.IdUnidadeNavigation)
                    .WithMany(p => p.PessoaUnidade)
                    .HasForeignKey(d => d.IdUnidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_UNIDADE_PESSOA_UNIDADE");
            });

            modelBuilder.Entity<RegraAreaComum>(entity =>
            {
                entity.HasKey(e => e.IdRegraAreaComum);

                entity.ToTable("REGRA_AREA_COMUM");

                entity.Property(e => e.IdRegraAreaComum)
                    .HasColumnName("ID_REGRA_AREA_COMUM")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.QtdePeriodo).HasColumnName("QTDE_PERIODO");

                entity.Property(e => e.QtdeVezes).HasColumnName("QTDE_VEZES");

                entity.Property(e => e.Tempo).HasColumnName("TEMPO");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.RegraAreaComum)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PESSOA_REGRA_AREA_COMUM");
            });

            modelBuilder.Entity<ReservaAreaComum>(entity =>
            {
                entity.HasKey(e => e.IdReservaAreaComum);

                entity.ToTable("RESERVA_AREA_COMUM");

                entity.Property(e => e.IdReservaAreaComum)
                    .HasColumnName("ID_RESERVA_AREA_COMUM")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdAreaComum).HasColumnName("ID_AREA_COMUM");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.Periodo).HasColumnName("PERIODO");

                entity.Property(e => e.Situacao).HasColumnName("SITUACAO");

                entity.HasOne(d => d.IdAreaComumNavigation)
                    .WithMany(p => p.ReservaAreaComum)
                    .HasForeignKey(d => d.IdAreaComum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_AREA_COMUM_RESERVA_AREA_COMUM");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.ReservaAreaComum)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CONDOMINIO_RESERVA_AREA_COMUM");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.ReservaAreaComum)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PESSOA_RESERVA_AREA_COMUM");
            });

            modelBuilder.Entity<Residente>(entity =>
            {
                entity.HasKey(e => e.IdResidente);

                entity.ToTable("RESIDENTE");

                entity.Property(e => e.IdResidente)
                    .HasColumnName("ID_RESIDENTE")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.IdPessoaResidente).HasColumnName("ID_PESSOA_RESIDENTE");

                entity.Property(e => e.IdPessoaUnidade).HasColumnName("ID_PESSOA_UNIDADE");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.Residente)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CONDOMINIO_RESIDENTE");

                entity.HasOne(d => d.IdPessoaResidenteNavigation)
                    .WithMany(p => p.ResidenteIdPessoaResidenteNavigation)
                    .HasForeignKey(d => d.IdPessoaResidente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PESSOA_RESIDENTE_RESIDENTE");

                entity.HasOne(d => d.IdPessoaUnidadeNavigation)
                    .WithMany(p => p.ResidenteIdPessoaUnidadeNavigation)
                    .HasForeignKey(d => d.IdPessoaUnidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PESSOA_UNIDADE_RESIDENTE");
            });

            modelBuilder.Entity<SindicoCondominio>(entity =>
            {
                entity.HasKey(e => e.IdSindicoCondominio);

                entity.ToTable("SINDICO_CONDOMINIO");

                entity.Property(e => e.IdSindicoCondominio)
                    .HasColumnName("ID_SINDICO_CONDOMINIO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaMandato)
                    .HasColumnName("DTA_MANDATO")
                    .HasColumnType("date");

                entity.Property(e => e.DtaTermino)
                    .HasColumnName("DTA_TERMINO")
                    .HasColumnType("date");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.IdPessoa).HasColumnName("ID_PESSOA");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.SindicoCondominio)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CONDOMINIO_SINDICO_CONDOMINIO");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.SindicoCondominio)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PESSOA_SINDICO_CONDOMINIO");
            });

            modelBuilder.Entity<SindicoEndereco>(entity =>
            {
                entity.HasKey(e => e.IdSindicoEndereco);

                entity.ToTable("SINDICO_ENDERECO");

                entity.Property(e => e.IdSindicoEndereco)
                    .HasColumnName("ID_SINDICO_ENDERECO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdEndereco).HasColumnName("ID_ENDERECO");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.IdSindicoCondominio).HasColumnName("ID_SINDICO_CONDOMINIO");

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.SindicoEndereco)
                    .HasForeignKey(d => d.IdEndereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_ENDERECO_SINDICO_ENDERECO");

                entity.HasOne(d => d.IdSindicoCondominioNavigation)
                    .WithMany(p => p.SindicoEndereco)
                    .HasForeignKey(d => d.IdSindicoCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_SINDICO_CONDOMINIO");
            });

            modelBuilder.Entity<Submodulo>(entity =>
            {
                entity.HasKey(e => e.IdSubmodulo);

                entity.ToTable("SUBMODULO");

                entity.Property(e => e.IdSubmodulo)
                    .HasColumnName("ID_SUBMODULO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdModulo).HasColumnName("ID_MODULO");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("TITULO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.Submodulo)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_MODULO_SUBMODULO");
            });

            modelBuilder.Entity<TipoLeitura>(entity =>
            {
                entity.HasKey(e => e.IdTipoLeitura);

                entity.ToTable("TIPO_LEITURA");

                entity.Property(e => e.IdTipoLeitura)
                    .HasColumnName("ID_TIPO_LEITURA")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaFechamento)
                    .HasColumnName("DTA_FECHAMENTO")
                    .HasColumnType("date");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Unidade)
                    .IsRequired()
                    .HasColumnName("UNIDADE")
                    .HasColumnType("char(5)");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.TipoLeitura)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CONDOMINIO_TIPO_LEITURA");
            });

            modelBuilder.Entity<Unidade>(entity =>
            {
                entity.HasKey(e => e.IdUnidade);

                entity.ToTable("UNIDADE");

                entity.Property(e => e.IdUnidade)
                    .HasColumnName("ID_UNIDADE")
                    .ValueGeneratedNever();

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.NumeroAndar).HasColumnName("NUMERO_ANDAR");

                entity.Property(e => e.NumeroTipoLote).HasColumnName("NUMERO_TIPO_LOTE");

                entity.Property(e => e.NumeroUnidade).HasColumnName("NUMERO_UNIDADE");

                entity.Property(e => e.Situacao).HasColumnName("SITUACAO");

                entity.Property(e => e.TipoLote).HasColumnName("TIPO_LOTE");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.Unidade)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CONDOMINIO_UNIDADE");
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.HasKey(e => e.IdVeiculo);

                entity.ToTable("VEICULO");

                entity.Property(e => e.IdVeiculo)
                    .HasColumnName("ID_VEICULO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ano)
                    .IsRequired()
                    .HasColumnName("ANO")
                    .HasColumnType("char(4)");

                entity.Property(e => e.Delet).HasColumnName("DELET");

                entity.Property(e => e.DtaInicio)
                    .HasColumnName("DTA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtaUpdate)
                    .HasColumnName("DTA_UPDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCondominio).HasColumnName("ID_CONDOMINIO");

                entity.Property(e => e.IdMarca).HasColumnName("ID_MARCA");

                entity.Property(e => e.IdResponsavel).HasColumnName("ID_RESPONSAVEL");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasColumnName("MODELO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasColumnName("PLACA")
                    .HasColumnType("char(7)");

                entity.Property(e => e.Vaga)
                    .HasColumnName("VAGA")
                    .HasColumnType("char(4)");

                entity.HasOne(d => d.IdCondominioNavigation)
                    .WithMany(p => p.Veiculo)
                    .HasForeignKey(d => d.IdCondominio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_CONDOMINIO_VEICULO");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Veiculo)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_MARCA");
            });
        }
    }
}
