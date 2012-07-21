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
using MashedVVM.Test.Framework.TestObjects;
using NUnit.Framework;

namespace MashedVVM.Test.Framework
{

	[TestFixture]
	public class LocatorTest
	{

		[Test]
		public void InitLocatorTest1()
		{
			var locator = Locator.Instance;
			var logger = (ILogger)locator["Logger"];
			logger.Log("Test!");
			Assert.IsTrue(logger is ILogger);
		}


		[Test]
		public void InitLocatorTest2()
		{
			var locator = Locator.Instance;
			var logger = (ILogger)locator.GetInstance("Logger");
			logger.Log("Test2!");
			Assert.IsTrue(logger is ILogger);
		}

	}

}
