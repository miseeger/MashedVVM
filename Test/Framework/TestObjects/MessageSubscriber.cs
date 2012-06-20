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

	public class MessageSubscriber
	{

		public string ReceivedByTypeMessage { get; set; }
		public string ReceivedByIdMessageId { get; set; }
		public string ReceivedByIdAndTypeMessage { get; set; }
		public string ReceivedByIdAndTypeMessageId { get; set; }


		public MessageSubscriber()
		{
			MessageBroker.Instance.Register<string>(this, MessageReceivedByType);
			MessageBroker.Instance.Register(this, MessagePublisher.MessageId, MessageReceivedById);
			MessageBroker.Instance.Register<string>(this, MessagePublisher.IdTypeMessageId, MessageReceivedByIdAndType);
		}


		private void MessageReceivedByType(string Message)
		{
			ReceivedByTypeMessage = Message;
		}


		private void MessageReceivedById()
		{
			ReceivedByIdMessageId = MessagePublisher.MessageId;
		}


		private void MessageReceivedByIdAndType(string Message)
		{
			ReceivedByIdAndTypeMessage = Message;
			ReceivedByIdAndTypeMessageId = MessagePublisher.IdTypeMessageId;
		}

	}

}
