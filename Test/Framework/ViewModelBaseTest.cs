﻿/* ************************************************************************* *
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

	[TestFixture]
	public class ViewModelBaseTest
	{

		[Test]
		public void InitializeTest()
		{
			var testView = new UserControlViewBaseToTest();
			var testViewModel = new ViewModelBaseToTest(testView);
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
				&& testViewModel.IsBusy
			);
		}

	}

}