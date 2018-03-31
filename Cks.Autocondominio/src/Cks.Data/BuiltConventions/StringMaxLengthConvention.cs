using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace Cks.Data.Conventions
{
	/// <summary>
	/// Convenções padrões para o tipo String
	/// </summary>
	internal sealed class StringMaxLengthConvention : IModelBuiltConvention
	{
		/// <summary>
		/// Annotations
		/// </summary>
		internal const string AnnotationName = "MaxLength";
		
		private int MaxLength { get; set; }

		/// <summary>
		/// Construtor da classe
		/// </summary>
		/// <param name="maxLength">Tamanho da string</param>
		public StringMaxLengthConvention(int maxLength)
		{
			this.MaxLength = maxLength;
		}

		/// <summary>
		/// Override do método Apply
		/// </summary>
		/// <param name="modelBuilder">tipo model builder</param>
		/// <returns>Model builder</returns>
		public InternalModelBuilder Apply(InternalModelBuilder modelBuilder)
		{
			foreach (var entity in modelBuilder.Metadata.GetEntityTypes())
			{
				foreach (var prop in entity.GetProperties())
				{
					if (prop.ClrType == typeof(string))
					{
						if (prop.FindAnnotation(AnnotationName) == null)
							prop.AddAnnotation(AnnotationName, this.MaxLength);

						prop.Builder.IsUnicode(false, ConfigurationSource.Explicit);
					}
				}
			}
			return modelBuilder;
		}

	}
}