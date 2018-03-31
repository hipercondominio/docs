namespace System
{
	/// <summary>
	/// Extensões para strings.
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Converter uma sequencia de string para formato camelCase (primeira minúscula).
		/// </summary>
		/// <param name="obj">String referenciada.</param>
		public static string ToCamelCase(this string obj)
		{
			return String.Concat(obj.Substring(0, 1).ToLower(), obj.Substring(1));
		}
	}
}