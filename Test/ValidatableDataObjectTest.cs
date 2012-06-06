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
using MashedVVM.Test.Base;
using NUnit.Framework;

namespace MashedVVM.Test
{
	[TestFixture]
	public class ValidatableDataObjectTest
	{

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
		public void HasErrorsTest()
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
		public void HasErrors2Test()
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
		public void ErrorListTest()
		{
			var testObject = new ValidatableDataObjectToTest{ObjectStatus = DataObjectStatus.Added};
			testObject.LastName = "";
			testObject.FirstName = "AAA";
			var ErrorList = testObject.Errorlist;
			var ErrorList2 = testObject.ErrorStringlist;
			
			Assert.IsTrue(ErrorList == string.Format("{0}\n{1}\n{2}", 
				"AAA not allowed as firstname.", "This is not a valid firstname.", 
				"Lastname must be given."));
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

	}

}

