using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cks.Data
{
	/// <summary>
	/// Contexto base
	/// </summary>
	public abstract class BaseContext : DbContext
	{
		#region Construtores
		public BaseContext()
		{
		}

		public BaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
		{
		}
		#endregion

		#region Eventos
		/// <summary>
		/// Ocorre durante a configuração da base de dados.
		/// </summary>
		/// <param name="optionsBuilder"></param>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			//// ignorar erro de ambiente da versão anterior
			//// optionsBuilder.ConfigureWarnings(x => x.Ignore(Microsoft.EntityFrameworkCore.Infrastructure.RelationalEventId.AmbientTransactionWarning));
		}

		/// <summary>
		/// Override do Método OnModelCreating do DbContext
		/// </summary>
		/// <param name="optionsBuilder">ModelBuilder</param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.StringMaxLength(Config.StringMaxLength);
		}
		#endregion
	}
}