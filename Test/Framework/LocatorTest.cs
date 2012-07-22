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
using MashedVVM.Framework.Exceptions;
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
			var logger = (ILogger)locator["ConsoleLogger"];
			logger.Log("Test!");
			Assert.IsTrue(logger is ILogger);
		}


		[Test]
		public void InitLocatorTest2()
		{
			var locator = Locator.Instance;
			var logger = (ILogger)locator.Resolve("ConsoleLogger");
			logger.Log("Test2!");
			Assert.IsTrue(logger is ILogger);
		}


		[Test]
		public void InitLocatorTest3()
		{
			var locator = Locator.Instance;
			var logger = locator.Resolve<ILogger>("ConsoleLogger");
			logger.Log("Test3!");
			Assert.IsTrue(logger is ILogger);
		}


		[Test]
		public void RegisterManuallyTest1()
		{
			var locator = Locator.Instance;
			try 
			{
				locator.Register("DebugLogger", new DebugLoggerToTest());
			}
			catch (AlreadyRegisteredException) 
			{
			}
			finally
			{
				var logger = (ILogger)locator.Resolve("DebugLogger");
				logger.Log("Test4!");
				Assert.IsTrue(logger is ILogger);
			}
		}


		[Test]
		public void RegisterManuallyTest2()
		{
			var locator = Locator.Instance;
			try 
			{
				locator.Register("DebugLogger", new DebugLoggerToTest());
			}
			catch (AlreadyRegisteredException) 
			{
			}
			finally
			{
				var logger = (ILogger)locator["DebugLogger"];
				logger.Log("Test5!");
				Assert.IsTrue(logger is ILogger);
			}
		}


		[Test]
		public void RegisterManuallyTest3()
		{
			var locator = Locator.Instance;
			try 
			{
				locator.Register("DebugLogger", new DebugLoggerToTest());
			}
			catch (AlreadyRegisteredException) 
			{
			}
			finally
			{
				var logger = locator.Resolve<ILogger>("DebugLogger");
				logger.Log("Test6!");
				Assert.IsTrue(logger is ILogger);
			}
		}
		
		
	}

}
