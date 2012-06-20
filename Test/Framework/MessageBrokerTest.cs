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
using MashedVVM.Test.Framework.TestObjects;
using NUnit.Framework;

namespace MashedVVM.Test.Framework
{

	[TestFixture]
	public class MessageBrokerTest
	{

		[Test]
		public void SendReceivedByTypeMessageTest()
		{
			var publisher = new MessagePublisher();
			var subscriber1 = new MessageSubscriber();
			var subscriber2 = new MessageSubscriber();
			publisher.SendByType();
			Assert.IsTrue(subscriber1.ReceivedByTypeMessage == MessagePublisher.TypeMessage 
				&& subscriber2.ReceivedByTypeMessage == MessagePublisher.TypeMessage);
		}


		[Test]
		public void SendReceivedByIdTest()
		{
			var publisher = new MessagePublisher();
			var subscriber1 = new MessageSubscriber();
			var subscriber2 = new MessageSubscriber();
			publisher.SendById();
			Assert.IsTrue(subscriber1.ReceivedByIdMessageId == MessagePublisher.MessageId 
				&& subscriber2.ReceivedByIdMessageId == MessagePublisher.MessageId);
		}


		[Test]
		public void SendReceivedByIdAndTypeTest()
		{
			var publisher = new MessagePublisher();
			var subscriber1 = new MessageSubscriber();
			var subscriber2 = new MessageSubscriber();
			publisher.SendByIdAndType();
			Assert.IsTrue(subscriber1.ReceivedByIdAndTypeMessage == MessagePublisher.IdTypeMessage
				&& subscriber1.ReceivedByIdAndTypeMessageId == MessagePublisher.IdTypeMessageId
				&& subscriber2.ReceivedByIdAndTypeMessage == MessagePublisher.IdTypeMessage
				&& subscriber2.ReceivedByIdAndTypeMessageId == MessagePublisher.IdTypeMessageId);
		}

	}

}
