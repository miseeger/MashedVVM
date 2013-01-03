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
	public class DataObjectTest
	{

		public DataObjectToTest do2Test;

		[TestFixtureSetUp]
		public void SetUp()
		{
			do2Test = new DataObjectToTest();
		}


		[Test]
		public void ConstructorOriginalTest()
		{
			var testObject = new DataObjectToTest();
			Assert.IsTrue(testObject.ObjectStatus == DataObjectStatus.Original);
		}


		[Test]
		public void ConstructorAddedTest()
		{
			var testObject = new DataObjectToTest() { ObjectStatus = DataObjectStatus.Added };
			Assert.IsTrue(testObject.ObjectStatus == DataObjectStatus.Added);
		}


		[Test]
		public void ChangeOnlyObjectStatusTest()
		{
			var testObject = new DataObjectToTest();
			testObject.ObjectStatus = DataObjectStatus.Deleted;
			Assert.IsTrue(
				(testObject.ObjectStatus == DataObjectStatus.Deleted)
				&& (testObject.ChangedPropertyName == "ObjectStatus")
			);
		}


		[Test]
		public void ChangeObjectStatusIgnoringPropertiesTest()
		{
			var testObject = new DataObjectToTest();
			testObject.IsBusy = true;
			Assert.IsTrue(
				(testObject.ObjectStatus == DataObjectStatus.Original)
				&& (testObject.ChangedPropertyName == "IsBusy")
				&& (testObject.IsBusy == true)
			);
		}


		[Test]
		public void AddedStatusTest()
		{
			var testObject = new DataObjectToTest() { ObjectStatus = DataObjectStatus.Added };
			testObject.Name = "TestName";
			Assert.IsTrue(
				(testObject.ObjectStatus == DataObjectStatus.Added)
				&& (testObject.ChangedPropertyName == "Name")
				&& (testObject.Name == "TestName")
			);
		}


		[Test]
		public void DeletedStatusTest()
		{
			var testObject = new DataObjectToTest() { ObjectStatus = DataObjectStatus.Deleted };
			testObject.Name = "TestName";
			Assert.IsTrue(
				(testObject.ObjectStatus == DataObjectStatus.Deleted)
				&& (testObject.ChangedPropertyName == "Name")
				&& (testObject.Name == "TestName")
			);
		}


		[Test]
		public void ChangeNormalPropertyTest()
		{
			var testObject = new DataObjectToTest();
			testObject.Name = "TestName";
			Assert.IsTrue(
				(testObject.ObjectStatus == DataObjectStatus.Modified)
				&& (testObject.ChangedPropertyName == "Name")
				&& (testObject.Name == "TestName")
			);
		}


		[Test]
		public void IsDirtyTest()
		{
			var testObject = new DataObjectToTest();
			testObject.Name = "TestName";
			Assert.IsTrue(testObject.IsDirty == true);
		}

	}

}
