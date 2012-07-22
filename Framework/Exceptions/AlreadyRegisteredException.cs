/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 *                                                                           *
 * Licensed under the MS-PL (http://www.opensource.org/licenses/MS-PL)       *
 * ************************************************************************* */

using System;
using System.Runtime.Serialization;

namespace MashedVVM.Framework.Exceptions
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
