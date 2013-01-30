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
using MashedVVM.Base.Enum;
using MashedVVM.Test.Base.TestObjects;
using NUnit.Framework;

namespace MashedVVM.Test.Base
{
	[TestFixture]
	public class DataObjectTestIgnoreState
	{

		public DataObjectToTestIgnoreState do2Test;

		[TestFixtureSetUp]
		public void SetUp()
		{
			// TODO: Fill with setup code.
		}


		[Test]
		public void ConstructorTest()
		{
			var testObject = new DataObjectToTestIgnoreState();
			Assert.IsTrue
			(
				(testObject.IgnoreObjectStatus == true)
				&& (testObject.ObjectStatus == DataObjectStatus.Ignore)
				&& (!testObject.IsDirty)
			);
		}


		[Test]
		public void IsDirtyTest()
		{
			var testObject = new DataObjectToTestIgnoreState();
			testObject.Name = "TestName";
			Assert.IsTrue(
				(testObject.ObjectStatus == DataObjectStatus.Ignore)
				&& (testObject.IsDirty)
				&& (testObject.ChangedPropertyName == "Name")
				&& (testObject.Name == "TestName")
			);
		}

		
		[Test]
		public void MaualNotIsDirtyTest()
		{
			var testObject = new DataObjectToTestIgnoreState();
			testObject.Name = "TestName";
			testObject.IsDirty = false;
			Assert.IsTrue(
				(testObject.ObjectStatus == DataObjectStatus.Ignore)
				&& (!testObject.IsDirty)
				&& (testObject.ChangedPropertyName == "IsDirty")
				&& (testObject.Name == "TestName")
			);
		}
		

		[Test]
		public void MaualIsDirtyTest()
		{
			var testObject = new DataObjectToTestIgnoreState();
			testObject.IsDirty = true;
			Assert.IsTrue(
				(testObject.ObjectStatus == DataObjectStatus.Ignore)
				&& (testObject.IsDirty)
				&& (testObject.ChangedPropertyName == "IsDirty")
				&& (testObject.Name == null)
			);
		}



	}

}
