 /*
 * User: ${PROJECT}
 *
 * Created by Michael Seeger (www.codedriven.net)
 */

using System;
using MashedVVM.Framework;

namespace MashedVVM.Test.Framework.TestObjects
{

	public class MessagePublisher
	{

		public void SendByType()
		{
			MessageBroker.Instance.Send<string>("String message from Publisher.");
		}


		public void SendById()
		{
			MessageBroker.Instance.Send("MyMessageId");
		}


		public void SendByIdAndType()
		{
			MessageBroker.Instance.Send<string>("String message from Publisher with registered Id.", "MyStringObjectMessageId");
		}

	}

}
