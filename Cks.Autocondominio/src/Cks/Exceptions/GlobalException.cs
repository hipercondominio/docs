using System;
using System.Runtime.Serialization;

namespace Cks.Global.Exceptions
{
	/// <summary>
	/// Exceção geral do pacote Global.
	/// </summary>
	public class GlobalException : Exception
	{
		#region Construtores
		public GlobalException() : base(Messages.Generic)
		{
		}

		public GlobalException(string message) : base(message)
		{
		}

		public GlobalException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected GlobalException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
		#endregion
	}
}
