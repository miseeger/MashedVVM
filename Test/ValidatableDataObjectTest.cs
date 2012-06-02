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
				&& (testObject.ErrorsChangedProperty == "LastName")
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
				&& (testObject.ErrorsChangedProperty == "LastName")
				&& testObject.HasErrors
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

	}

}

