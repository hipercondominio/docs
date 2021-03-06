﻿using Cks.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;

namespace Cks.Business
{
	class Usuario
	{
		//Pessoa
		public int IdPessoa { get; set; }
		public string Nome { get; set; }
		public string Cpf { get; set; }
		public string Rg { get; set; }
		public int? Sexo { get; set; }
		public DateTime DtaNascimeno { get; set; }
		public string Mail { get; set; }
		public string Senha { get; set; }
		//Endereco
		public int IdEndereco { get; set; }
		public int IdResponsavel { get; set; }
		public string Cep { get; set; }
		public string Logradouro { get; set; }
		public string Numero { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }
		//Contato
		public int IdContato { get; set; }
		public bool Delet { get; set; }
		public int Tipo { get; set; }
		public string Ddd { get; set; }
		public string Telefone { get; set; }




		public void Create(int idResponsavel)
		{
			var context = new Cks.Data.Contexts.DefaultContext();
			Pessoa dtPessoa = new Cks.Data.Models.Pessoa();
			dtPessoa.IdResponsavel = idResponsavel;
			dtPessoa.DtaInicio = DateTime.Now;
			dtPessoa.DtaUpdate = DateTime.Now;
			dtPessoa.Delet = false;
			dtPessoa.Nome = this.Nome;
			dtPessoa.Cpf = this.Cpf;
			dtPessoa.Rg = this.Rg;
			dtPessoa.Sexo = this.Sexo;
			dtPessoa.DtaNascimeno = this.DtaNascimeno;
			dtPessoa.Mail = this.Mail;
			dtPessoa.Senha = this.Senha;

			Endereco dtEndereco = new Cks.Data.Models.Endereco();
			dtEndereco.IdResponsavel = idResponsavel;
			dtEndereco.DtaInicio = DateTime.Now;
			dtEndereco.DtaUpdate = DateTime.Now;
			dtEndereco.Delet = false;
			dtEndereco.Cep = this.Cep;
			dtEndereco.Logradouro = this.Logradouro;
			dtEndereco.Numero = this.Numero;
			dtEndereco.Bairro = this.Bairro;
			dtEndereco.Cidade = this.Cidade;
			dtEndereco.Estado = this.Estado;
			//ver com o markinho
			//Contato dtContato = new Cks.Data.Models.Contato();

			context.Pessoa.Add(dtPessoa);
			context.Endereco.Add(dtEndereco);
			context.SaveChanges();
		}
		public static void Update(int idPessoa)
		{
			var context = new Cks.Data.Contexts.DefaultContext();
			Pessoa dtPessoa = new Cks.Data.Models.Pessoa();
			dtPessoa.IdPessoa = idPessoa;
			dtPessoa.IdResponsavel = this.IdResponsavel;
			dtPessoa.DtaInicio = DateTime.Now;
			dtPessoa.DtaUpdate = DateTime.Now;
			dtPessoa.Delet = false;
			dtPessoa.Nome = this.Nome;
			dtPessoa.Cpf = this.Cpf;
			dtPessoa.Rg = this.Rg;
			dtPessoa.Sexo = this.Sexo;
			dtPessoa.DtaNascimeno = this.DtaNascimeno;
			dtPessoa.Mail = this.Mail;
			dtPessoa.Senha = this.Senha;

			Endereco dtEndereco = new Cks.Data.Models.Endereco();
			dtEndereco.IdResponsavel = this.IdResponsavel;
			dtEndereco.DtaInicio = DateTime.Now;
			dtEndereco.DtaUpdate = DateTime.Now;
			dtEndereco.Delet = false;
			dtEndereco.Cep = this.Cep;
			dtEndereco.Logradouro = this.Logradouro;
			dtEndereco.Numero = this.Numero;
			dtEndereco.Bairro = this.Bairro;
			dtEndereco.Cidade = this.Cidade;
			dtEndereco.Estado = this.Estado;
			//ver com o markinho
			//Contato dtContato = new Cks.Data.Models.Contato();

			context.Pessoa.Update(dtPessoa);
			context.Endereco.Update(dtEndereco);
			context.SaveChanges();
		}
	
		public Pessoa FindById(int id)
		{
			var context = new Data.Contexts.DefaultContext();
			var dbPessoa = context.Pessoa.FirstOrDefault(x => x.IdPessoa == id);
			var pessoa = Mapper.Map<Pessoa>(dbPessoa);
			return pessoa;

		}

		public IQueryable<Pessoa> Find(Pessoa pessoa)
		{

			var context = new Data.Contexts.DefaultContext();
			var dbPessoa = context.Pessoa.Where(x =>
					(pessoa.Nome == null || x.Nome.Contains(pessoa.Nome))
				);
			var pessoas = Mapper.Map<IEnumerable<Pessoa>>(dbPessoa).AsQueryable();
			return pessoas;
		}

	}
}
