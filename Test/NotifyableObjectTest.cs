/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 *                                                                           *
 * Licensed under the MS-PL (http://www.opensource.org/licenses/MS-PL)       *
 * ************************************************************************* */
 
using System;
using NUnit.Framework;
using System.Collections.Generic;
using MashedVVM.Test.Base;

namespace MashedVVM.Test
{

	[TestFixture]
	public class NotifyableObjectTest
	{

		public NotifyableObjectToTest no2Test;
		
		[TestFixtureSetUp]
		public void SetUp()
		{
			no2Test = new NotifyableObjectToTest();
		}


		[Test]
		public void NotifyPropertyChangeWithLambdaTest()
		{
			var value = "TestName";
			no2Test.Name = value;
			Assert.IsTrue(no2Test.ChangedPropertyName == "Name");
			Assert.IsTrue(no2Test.Name == value);
		}


		[Test]
		public void NotifyPropertyChangeWithMagicStringTest()
		{
			var value = 99;
			no2Test.Number = value;
			Assert.IsTrue(no2Test.ChangedPropertyName == "Number");
			Assert.IsTrue(no2Test.Number == value);
		}


		[Test]
		public void TriggerAttributeTest()
		{
			no2Test.TriggerProp = "Test";
			Assert.IsTrue(no2Test.TriggerMessage == "triggered");
		}


		[Test]
		public void MultipleTriggerAttributeTest()
		{
			no2Test.TriggerProp2 = "Test2";
			var triggerMessage2 = no2Test.TriggerMessage;
			no2Test.TriggerMessage = "";

			no2Test.TriggerProp3 = "Test";
			var triggerMessage3 = no2Test.TriggerMessage;

			Assert.IsTrue(triggerMessage2 == "multipletriggered" && triggerMessage3 == "multipletriggered");
		}

	}

}
