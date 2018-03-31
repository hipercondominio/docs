using System;
using System.Runtime.Serialization;

namespace Cks.Data.Exceptions
{
	/// <summary>
	/// Exceção geral do pacote Global.
	/// </summary>
	public class DataException : Exception
	{
		#region Construtores
		public DataException() : base(Messages.Generic)
		{
		}

		public DataException(string message) : base(message)
		{
		}

		public DataException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected DataException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
		#endregion
	}
}
