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
			Assert.IsTrue
			(
				(testObject.ObjectStatus == DataObjectStatus.Original)
				&& (!testObject.IsDirty)
			);
		}


		[Test]
		public void ConstructorAddedTest()
		{
			var testObject = new DataObjectToTest() { ObjectStatus = DataObjectStatus.Added };
			Assert.IsTrue
			(
				(testObject.ObjectStatus == DataObjectStatus.Added)
				&& (testObject.IsDirty)
			);
		}


		[Test]
		public void ChangeObjectStatusToDeletedTest()
		{
			var testObject = new DataObjectToTest();
			testObject.ObjectStatus = DataObjectStatus.Deleted;
			Assert.IsTrue(
				(testObject.ObjectStatus == DataObjectStatus.Deleted)
				&& (testObject.IsDirty)
				&& (testObject.ChangedPropertyName == "ObjectStatus")
			);
		}
		
		
		[Test]
		public void ChangeObjectStatusToAddedTest()
		{
			var testObject = new DataObjectToTest();
			testObject.ObjectStatus = DataObjectStatus.Added;
			Assert.IsTrue(
				(testObject.ObjectStatus == DataObjectStatus.Added)
				&& (testObject.IsDirty)
				&& (testObject.ChangedPropertyName == "ObjectStatus")
			);
		}


		[Test]
		public void ModifiedStatusTest()
		{
			var testObject = new DataObjectToTest();
			testObject.Name = "TestName";
			Assert.IsTrue(
				(testObject.ObjectStatus == DataObjectStatus.Modified)
				&& (testObject.IsDirty)
				&& (testObject.ChangedPropertyName == "Name")
				&& (testObject.Name == "TestName")
			);
		}


		[Test]
		public void AddedStatusTest()
		{
			var testObject = new DataObjectToTest() { ObjectStatus = DataObjectStatus.Added };
			testObject.Name = "TestName";
			Assert.IsTrue(
				(testObject.ObjectStatus == DataObjectStatus.Added)
				&& (testObject.IsDirty)
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
				&& (testObject.IsDirty)
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
		public void ObjectStatusOriginalToDeletedTest()
		{
			var testObject = new DataObjectToTest();
			testObject.ObjectStatus = DataObjectStatus.Deleted;
			Assert.IsTrue
				(
					(testObject.ObjectStatus == DataObjectStatus.Deleted)
					&& (testObject.IsDirty)
				);
		}


		[Test]
		public void ObjectStatusOriginalToModifiedTest()
		{
			var testObject = new DataObjectToTest();
			testObject.ObjectStatus = DataObjectStatus.Modified;
			Assert.IsTrue
				(
					(testObject.ObjectStatus == DataObjectStatus.Modified)
					&& (testObject.IsDirty)
				);
		}


		[Test]
		public void ObjectStatusOriginalToAddedTest()
		{
			var testObject = new DataObjectToTest();
			testObject.ObjectStatus = DataObjectStatus.Modified;
			Assert.IsTrue
				(
					(testObject.ObjectStatus == DataObjectStatus.Modified)
					&& (testObject.IsDirty)
				);
		}


		[Test]
		public void ObjectStatusDeletedToOriginalTest()
		{
			var testObject = new DataObjectToTest() {ObjectStatus = DataObjectStatus.Deleted};
			testObject.ObjectStatus = DataObjectStatus.Original;
			Assert.IsTrue
				(
					(testObject.ObjectStatus == DataObjectStatus.Original)
					&& (!testObject.IsDirty)
				);
		}


		[Test]
		public void ObjectStatusDeletedToModifiedTest()
		{
			var testObject = new DataObjectToTest() {ObjectStatus = DataObjectStatus.Deleted};
			testObject.ObjectStatus = DataObjectStatus.Modified;
			Assert.IsTrue
				(
					(testObject.ObjectStatus == DataObjectStatus.Deleted)
					&& (testObject.IsDirty)
				);
		}


		[Test]
		public void ObjectStatusDeletedToAddedTest()
		{
			var testObject = new DataObjectToTest() {ObjectStatus = DataObjectStatus.Deleted};
			testObject.ObjectStatus = DataObjectStatus.Added;
			Assert.IsTrue
				(
					(testObject.ObjectStatus == DataObjectStatus.Deleted)
					&& (testObject.IsDirty)
				);
		}


		[Test]
		public void ObjectStatusAddedToModifiedTest()
		{
			var testObject = new DataObjectToTest() {ObjectStatus = DataObjectStatus.Added};
			testObject.ObjectStatus = DataObjectStatus.Modified;
			Assert.IsTrue
				(
					(testObject.ObjectStatus == DataObjectStatus.Added)
					&& (testObject.IsDirty)
				);
		}


		[Test]
		public void ObjectStatusAddedToDeletedTest()
		{
			var testObject = new DataObjectToTest() {ObjectStatus = DataObjectStatus.Added};
			testObject.ObjectStatus = DataObjectStatus.Deleted;
			Assert.IsTrue
				(
					(testObject.ObjectStatus == DataObjectStatus.Added)
					&& (testObject.IsDirty)
				);
		}


		[Test]
		public void ObjectStatusAddedToOriginalTest()
		{
			var testObject = new DataObjectToTest() {ObjectStatus = DataObjectStatus.Added};
			testObject.ObjectStatus = DataObjectStatus.Original;
			Assert.IsTrue
				(
					(testObject.ObjectStatus == DataObjectStatus.Added)
					&& (testObject.IsDirty)
				);
		}


		[Test]
		public void ObjectStatusModifiedToOriginalTest()
		{
			var testObject = new DataObjectToTest() {ObjectStatus = DataObjectStatus.Modified};
			testObject.ObjectStatus = DataObjectStatus.Original;
			Assert.IsTrue
				(
					(testObject.ObjectStatus == DataObjectStatus.Original)
					&& (!testObject.IsDirty)
				);
		}


		[Test]
		public void ObjectStatusModifiedToDeletedTest()
		{
			var testObject = new DataObjectToTest() {ObjectStatus = DataObjectStatus.Modified};
			testObject.ObjectStatus = DataObjectStatus.Deleted;
			Assert.IsTrue
				(
					(testObject.ObjectStatus == DataObjectStatus.Deleted)
					&& (testObject.IsDirty)
				);
		}


		[Test]
		public void ObjectStatusModifiedToAddedTest()
		{
			var testObject = new DataObjectToTest() {ObjectStatus = DataObjectStatus.Modified};
			testObject.ObjectStatus = DataObjectStatus.Modified;
			Assert.IsTrue
				(
					(testObject.ObjectStatus == DataObjectStatus.Modified)
					&& (testObject.IsDirty)
				);
		}

		[Test]
		public void IsDirtyTest()
		{
			var testObject = new DataObjectToTest();
			testObject.Name = "TestName";
			Assert.IsTrue(
				testObject.IsDirty == true
				&& testObject.ObjectStatus == DataObjectStatus.Modified);
		}


		[Test]
		public void IsDirtyToFalseTest()
		{
			var testObject = new DataObjectToTest();
			testObject.Name = "TestName";
			testObject.IsDirty = false;
			Assert.IsTrue(
				testObject.IsDirty == false
				&& testObject.ObjectStatus == DataObjectStatus.Original);
		}


		[Test]
		public void DataObjectStatusOriginalToIsDirtyTest()
		{
			var testObject = new DataObjectToTest();
			testObject.IsDirty = true;
			Assert.IsTrue
				(
					(testObject.IsDirty)
					&& (testObject.ObjectStatus == DataObjectStatus.Modified)
				);
		}


		[Test]
		public void DataObjectStatusModifiedToIsDirtyTest()
		{
			var testObject = new DataObjectToTest(){ObjectStatus = DataObjectStatus.Modified};
			testObject.IsDirty = true;
			Assert.IsTrue
				(
					(testObject.IsDirty)
					&& (testObject.ObjectStatus == DataObjectStatus.Modified)
				);
		}


		[Test]
		public void DataObjectStatusDeletedToIsDirtyTest()
		{
			var testObject = new DataObjectToTest(){ObjectStatus = DataObjectStatus.Deleted};
			testObject.IsDirty = true;
			Assert.IsTrue
				(
					(testObject.IsDirty)
					&& (testObject.ObjectStatus == DataObjectStatus.Deleted)
				);
		}


		[Test]
		public void DataObjectStatusAddedToIsDirtyTest()
		{
			var testObject = new DataObjectToTest(){ObjectStatus = DataObjectStatus.Added};
			testObject.IsDirty = true;
			Assert.IsTrue
				(
					(testObject.IsDirty)
					&& (testObject.ObjectStatus == DataObjectStatus.Added)
				);
		}


		[Test]
		public void DataObjectStatusOriginalToNotIsDirtyTest()
		{
			var testObject = new DataObjectToTest();
			testObject.IsDirty = false;
			Assert.IsTrue
				(
					(!testObject.IsDirty)
					&& (testObject.ObjectStatus == DataObjectStatus.Original)
				);
		}


		[Test]
		public void DataObjectStatusModifiedToNotIsDirtyTest()
		{
			var testObject = new DataObjectToTest(){ObjectStatus = DataObjectStatus.Modified};
			testObject.IsDirty = false;
			Assert.IsTrue
				(
					(!testObject.IsDirty)
					&& (testObject.ObjectStatus == DataObjectStatus.Original)
				);
		}


		[Test]
		public void DataObjectStatusDeletedToNotIsDirtyTest()
		{
			var testObject = new DataObjectToTest(){ObjectStatus = DataObjectStatus.Deleted};
			testObject.IsDirty = false;
			Assert.IsTrue
				(
					(!testObject.IsDirty)
					&& (testObject.ObjectStatus == DataObjectStatus.Original)
				);
		}


		[Test]
		public void DataObjectStatusAddedToNotIsDirtyTest()
		{
			var testObject = new DataObjectToTest(){ObjectStatus = DataObjectStatus.Added};
			testObject.IsDirty = false;
			Assert.IsTrue
				(
					(testObject.IsDirty)
					&& (testObject.ObjectStatus == DataObjectStatus.Added)
				);
		}


		
		
		
		
		
		



		[Test]
		public void ResetObjectTest()
		{
			var testObject = new DataObjectToTest();
			testObject.Name = "TestName";
			testObject.ResetStatus();
			Assert.IsTrue(
				(testObject.IsDirty ==   false)
				&& (testObject.ObjectStatus == DataObjectStatus.Original)
			);
		}

	}

}
