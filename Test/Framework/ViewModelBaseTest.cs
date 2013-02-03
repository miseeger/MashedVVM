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
using MashedVVM.Test.Framework.TestObjects;
using NUnit.Framework;

namespace MashedVVM.Test.Framework
{

	[TestFixture, RequiresSTA]
	public class ViewModelBaseTest
	{

		[Test]
		public void InitializeTest()
		{
			var testView = new UserControlViewBaseToTest();
			var testViewModel = new ViewModelBaseToTest(testView);
			testViewModel.Initialize();
			Assert.IsTrue
			(
				testViewModel.Initialized
				&& testViewModel.View.ViewModel == testViewModel
				&& testViewModel.View == testView
			);
		}


		[Test]
		public void InDesignTest()
		{
			var testView = new UserControlViewBaseToTest();
			var testViewModel = new ViewModelBaseToTest(testView);
			Assert.IsFalse(testViewModel.InDesign);
		}


		[Test]
		public void ToStringTest()
		{
			var testView = new UserControlViewBaseToTest();
			var testViewModel = new ViewModelBaseToTest(testView);
			Assert.IsTrue(testViewModel.ToString() == "ViewModel ViewModelBaseToTest");
		}


		[Test]
		public void IsBusyTest()
		{
			var testView = new UserControlViewBaseToTest();
			var testViewModel = new ViewModelBaseToTest(testView);
			testViewModel.IsBusy = true;
			Assert.IsTrue
			(
				testViewModel.ChangedPropertyName == "IsBusy"
				&& testViewModel.IsDirty == false
				&& testViewModel.IsBusy
			);
		}
		
		
		[Test]
		public void IsDirtyDirectTest()
		{
			var testView = new UserControlViewBaseToTest();
			var testViewModel = new ViewModelBaseToTest(testView);
			testViewModel.IsDirty = true;
			Assert.IsTrue
			(
				testViewModel.ChangedPropertyName == "IsDirty"
				&& testViewModel.IsDirty == true
			);
		}


		[Test]
		public void IsDirtyAutoTest()
		{
			
			var testView = new UserControlViewBaseToTest();
			var testViewModel = new ViewModelBaseToTest(testView)
				{
					Name = "John"
					,IsDirty = false
				};
			var isDirtyInit = testViewModel.IsDirty;
			testViewModel.Name = "Jack";
			Assert.IsTrue
			(
				isDirtyInit == false
				&& testViewModel.IsDirty
				&& testViewModel.ChangedPropertyName == "Name"
			);
		}

	}

}
