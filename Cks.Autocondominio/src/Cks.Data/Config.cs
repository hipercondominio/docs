namespace Cks.Data
{
	public static class Config
	{
		/// <summary>
		/// Determina o tamanho máximo de um campo para string, quando não especificado.
		/// </summary>
		public static int StringMaxLength = 300;

		/// <summary>
		/// String de conexão padrão com base de dados.
		/// </summary>
		public static string DefaultConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\github\docs\Cks.Autocondominio\src\Cks.Data\Databases\AutoCondominio.mdf;Integrated Security=True;Connect Timeout=30";
	}
}
