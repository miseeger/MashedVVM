/* ************************************************************************* *
 * MashedVVM.Test                                                            *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 *                                                                           *
 * This code is distributed under the MS Public License. For more details    *
 * see http://www.opensource.org/licenses/MS-PL.                             *
 *                                                                           *
 * ************************************************************************* */

using System;
using MashedVVM.Framework;

namespace MashedVVM.Test.Framework.TestObjects
{

	public class MessagePublisher
	{

		public static readonly string TypeMessage = "String message from Publisher.";
		public static readonly string MessageId = "MyMessageId";
		public static readonly string IdTypeMessage = "String message from Publisher with registered Id.";
		public static readonly string IdTypeMessageId = "MyStringObjectMessageId";
		
		
		public void SendByType()
		{
			MessageBroker.Instance.Send<string>(TypeMessage);
		}


		public void SendById()
		{
			MessageBroker.Instance.Send(MessageId);
		}


		public void SendByIdAndType()
		{
			MessageBroker.Instance.Send<string>(IdTypeMessage, IdTypeMessageId);
		}

	}

}
