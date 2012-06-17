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
using System.Linq;
using MashedVVM.Base.Enum;
using MashedVVM.Test.Framework.TestObjects;
using NUnit.Framework;

namespace MashedVVM.Test.Framework
{

	[TestFixture]
	public class RelayCommandTest
	{

		[Test]
		public void ReevaluateOnLastnameChangeTest()
		{
			var testObject = new RelayCommandsToTest();
			// at least the relay command must be get once in order to call
			// its ctor so that CanExecuteChanged will be subscribed to.
			var rcmd = testObject.SimpleRcmdCeCommand;
			testObject.Lastname = "Doe";
			Assert.IsTrue(testObject.SimpleRcmdCeCanExecuteChangedExecuted);
		}


		[Test]
		public void ReevaluateOnFirstnameChangeTest()
		{
			var testObject = new RelayCommandsToTest();
			// at least the relay command must be get once in order to call
			// its ctor so that CanExecuteChanged will be subscribed to.
			var rcmd = testObject.SimpleRcmdCeCommand;
			testObject.Firstname = "John";
			Assert.IsTrue(testObject.SimpleRcmdCeCanExecuteChangedExecuted);
		}


		[Test]
		public void RaiseCanExecuteChangedOnRelayCommandTest()
		{
			var testObject = new RelayCommandsToTest();
			testObject.SimpleRcmdCeCommand.RaiseCanExecuteChanged();
			Assert.IsTrue(testObject.SimpleRcmdCeCanExecuteChangedExecuted);
		}


		[Test]
		public void SimpleRcmdExecuteTest()
		{
			var testObject = new RelayCommandsToTest();
			testObject.SimpleRcmdCommand.Execute(this);
			Assert.IsTrue(testObject.SimpleRcmdExecuted);
		}

	}

}
