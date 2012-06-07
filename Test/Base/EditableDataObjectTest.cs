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
	public class EditableDataObjectTest
	{


		[Test]
		public void EndEditTest()
		{
			var testObject = new EditableDataObjectToTest();
			var birthdate = DateTime.Now;
			testObject.FirstName = "John";
			testObject.LastName = "Doe";
			testObject.Birthdate = birthdate;
			testObject.ObjectStatus = DataObjectStatus.Original;
			
			testObject.BeginEdit();
			testObject.FirstName = "Jane";
			testObject.EndEdit();
			
			Assert.IsTrue(
				(testObject.ObjectStatus == DataObjectStatus.Modified)
				&& (testObject.FirstName == "Jane")
				&& (testObject.LastName == "Doe")
				&& (testObject.FullName == "Jane Doe")
				&& (testObject.Birthdate == birthdate)
			);
		}


		[Test]
		public void CancelEditTest()
		{
			var testObject = new EditableDataObjectToTest();
			var birthdate = DateTime.Now;
			testObject.FirstName = "John";
			testObject.LastName = "Doe";
			testObject.Birthdate = birthdate;
			testObject.ObjectStatus = DataObjectStatus.Original;
			
			testObject.BeginEdit();
			testObject.FirstName = "Jane";
			testObject.CancelEdit();
			
			Assert.IsTrue(
				(testObject.ObjectStatus == DataObjectStatus.Original)
				&& (testObject.FirstName == "John")
				&& (testObject.LastName == "Doe")
				&& (testObject.FullName == "John Doe")
				&& (testObject.Birthdate == birthdate)
			);
		}

	}

}

