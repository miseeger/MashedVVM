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
using MashedVVM.Test.Base.TestObjects;
using NUnit.Framework;

namespace MashedVVM.Test.Base
{
	[TestFixture]
	public class ValidatableDataObjectTest
	{

		private const string ExpectedFirstNameErrors = "AAA not allowed as firstname.\nThis is not a valid firstname.";
		private const string ExpectedLastNameErrors = "Lastname must be given.";


		[Test]
		public void NotifyErrorsChangedTest()
		{
			var testObject = new ValidatableDataObjectToTest() {ObjectStatus = DataObjectStatus.Added};
			testObject.FirstName = "John";
			testObject.LastName = "";
			
			Assert.IsTrue(
				(testObject.ObjectStatus == DataObjectStatus.Added)
				&& (testObject.FirstName == "John")
				&& (testObject.LastName == "")
				&& (testObject.LastErrorsChangedProperty == "LastName")
			);
		}


		[Test]
		public void HasErrorsLastNameTest()
		{
			var testObject = new ValidatableDataObjectToTest{ObjectStatus = DataObjectStatus.Added};
			testObject.FirstName = "John";
			testObject.LastName = "";
			
			Assert.IsTrue(
				(testObject.ObjectStatus == DataObjectStatus.Added)
				&& (testObject.LastErrorsChangedProperty == "LastName")
				&& testObject.HasErrors
			);
		}


		[Test]
		public void HasErrorsFirstNameTest()
		{
			var testObject = new ValidatableDataObjectToTest{ObjectStatus = DataObjectStatus.Added};
			testObject.LastName = "Doe";
			testObject.FirstName = "AAA";
			
			Assert.IsTrue(
				(testObject.ObjectStatus == DataObjectStatus.Added)
				&& (testObject.LastErrorsChangedProperty == "FirstName")
				&& (testObject.HasErrors)
			);
		}


		[Test]
		public void SetRemoveLastNameErrorTest()
		{
			var testObject = new ValidatableDataObjectToTest{ObjectStatus = DataObjectStatus.Added};
			testObject.FirstName = "AAA";
			testObject.LastName = "Doe";
			testObject.FirstName = "John";
			
			Assert.IsTrue(
				(testObject.ObjectStatus == DataObjectStatus.Added)
				&& (testObject.IsValid)
			);
		}


		[Test]
		public void ErrorListTest()
		{
			var testObject = new ValidatableDataObjectToTest{ObjectStatus = DataObjectStatus.Added};
			testObject.LastName = "";
			testObject.FirstName = "AAA";
			var ErrorList = testObject.Errorlist;
			var ErrorList2 = testObject.ErrorStringlist;
			
			Assert.IsTrue(ErrorList == string.Format("{0}\n{1}", 
				ExpectedFirstNameErrors, ExpectedLastNameErrors));
		}


		[Test]
		public void ErrorStringlistTest()
		{
			var expectedErrorList = new System.Collections.Generic.List<string>()
				{
					ExpectedFirstNameErrors,
					ExpectedLastNameErrors
				};

			var testObject = new ValidatableDataObjectToTest{ObjectStatus = DataObjectStatus.Added};
			testObject.LastName = "";
			testObject.FirstName = "AAA";
			var testErrorList = testObject.ErrorStringlist;

			Assert.IsTrue(
				(expectedErrorList[0] == testErrorList[0])
				&& (expectedErrorList[1] == testErrorList[1])
			);
		}


		[Test]
		public void GetErrorsGenericTest()
		{
			var testObject = new ValidatableDataObjectToTest{ObjectStatus = DataObjectStatus.Added};
			testObject.FirstName = "John";
			testObject.LastName = "";
			var errors = testObject.GetErrors(() => testObject.LastName).Cast<string>().ToList();
			
			Assert.IsTrue(
				(errors[0] == ExpectedLastNameErrors)
				&& (testObject.HasErrors)
			);
		}


		[Test]
		public void IsValidTest()
		{
			var testObject = new ValidatableDataObjectToTest{ObjectStatus = DataObjectStatus.Added};
			testObject.FirstName = "John";
			testObject.LastName = "Doe";
			
			Assert.IsTrue(
				(testObject.ObjectStatus == DataObjectStatus.Added)
				&& testObject.IsValid
			);
		}


		[Test]
		public void GenericNotificationTest()
		{
			var testObject = new ValidatableDataObjectToTest{ObjectStatus = DataObjectStatus.Added};
			testObject.NotifyErrorsChanged(() => testObject.LastName);
			Assert.IsTrue((testObject.LastErrorsChangedProperty == "LastName")
							&& (testObject.ObjectStatus == DataObjectStatus.Added));
		}
		

		// ----- Tests for the IDataErrorInfo implementation

		[Test]
		public void ErrorTest()
		{
			var testObject = new ValidatableDataObjectToTest{ObjectStatus = DataObjectStatus.Added};
			Assert.IsTrue(testObject.Error == string.Empty);
		}


		[Test]
		public void StringIndexerTest()
		{
			var testObject = new ValidatableDataObjectToTest{ObjectStatus = DataObjectStatus.Added};
			testObject.LastName = "";
			testObject.FirstName = "AAA";

			Assert.IsTrue(
				(testObject["FirstName"] == ExpectedFirstNameErrors)
				&& (testObject["LastName"] == ExpectedLastNameErrors)
			);
		}


	}

}

