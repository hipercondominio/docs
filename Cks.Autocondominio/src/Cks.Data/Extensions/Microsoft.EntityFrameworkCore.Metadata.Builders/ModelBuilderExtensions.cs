using Cks.Data;
using Cks.Data.Conventions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using System.Reflection;

namespace Microsoft.EntityFrameworkCore.Metadata.Builders
{
	/// <summary>
	/// Extensão da classe ModelBuilder
	/// </summary>
	public static class ModelBuilderExtensions
	{
		#region Métodos
		/// <summary>
		/// Adiciona configurações do FluentAPI.
		/// </summary>
		/// <typeparam name="TEntidade">Entidade</typeparam>
		/// <param name="modelBuilder">Model builder</param>
		/// <param name="entityConfig">Configuração do entity</param>
		public static void AppendEntityConfig<TEntidade>(this ModelBuilder modelBuilder, EntityConfig<TEntidade> entityConfig)
			where TEntidade : class
		{
			modelBuilder.Entity<TEntidade>(entityConfig.Configure);
		}

		/// <summary>
		/// Adiciona convenções.
		/// </summary>
		/// <param name="modelBuilder">Model builder</param>
		/// <param name="convention">Convenção</param>
		/// <returns>Model builder</returns>
		public static ModelBuilder AddConvension(this ModelBuilder modelBuilder, IModelBuiltConvention convention)
		{
			var modelBuilderInterno = modelBuilder.GetInfrastructure();
			var conventionDispatcher = modelBuilderInterno.Metadata.ConventionDispatcher;
			var conventionSet = conventionDispatcher.GetType().GetField("_conventionSet", BindingFlags.NonPublic | BindingFlags.Instance)
				.GetValue(conventionDispatcher) as ConventionSet;
			conventionSet.ModelBuiltConventions.Add(convention);

			return modelBuilder;
		}

		/// <summary>
		/// Adiciona uma nova convenção com tipo generic
		/// </summary>
		/// <typeparam name="TConvention">Entidade</typeparam>
		/// <param name="modelBuilder">Model builder</param>
		/// <returns>Model Builder</returns>
		public static ModelBuilder AddConvention<TConvention>(this ModelBuilder modelBuilder) where TConvention : IModelBuiltConvention, new()
		{
			return modelBuilder.AddConvension(new TConvention());
		}

		/// <summary>
		/// Convenção para o tipo string VARCHAR(n)
		/// </summary>
		/// <param name="modelBuilder"></param>
		/// <param name="maxLength"></param>
		/// <returns></returns>
		public static ModelBuilder StringMaxLength(this ModelBuilder modelBuilder, int maxLength)
		{
			if (maxLength > 0)
				modelBuilder.AddConvension(new StringMaxLengthConvention(maxLength));

			return modelBuilder;
		}
		#endregion
	}
}