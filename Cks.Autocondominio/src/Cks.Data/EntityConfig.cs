using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Cks.Data
{
	/// <summary>
	/// Configuração de entidade para Contexto de banco.
	/// </summary>
	/// <typeparam name="TEntidade"></typeparam>
	public abstract class EntityConfig<TEntidade>
		where TEntidade : class
	{
		/// <summary>
		/// Expor para consulta à parte do contexto a entidade que está sendo configurada.
		/// </summary>
		public EntityTypeBuilder<TEntidade> Entidade { get; protected set; }

		/// <summary>
		/// Aplicar configurações da entidade com Fluent API.
		/// </summary>
		/// <param name="entidade"></param>
		public virtual void Configure(EntityTypeBuilder<TEntidade> entidade)
		{
			this.Entidade = entidade;
		}

		/// <summary>
		/// Inicia a autoconfiguração da entidade, através de um modelo desvinculado da base de dados.
		/// </summary>
		public void Configure()
		{
			var modelBuilder = new ModelBuilder(new ConventionSet());
			modelBuilder.Entity<TEntidade>(this.Configure);
		}
	}
}