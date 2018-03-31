using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Cks.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ANEXO",
                columns: table => new
                {
                    ID_ANEXO = table.Column<int>(nullable: false),
                    CONTEUDO = table.Column<string>(unicode: false, maxLength: 2000, nullable: true),
                    DELET = table.Column<bool>(nullable: false),
                    DOCUMENTO = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    EXTENSAO = table.Column<string>(type: "char(3)", nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    NOME = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    PASTA = table.Column<string>(unicode: false, maxLength: 800, nullable: false),
                    TAGS = table.Column<string>(unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ANEXO", x => x.ID_ANEXO);
                });

            migrationBuilder.CreateTable(
                name: "BANCO",
                columns: table => new
                {
                    ID_BANCO = table.Column<int>(nullable: false),
                    COD_BANO = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    NOME = table.Column<string>(unicode: false, maxLength: 300, nullable: false),
                    WEBSITE = table.Column<string>(unicode: false, maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANCO", x => x.ID_BANCO);
                });

            migrationBuilder.CreateTable(
                name: "CONDOMINIO",
                columns: table => new
                {
                    ID_CONDOMINIO = table.Column<int>(nullable: false),
                    APLIDO = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    CNPJ = table.Column<decimal>(type: "numeric(14, 0)", nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    NOME = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONDOMINIO", x => x.ID_CONDOMINIO);
                });

            migrationBuilder.CreateTable(
                name: "CUSTO_AREA_COMUM",
                columns: table => new
                {
                    ID_CUSTO_AREA_COMUM = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_CONTA_CATEGORIA = table.Column<int>(nullable: true),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    PGTO_DIA = table.Column<DateTime>(type: "date", nullable: false),
                    PGTO_TAXA_CONDOMINIAL = table.Column<bool>(nullable: false),
                    VALOR = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTO_AREA_COMUM", x => x.ID_CUSTO_AREA_COMUM);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    ID_ENDERECO = table.Column<int>(nullable: false),
                    BAIRRO = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    CEP = table.Column<string>(type: "char(7)", nullable: false),
                    CIDADE = table.Column<string>(unicode: false, maxLength: 80, nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ESTADO = table.Column<string>(type: "char(2)", nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    LOGRADOURO = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    NUMERO = table.Column<string>(type: "char(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.ID_ENDERECO);
                });

            migrationBuilder.CreateTable(
                name: "EXCLUSIVIDADE_AREA_COMUM",
                columns: table => new
                {
                    ID_EXCLUSIVIDADE_AREA_COMUM = table.Column<int>(nullable: false),
                    COMPLEMENTO = table.Column<string>(type: "char(4)", nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    TIPO_LOTE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXCLUSIVIDADE_AREA_COMUM", x => x.ID_EXCLUSIVIDADE_AREA_COMUM);
                });

            migrationBuilder.CreateTable(
                name: "MARCA_VEICULO",
                columns: table => new
                {
                    ID_MARCA_VEICULO = table.Column<int>(nullable: false),
                    MARCA = table.Column<string>(unicode: false, maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MARCA_VEICULO", x => x.ID_MARCA_VEICULO);
                });

            migrationBuilder.CreateTable(
                name: "MODULO",
                columns: table => new
                {
                    ID_MODULO = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DESCRICAO = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    NOME = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    PLANO = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    VALOR = table.Column<decimal>(type: "money", nullable: false),
                    VALOR_PLANO = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MODULO", x => x.ID_MODULO);
                });

            migrationBuilder.CreateTable(
                name: "PESSOA",
                columns: table => new
                {
                    ID_PESSOA = table.Column<int>(nullable: false),
                    CPF = table.Column<string>(type: "char(11)", nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_NASCIMENO = table.Column<DateTime>(type: "date", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    MAIL = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    NOME = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    RG = table.Column<string>(type: "char(8)", nullable: false),
                    SENHA = table.Column<string>(type: "char(8)", nullable: false),
                    SEXO = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOA", x => x.ID_PESSOA);
                });

            migrationBuilder.CreateTable(
                name: "AGENDA_PERIODO",
                columns: table => new
                {
                    ID_AGENDA_PERIODO = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_TERMINO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_CONDOMINIO = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    QTDE_OCORRENCIA = table.Column<int>(nullable: false),
                    QTDE_REPETICAO = table.Column<int>(nullable: false),
                    TIPO_REPETICAO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENDA_PERIODO", x => x.ID_AGENDA_PERIODO);
                    table.ForeignKey(
                        name: "FK_ID_CONDOMINIO_AGENDA_PERIODO",
                        column: x => x.ID_CONDOMINIO,
                        principalTable: "CONDOMINIO",
                        principalColumn: "ID_CONDOMINIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CONTA_BANCARIA",
                columns: table => new
                {
                    ID_CONTA_BANCARIA = table.Column<int>(nullable: false),
                    AGENCIA = table.Column<string>(type: "char(6)", nullable: false),
                    CONTA = table.Column<string>(type: "char(11)", nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_BANCO = table.Column<int>(nullable: false),
                    ID_CONDOMINIO = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    INICIO = table.Column<DateTime>(type: "date", nullable: false),
                    NOME = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    ORDEM = table.Column<int>(nullable: false),
                    PRINCIPAL = table.Column<bool>(nullable: false),
                    SALDO = table.Column<decimal>(type: "money", nullable: false),
                    TIPO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTA_BANCARIA", x => x.ID_CONTA_BANCARIA);
                    table.ForeignKey(
                        name: "FK_ID_BANCO_CONTA_BANCARIA",
                        column: x => x.ID_BANCO,
                        principalTable: "BANCO",
                        principalColumn: "ID_BANCO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_CONDOMINIO_CONTA_BANCARIA",
                        column: x => x.ID_CONDOMINIO,
                        principalTable: "CONDOMINIO",
                        principalColumn: "ID_CONDOMINIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GRUPO",
                columns: table => new
                {
                    ID_GRUPO = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_CONDOMINIO = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    NOME_GRUPO = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPO", x => x.ID_GRUPO);
                    table.ForeignKey(
                        name: "FK_ID_CONDOMINIO_GRUPO",
                        column: x => x.ID_CONDOMINIO,
                        principalTable: "CONDOMINIO",
                        principalColumn: "ID_CONDOMINIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MODULO_CONDOMINIO",
                columns: table => new
                {
                    ID_MODULO_CONDOMINIO = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_RENOVACAO = table.Column<DateTime>(type: "date", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_CONDOMINIO = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    VALOR_TOTAL = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MODULO_CONDOMINIO", x => x.ID_MODULO_CONDOMINIO);
                    table.ForeignKey(
                        name: "FK_ID_CONDOMINIO_MODULO_CONDOMINIO",
                        column: x => x.ID_CONDOMINIO,
                        principalTable: "CONDOMINIO",
                        principalColumn: "ID_CONDOMINIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TIPO_LEITURA",
                columns: table => new
                {
                    ID_TIPO_LEITURA = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_FECHAMENTO = table.Column<DateTime>(type: "date", nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_CONDOMINIO = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    NOME = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    UNIDADE = table.Column<string>(type: "char(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_LEITURA", x => x.ID_TIPO_LEITURA);
                    table.ForeignKey(
                        name: "FK_ID_CONDOMINIO_TIPO_LEITURA",
                        column: x => x.ID_CONDOMINIO,
                        principalTable: "CONDOMINIO",
                        principalColumn: "ID_CONDOMINIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UNIDADE",
                columns: table => new
                {
                    ID_UNIDADE = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_CONDOMINIO = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    NUMERO_ANDAR = table.Column<int>(nullable: false),
                    NUMERO_TIPO_LOTE = table.Column<int>(nullable: false),
                    NUMERO_UNIDADE = table.Column<int>(nullable: false),
                    SITUACAO = table.Column<int>(nullable: false),
                    TIPO_LOTE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UNIDADE", x => x.ID_UNIDADE);
                    table.ForeignKey(
                        name: "FK_ID_CONDOMINIO_UNIDADE",
                        column: x => x.ID_CONDOMINIO,
                        principalTable: "CONDOMINIO",
                        principalColumn: "ID_CONDOMINIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CONDOMINIO_ENDERECO",
                columns: table => new
                {
                    ID_CONDOMINIO_ENDERECO = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_CONDOMINIO = table.Column<int>(nullable: false),
                    ID_ENDERECO = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONDOMINIO_ENDERECO", x => x.ID_CONDOMINIO_ENDERECO);
                    table.ForeignKey(
                        name: "FK_ID_CONDOMINIO_ENDERECO",
                        column: x => x.ID_CONDOMINIO,
                        principalTable: "CONDOMINIO",
                        principalColumn: "ID_CONDOMINIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_ENDERECO_CONDOMINIO_ENDERECO",
                        column: x => x.ID_ENDERECO,
                        principalTable: "ENDERECO",
                        principalColumn: "ID_ENDERECO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VEICULO",
                columns: table => new
                {
                    ID_VEICULO = table.Column<int>(nullable: false),
                    ANO = table.Column<string>(type: "char(4)", nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_CONDOMINIO = table.Column<int>(nullable: false),
                    ID_MARCA = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    MODELO = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PLACA = table.Column<string>(type: "char(7)", nullable: false),
                    VAGA = table.Column<string>(type: "char(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEICULO", x => x.ID_VEICULO);
                    table.ForeignKey(
                        name: "FK_ID_CONDOMINIO_VEICULO",
                        column: x => x.ID_CONDOMINIO,
                        principalTable: "CONDOMINIO",
                        principalColumn: "ID_CONDOMINIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_MARCA",
                        column: x => x.ID_MARCA,
                        principalTable: "MARCA_VEICULO",
                        principalColumn: "ID_MARCA_VEICULO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SUBMODULO",
                columns: table => new
                {
                    ID_SUBMODULO = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DESCRICAO = table.Column<string>(unicode: false, maxLength: 2000, nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_MODULO = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    TITULO = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBMODULO", x => x.ID_SUBMODULO);
                    table.ForeignKey(
                        name: "FK_ID_MODULO_SUBMODULO",
                        column: x => x.ID_MODULO,
                        principalTable: "MODULO",
                        principalColumn: "ID_MODULO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CONSELHO_CONDOMINIO",
                columns: table => new
                {
                    ID_CONSELHO_CONDOMINIO = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_MANDATO = table.Column<DateTime>(type: "date", nullable: false),
                    DTA_TERMINO = table.Column<DateTime>(type: "date", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_CONDOMINIO = table.Column<int>(nullable: false),
                    ID_PESSOA = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    TIPO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONSELHO_CONDOMINIO", x => x.ID_CONSELHO_CONDOMINIO);
                    table.ForeignKey(
                        name: "FK_ID_CONDOMINIO_CONSELHO_CONDOMINIO",
                        column: x => x.ID_CONDOMINIO,
                        principalTable: "CONDOMINIO",
                        principalColumn: "ID_CONDOMINIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_PESSOA_CONSELHO_CONDOMINIO",
                        column: x => x.ID_PESSOA,
                        principalTable: "PESSOA",
                        principalColumn: "ID_PESSOA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CONTATO",
                columns: table => new
                {
                    ID_CONTATO = table.Column<int>(nullable: false),
                    DDD = table.Column<string>(type: "char(1)", nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_PESSOA = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    TELEFONE = table.Column<string>(type: "char(1)", nullable: false),
                    TIPO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTATO", x => x.ID_CONTATO);
                    table.ForeignKey(
                        name: "FK_ID_PESSOA_CONTATO",
                        column: x => x.ID_PESSOA,
                        principalTable: "PESSOA",
                        principalColumn: "ID_PESSOA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "REGRA_AREA_COMUM",
                columns: table => new
                {
                    ID_REGRA_AREA_COMUM = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_PESSOA = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    QTDE_PERIODO = table.Column<int>(nullable: false),
                    QTDE_VEZES = table.Column<int>(nullable: false),
                    TEMPO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGRA_AREA_COMUM", x => x.ID_REGRA_AREA_COMUM);
                    table.ForeignKey(
                        name: "FK_ID_PESSOA_REGRA_AREA_COMUM",
                        column: x => x.ID_PESSOA,
                        principalTable: "PESSOA",
                        principalColumn: "ID_PESSOA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RESIDENTE",
                columns: table => new
                {
                    ID_RESIDENTE = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_CONDOMINIO = table.Column<int>(nullable: false),
                    ID_PESSOA_RESIDENTE = table.Column<int>(nullable: false),
                    ID_PESSOA_UNIDADE = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESIDENTE", x => x.ID_RESIDENTE);
                    table.ForeignKey(
                        name: "FK_ID_CONDOMINIO_RESIDENTE",
                        column: x => x.ID_CONDOMINIO,
                        principalTable: "CONDOMINIO",
                        principalColumn: "ID_CONDOMINIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_PESSOA_RESIDENTE_RESIDENTE",
                        column: x => x.ID_PESSOA_RESIDENTE,
                        principalTable: "PESSOA",
                        principalColumn: "ID_PESSOA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_PESSOA_UNIDADE_RESIDENTE",
                        column: x => x.ID_PESSOA_UNIDADE,
                        principalTable: "PESSOA",
                        principalColumn: "ID_PESSOA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SINDICO_CONDOMINIO",
                columns: table => new
                {
                    ID_SINDICO_CONDOMINIO = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_MANDATO = table.Column<DateTime>(type: "date", nullable: false),
                    DTA_TERMINO = table.Column<DateTime>(type: "date", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_CONDOMINIO = table.Column<int>(nullable: false),
                    ID_PESSOA = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SINDICO_CONDOMINIO", x => x.ID_SINDICO_CONDOMINIO);
                    table.ForeignKey(
                        name: "FK_ID_CONDOMINIO_SINDICO_CONDOMINIO",
                        column: x => x.ID_CONDOMINIO,
                        principalTable: "CONDOMINIO",
                        principalColumn: "ID_CONDOMINIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_PESSOA_SINDICO_CONDOMINIO",
                        column: x => x.ID_PESSOA,
                        principalTable: "PESSOA",
                        principalColumn: "ID_PESSOA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SINDICO_ENDERECO",
                columns: table => new
                {
                    ID_SINDICO_ENDERECO = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_ENDERECO = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    ID_SINDICO_CONDOMINIO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SINDICO_ENDERECO", x => x.ID_SINDICO_ENDERECO);
                    table.ForeignKey(
                        name: "FK_ID_ENDERECO_SINDICO_ENDERECO",
                        column: x => x.ID_ENDERECO,
                        principalTable: "ENDERECO",
                        principalColumn: "ID_ENDERECO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_SINDICO_CONDOMINIO",
                        column: x => x.ID_SINDICO_CONDOMINIO,
                        principalTable: "PESSOA",
                        principalColumn: "ID_PESSOA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AGENDA",
                columns: table => new
                {
                    ID_AGENDA = table.Column<int>(nullable: false),
                    ATIVIDADE = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    COR = table.Column<string>(type: "char(7)", nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DESCRICAO = table.Column<string>(unicode: false, maxLength: 2000, nullable: false),
                    DTA_COMECO = table.Column<DateTime>(type: "date", nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_TERMINO = table.Column<DateTime>(type: "date", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_AGENDA_PERIODO = table.Column<int>(nullable: false),
                    ID_CONDOMINIO = table.Column<int>(nullable: false),
                    ID_PESSOA = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    OCUPADO = table.Column<bool>(nullable: false),
                    SITUACAO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENDA", x => x.ID_AGENDA);
                    table.ForeignKey(
                        name: "FK_ID_ID_AGENDA_PERIODO_AGENDA",
                        column: x => x.ID_AGENDA_PERIODO,
                        principalTable: "AGENDA_PERIODO",
                        principalColumn: "ID_AGENDA_PERIODO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_CONDOMINIO_AGENDA",
                        column: x => x.ID_CONDOMINIO,
                        principalTable: "CONDOMINIO",
                        principalColumn: "ID_CONDOMINIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_PESSOA_AGENDA",
                        column: x => x.ID_PESSOA,
                        principalTable: "PESSOA",
                        principalColumn: "ID_PESSOA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AGENDA_SEMANA",
                columns: table => new
                {
                    ID_AGENDA_SEMANA = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DOM = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_AGENDA_PERIODO = table.Column<int>(nullable: false),
                    ID_CONDOMINIO = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    QUA = table.Column<bool>(nullable: false),
                    QUI = table.Column<bool>(nullable: false),
                    SEG = table.Column<bool>(nullable: false),
                    SEX = table.Column<bool>(nullable: false),
                    SÁB = table.Column<bool>(nullable: false),
                    TER = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENDA_SEMANA", x => x.ID_AGENDA_SEMANA);
                    table.ForeignKey(
                        name: "FK_ID_AGENDA_PERIODO_AGENDA_SEMANA",
                        column: x => x.ID_AGENDA_PERIODO,
                        principalTable: "AGENDA_PERIODO",
                        principalColumn: "ID_AGENDA_PERIODO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_CONDOMINIO_AGENDA_SEMANA",
                        column: x => x.ID_CONDOMINIO,
                        principalTable: "CONDOMINIO",
                        principalColumn: "ID_CONDOMINIO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GRUPO_PESSOA",
                columns: table => new
                {
                    ID_GRUPO_PESSOA = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_GRUPO = table.Column<int>(nullable: false),
                    ID_PESSOA = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRUPO_PESSOA", x => x.ID_GRUPO_PESSOA);
                    table.ForeignKey(
                        name: "FK_ID_GRUPO_GRUPO_PESSOA",
                        column: x => x.ID_GRUPO,
                        principalTable: "GRUPO",
                        principalColumn: "ID_GRUPO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_PESSOA_GRUPO_PESSOA",
                        column: x => x.ID_PESSOA,
                        principalTable: "PESSOA",
                        principalColumn: "ID_PESSOA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LEITURA",
                columns: table => new
                {
                    ID_LEITURA = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_LEITURA = table.Column<DateTime>(type: "date", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_CONDOMINIO = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    ID_TIPO_LEITURA = table.Column<int>(nullable: false),
                    ID_UNIDADE = table.Column<int>(nullable: false),
                    VALOR = table.Column<decimal>(type: "numeric(4, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEITURA", x => x.ID_LEITURA);
                    table.ForeignKey(
                        name: "FK_ID_CONDOMINIO_LEITURA",
                        column: x => x.ID_CONDOMINIO,
                        principalTable: "CONDOMINIO",
                        principalColumn: "ID_CONDOMINIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_TIPO_LEITURA_LEITURA",
                        column: x => x.ID_TIPO_LEITURA,
                        principalTable: "TIPO_LEITURA",
                        principalColumn: "ID_TIPO_LEITURA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PESSOA_UNIDADE",
                columns: table => new
                {
                    ID_PESSOA_UNIDADE = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_PESSOA = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    ID_UNIDADE = table.Column<int>(nullable: false),
                    SITUACAO = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOA_UNIDADE", x => x.ID_PESSOA_UNIDADE);
                    table.ForeignKey(
                        name: "FK_ID_PESSOA_PESSOA_UNIDADE",
                        column: x => x.ID_PESSOA,
                        principalTable: "PESSOA",
                        principalColumn: "ID_PESSOA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_UNIDADE_PESSOA_UNIDADE",
                        column: x => x.ID_UNIDADE,
                        principalTable: "UNIDADE",
                        principalColumn: "ID_UNIDADE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERMISSAO",
                columns: table => new
                {
                    ID_PERMISSAO = table.Column<int>(nullable: false),
                    ACESSO = table.Column<bool>(nullable: true),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ESCRITA = table.Column<bool>(nullable: true),
                    ID_CONDOMINIO = table.Column<int>(nullable: false),
                    ID_PESSOA = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    ID_SUBMODULO = table.Column<int>(nullable: false),
                    LEITURA = table.Column<bool>(nullable: true),
                    REMOCAO = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSAO", x => x.ID_PERMISSAO);
                    table.ForeignKey(
                        name: "FK_ID_CONDOMINIO_PERMISSAO",
                        column: x => x.ID_CONDOMINIO,
                        principalTable: "CONDOMINIO",
                        principalColumn: "ID_CONDOMINIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_PESSOA_PERMISSAO",
                        column: x => x.ID_PESSOA,
                        principalTable: "PESSOA",
                        principalColumn: "ID_PESSOA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_SUBMODULO_PERMISSAO",
                        column: x => x.ID_SUBMODULO,
                        principalTable: "SUBMODULO",
                        principalColumn: "ID_SUBMODULO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AREA_COMUM",
                columns: table => new
                {
                    ID_AREA_COMUM = table.Column<int>(nullable: false),
                    CAPACIDADE = table.Column<decimal>(type: "numeric(5, 0)", nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DESCRICAO = table.Column<string>(unicode: false, maxLength: 2000, nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_CONDOMINIO = table.Column<int>(nullable: false),
                    ID_CUSTO_AREA_COMUM = table.Column<int>(nullable: false),
                    ID_EXCLUSIVIDADE_AREA_COMUM = table.Column<int>(nullable: false),
                    ID_REGRA_AREA_COMUM = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    NOME = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    REGRAS_USO = table.Column<string>(unicode: false, maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AREA_COMUM", x => x.ID_AREA_COMUM);
                    table.ForeignKey(
                        name: "FK_ID_CONDOMINIO_AREA_COMUM",
                        column: x => x.ID_CONDOMINIO,
                        principalTable: "CONDOMINIO",
                        principalColumn: "ID_CONDOMINIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_CUSTO_AREA_COMUM_AREA_COMUM",
                        column: x => x.ID_CUSTO_AREA_COMUM,
                        principalTable: "CUSTO_AREA_COMUM",
                        principalColumn: "ID_CUSTO_AREA_COMUM",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_EXCLUSIVIDADE_AREA_COMUM_AREA_COMUM",
                        column: x => x.ID_EXCLUSIVIDADE_AREA_COMUM,
                        principalTable: "EXCLUSIVIDADE_AREA_COMUM",
                        principalColumn: "ID_EXCLUSIVIDADE_AREA_COMUM",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_REGRA_AREA_COMUM_AREA_COMUM",
                        column: x => x.ID_REGRA_AREA_COMUM,
                        principalTable: "REGRA_AREA_COMUM",
                        principalColumn: "ID_REGRA_AREA_COMUM",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INFRACAO",
                columns: table => new
                {
                    ID_INFRACAO = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DESCRICAO = table.Column<string>(unicode: false, maxLength: 2000, nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ENVIAR_MAIL = table.Column<bool>(nullable: true),
                    ID_CONDOMINIO = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    ID_SINDICO_CONDOMINIO = table.Column<int>(nullable: false),
                    ID_UNIDADE = table.Column<int>(nullable: false),
                    TIPO_INFRACAO = table.Column<int>(nullable: false),
                    VALOR = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INFRACAO", x => x.ID_INFRACAO);
                    table.ForeignKey(
                        name: "FK_ID_CONDOMINIO_INFRACAO",
                        column: x => x.ID_CONDOMINIO,
                        principalTable: "CONDOMINIO",
                        principalColumn: "ID_CONDOMINIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_SINDICO_CONDOMINIO_INFRACAO",
                        column: x => x.ID_SINDICO_CONDOMINIO,
                        principalTable: "SINDICO_CONDOMINIO",
                        principalColumn: "ID_SINDICO_CONDOMINIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_UNIDADE_INFRACAO",
                        column: x => x.ID_UNIDADE,
                        principalTable: "UNIDADE",
                        principalColumn: "ID_UNIDADE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RESERVA_AREA_COMUM",
                columns: table => new
                {
                    ID_RESERVA_AREA_COMUM = table.Column<int>(nullable: false),
                    DELET = table.Column<bool>(nullable: false),
                    DTA_INICIO = table.Column<DateTime>(type: "datetime", nullable: false),
                    DTA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_AREA_COMUM = table.Column<int>(nullable: false),
                    ID_CONDOMINIO = table.Column<int>(nullable: false),
                    ID_PESSOA = table.Column<int>(nullable: false),
                    ID_RESPONSAVEL = table.Column<int>(nullable: false),
                    PERIODO = table.Column<int>(nullable: false),
                    SITUACAO = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVA_AREA_COMUM", x => x.ID_RESERVA_AREA_COMUM);
                    table.ForeignKey(
                        name: "FK_ID_AREA_COMUM_RESERVA_AREA_COMUM",
                        column: x => x.ID_AREA_COMUM,
                        principalTable: "AREA_COMUM",
                        principalColumn: "ID_AREA_COMUM",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_CONDOMINIO_RESERVA_AREA_COMUM",
                        column: x => x.ID_CONDOMINIO,
                        principalTable: "CONDOMINIO",
                        principalColumn: "ID_CONDOMINIO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ID_PESSOA_RESERVA_AREA_COMUM",
                        column: x => x.ID_PESSOA,
                        principalTable: "PESSOA",
                        principalColumn: "ID_PESSOA",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AGENDA_ID_AGENDA_PERIODO",
                table: "AGENDA",
                column: "ID_AGENDA_PERIODO");

            migrationBuilder.CreateIndex(
                name: "IX_AGENDA_ID_CONDOMINIO",
                table: "AGENDA",
                column: "ID_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_AGENDA_ID_PESSOA",
                table: "AGENDA",
                column: "ID_PESSOA");

            migrationBuilder.CreateIndex(
                name: "IX_AGENDA_PERIODO_ID_CONDOMINIO",
                table: "AGENDA_PERIODO",
                column: "ID_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_AGENDA_SEMANA_ID_AGENDA_PERIODO",
                table: "AGENDA_SEMANA",
                column: "ID_AGENDA_PERIODO");

            migrationBuilder.CreateIndex(
                name: "IX_AGENDA_SEMANA_ID_CONDOMINIO",
                table: "AGENDA_SEMANA",
                column: "ID_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_AREA_COMUM_ID_CONDOMINIO",
                table: "AREA_COMUM",
                column: "ID_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_AREA_COMUM_ID_CUSTO_AREA_COMUM",
                table: "AREA_COMUM",
                column: "ID_CUSTO_AREA_COMUM");

            migrationBuilder.CreateIndex(
                name: "IX_AREA_COMUM_ID_EXCLUSIVIDADE_AREA_COMUM",
                table: "AREA_COMUM",
                column: "ID_EXCLUSIVIDADE_AREA_COMUM");

            migrationBuilder.CreateIndex(
                name: "IX_AREA_COMUM_ID_REGRA_AREA_COMUM",
                table: "AREA_COMUM",
                column: "ID_REGRA_AREA_COMUM");

            migrationBuilder.CreateIndex(
                name: "IX_CONDOMINIO_ENDERECO_ID_CONDOMINIO",
                table: "CONDOMINIO_ENDERECO",
                column: "ID_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_CONDOMINIO_ENDERECO_ID_ENDERECO",
                table: "CONDOMINIO_ENDERECO",
                column: "ID_ENDERECO");

            migrationBuilder.CreateIndex(
                name: "IX_CONSELHO_CONDOMINIO_ID_CONDOMINIO",
                table: "CONSELHO_CONDOMINIO",
                column: "ID_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_CONSELHO_CONDOMINIO_ID_PESSOA",
                table: "CONSELHO_CONDOMINIO",
                column: "ID_PESSOA");

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_BANCARIA_ID_BANCO",
                table: "CONTA_BANCARIA",
                column: "ID_BANCO");

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_BANCARIA_ID_CONDOMINIO",
                table: "CONTA_BANCARIA",
                column: "ID_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_CONTATO_ID_PESSOA",
                table: "CONTATO",
                column: "ID_PESSOA");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPO_ID_CONDOMINIO",
                table: "GRUPO",
                column: "ID_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPO_PESSOA_ID_GRUPO",
                table: "GRUPO_PESSOA",
                column: "ID_GRUPO");

            migrationBuilder.CreateIndex(
                name: "IX_GRUPO_PESSOA_ID_PESSOA",
                table: "GRUPO_PESSOA",
                column: "ID_PESSOA");

            migrationBuilder.CreateIndex(
                name: "IX_INFRACAO_ID_CONDOMINIO",
                table: "INFRACAO",
                column: "ID_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_INFRACAO_ID_SINDICO_CONDOMINIO",
                table: "INFRACAO",
                column: "ID_SINDICO_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_INFRACAO_ID_UNIDADE",
                table: "INFRACAO",
                column: "ID_UNIDADE");

            migrationBuilder.CreateIndex(
                name: "IX_LEITURA_ID_CONDOMINIO",
                table: "LEITURA",
                column: "ID_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_LEITURA_ID_TIPO_LEITURA",
                table: "LEITURA",
                column: "ID_TIPO_LEITURA");

            migrationBuilder.CreateIndex(
                name: "IX_MODULO_CONDOMINIO_ID_CONDOMINIO",
                table: "MODULO_CONDOMINIO",
                column: "ID_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_PERMISSAO_ID_CONDOMINIO",
                table: "PERMISSAO",
                column: "ID_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_PERMISSAO_ID_PESSOA",
                table: "PERMISSAO",
                column: "ID_PESSOA");

            migrationBuilder.CreateIndex(
                name: "IX_PERMISSAO_ID_SUBMODULO",
                table: "PERMISSAO",
                column: "ID_SUBMODULO");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_UNIDADE_ID_PESSOA",
                table: "PESSOA_UNIDADE",
                column: "ID_PESSOA");

            migrationBuilder.CreateIndex(
                name: "IX_PESSOA_UNIDADE_ID_UNIDADE",
                table: "PESSOA_UNIDADE",
                column: "ID_UNIDADE");

            migrationBuilder.CreateIndex(
                name: "IX_REGRA_AREA_COMUM_ID_PESSOA",
                table: "REGRA_AREA_COMUM",
                column: "ID_PESSOA");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVA_AREA_COMUM_ID_AREA_COMUM",
                table: "RESERVA_AREA_COMUM",
                column: "ID_AREA_COMUM");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVA_AREA_COMUM_ID_CONDOMINIO",
                table: "RESERVA_AREA_COMUM",
                column: "ID_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVA_AREA_COMUM_ID_PESSOA",
                table: "RESERVA_AREA_COMUM",
                column: "ID_PESSOA");

            migrationBuilder.CreateIndex(
                name: "IX_RESIDENTE_ID_CONDOMINIO",
                table: "RESIDENTE",
                column: "ID_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_RESIDENTE_ID_PESSOA_RESIDENTE",
                table: "RESIDENTE",
                column: "ID_PESSOA_RESIDENTE");

            migrationBuilder.CreateIndex(
                name: "IX_RESIDENTE_ID_PESSOA_UNIDADE",
                table: "RESIDENTE",
                column: "ID_PESSOA_UNIDADE");

            migrationBuilder.CreateIndex(
                name: "IX_SINDICO_CONDOMINIO_ID_CONDOMINIO",
                table: "SINDICO_CONDOMINIO",
                column: "ID_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_SINDICO_CONDOMINIO_ID_PESSOA",
                table: "SINDICO_CONDOMINIO",
                column: "ID_PESSOA");

            migrationBuilder.CreateIndex(
                name: "IX_SINDICO_ENDERECO_ID_ENDERECO",
                table: "SINDICO_ENDERECO",
                column: "ID_ENDERECO");

            migrationBuilder.CreateIndex(
                name: "IX_SINDICO_ENDERECO_ID_SINDICO_CONDOMINIO",
                table: "SINDICO_ENDERECO",
                column: "ID_SINDICO_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_SUBMODULO_ID_MODULO",
                table: "SUBMODULO",
                column: "ID_MODULO");

            migrationBuilder.CreateIndex(
                name: "IX_TIPO_LEITURA_ID_CONDOMINIO",
                table: "TIPO_LEITURA",
                column: "ID_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_UNIDADE_ID_CONDOMINIO",
                table: "UNIDADE",
                column: "ID_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_VEICULO_ID_CONDOMINIO",
                table: "VEICULO",
                column: "ID_CONDOMINIO");

            migrationBuilder.CreateIndex(
                name: "IX_VEICULO_ID_MARCA",
                table: "VEICULO",
                column: "ID_MARCA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AGENDA");

            migrationBuilder.DropTable(
                name: "AGENDA_SEMANA");

            migrationBuilder.DropTable(
                name: "ANEXO");

            migrationBuilder.DropTable(
                name: "CONDOMINIO_ENDERECO");

            migrationBuilder.DropTable(
                name: "CONSELHO_CONDOMINIO");

            migrationBuilder.DropTable(
                name: "CONTA_BANCARIA");

            migrationBuilder.DropTable(
                name: "CONTATO");

            migrationBuilder.DropTable(
                name: "GRUPO_PESSOA");

            migrationBuilder.DropTable(
                name: "INFRACAO");

            migrationBuilder.DropTable(
                name: "LEITURA");

            migrationBuilder.DropTable(
                name: "MODULO_CONDOMINIO");

            migrationBuilder.DropTable(
                name: "PERMISSAO");

            migrationBuilder.DropTable(
                name: "PESSOA_UNIDADE");

            migrationBuilder.DropTable(
                name: "RESERVA_AREA_COMUM");

            migrationBuilder.DropTable(
                name: "RESIDENTE");

            migrationBuilder.DropTable(
                name: "SINDICO_ENDERECO");

            migrationBuilder.DropTable(
                name: "VEICULO");

            migrationBuilder.DropTable(
                name: "AGENDA_PERIODO");

            migrationBuilder.DropTable(
                name: "BANCO");

            migrationBuilder.DropTable(
                name: "GRUPO");

            migrationBuilder.DropTable(
                name: "SINDICO_CONDOMINIO");

            migrationBuilder.DropTable(
                name: "TIPO_LEITURA");

            migrationBuilder.DropTable(
                name: "SUBMODULO");

            migrationBuilder.DropTable(
                name: "UNIDADE");

            migrationBuilder.DropTable(
                name: "AREA_COMUM");

            migrationBuilder.DropTable(
                name: "ENDERECO");

            migrationBuilder.DropTable(
                name: "MARCA_VEICULO");

            migrationBuilder.DropTable(
                name: "MODULO");

            migrationBuilder.DropTable(
                name: "CONDOMINIO");

            migrationBuilder.DropTable(
                name: "CUSTO_AREA_COMUM");

            migrationBuilder.DropTable(
                name: "EXCLUSIVIDADE_AREA_COMUM");

            migrationBuilder.DropTable(
                name: "REGRA_AREA_COMUM");

            migrationBuilder.DropTable(
                name: "PESSOA");
        }
    }
}
