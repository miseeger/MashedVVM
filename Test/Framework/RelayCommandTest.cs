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

		#region ----- SimpleRcmdCommand ---------------------------------------

		[Test]
		public void SimpleRcmdCommandExecuteTest()
		{
			var testObject = new RelayCommandsToTest();
			testObject.SimpleRcmdCommand.Execute(this);
			Assert.IsTrue(testObject.SimpleRcmdExecuted);
		}

		#endregion


		#region ----- SimpleRcmdCeCommand -------------------------------------

		[Test]
		public void SimpleRcmdCeCommandExecuteTest()
		{
			var testObject = new RelayCommandsToTest();
			testObject.SimpleRcmdCeCommand.Execute(this);
			Assert.IsTrue(testObject.SimpleRcmdCeExecuted);
		}


		[Test]
		public void SimpleRcmdCeCommandCanExecuteTest()
		{
			var testObject = new RelayCommandsToTest();
			testObject.CanExecute = false;
			testObject.SimpleRcmdCeCommand.CanExecute(this);
			Assert.IsTrue(!testObject.SimpleRcmdCeCommand.CanExecute(this) && testObject.SimpleRcmdCeCanExecuteExecuted);
		}


		[Test]
		public void RaiseCanExecuteChangedOnSimpleRcmdCeCommandTest()
		{
			var testObject = new RelayCommandsToTest();
			testObject.SimpleRcmdCeCommand.RaiseCanExecuteChanged();
			Assert.IsTrue(testObject.SimpleRcmdCeCanExecuteChangedExecuted);
		}


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

		#endregion


		#region ----- ParamRcmdCommand ------------------------------------------------

		[Test]
		public void ParamRcmdCommandExecuteTest()
		{
			var testObject = new RelayCommandsToTest();
			testObject.ParamRcmdCommand.Execute("executed");
			Assert.IsTrue(testObject.RcmdWithParamExecuted && testObject.RcmdWithParamParamValue == "executed");
		}

		#endregion


		#region ----- ParamRcmdCeCommand ------------------------------------------------

		[Test]
		public void ParamRcmdCeCommandExecuteTest()
		{
			var testObject = new RelayCommandsToTest();
			testObject.ParamRcmdCeCommand.Execute("executed");
			Assert.IsTrue(testObject.RcmdWithParamCeExecuted && testObject.RcmdWithParamCeParamValue == "executed");
		}


		[Test]
		public void ParamRcmdCeCommandCanExecuteTest()
		{
			var testObject = new RelayCommandsToTest();
			testObject.CanExecute = false;
			testObject.ParamRcmdCeCommand.CanExecute("canexecuted");
			Assert.IsTrue(!testObject.SimpleRcmdCeCommand.CanExecute("canexecuted") 
				&& testObject.SimpleRcmdCeCanExecuteExecuted
				&& testObject.RcmdWithParamCeCanExecuteParamValue == "canexecuted");
		}


		[Test]
		public void RaiseCanExecuteChangedOnParamRcmdCeCommandTest()
		{
			var testObject = new RelayCommandsToTest();
			testObject.ParamRcmdCeCommand.RaiseCanExecuteChanged();
			Assert.IsTrue(testObject.RcmdWithParamCeCanExecuteChangedExecuted);
		}

		#endregion

	}

}
