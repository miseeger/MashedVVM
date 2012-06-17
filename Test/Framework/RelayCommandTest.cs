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
			// at least the relay command must be once referenced to call its 
			// ctor so that CanExecuteChanged will be subscribed to.
			var rcmd = testObject.SimpleRcmdCeCommand;
			testObject.Lastname = "John";
			Assert.IsTrue(testObject.SimpleRcmdCeCanExecuteChangedExecuted);
		}

	}
}
