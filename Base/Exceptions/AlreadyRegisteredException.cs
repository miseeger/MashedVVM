 /*
 * User: ${PROJECT}
 *
 * Created by Michael Seeger (www.codedriven.net)
 */
using System;
using System.Runtime.Serialization;

namespace MashedVVM.Base.Exceptions
{

	public class AlreadyRegisteredException : Exception, ISerializable
	{

		public AlreadyRegisteredException()
		{
		}

		
		public AlreadyRegisteredException(string message) : base(message)
		{
		}

		
		public AlreadyRegisteredException(string message, Exception innerException) : base(message, innerException)
		{
		}


		// This constructor is needed for serialization.
		protected AlreadyRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

	}

}
