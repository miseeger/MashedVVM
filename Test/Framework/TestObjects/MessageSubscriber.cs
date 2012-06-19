 /*
 * User: ${PROJECT}
 *
 * Created by Michael Seeger (www.codedriven.net)
 */
using System;
using MashedVVM.Framework;

namespace MashedVVM.Test.Framework.TestObjects
{

	public class MessageSubscriber
	{

		public string ReceivedByTypeMessage { get; set; }
		public string ReceivedByIdMessage { get; set; }
		public string ReceivedByIdAndTypeMessage { get; set; }


		public MessageSubscriber()
		{
			MessageBroker.Instance.Register<string>(this, MessageReceivedByType);
			MessageBroker.Instance.Register(this,"MyMessageId", MessageReceivedById);
			MessageBroker.Instance.Register<string>(this,"MyStringObjectMessageId", MessageReceivedByIdAndType);
		}


		private void MessageReceivedByType(string Message)
		{
			ReceivedByTypeMessage = Message;
		}


		private void MessageReceivedById()
		{
			ReceivedByIdMessage = "MyMessageId";
		}


		private void MessageReceivedByIdAndType(string Message)
		{
			ReceivedByIdAndTypeMessage = Message;
		}

	}

}
