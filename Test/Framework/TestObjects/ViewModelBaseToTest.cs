/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 *                                                                           *
 * Licensed under the MS-PL (http://www.opensource.org/licenses/MS-PL)       *
 * ************************************************************************* */

using System;
using MashedVVM.Framework;

namespace MashedVVM.Test.Framework.TestObjects
{
	/// <summary>
	/// Description of ViewModelBaseToTest.
	/// </summary>
	public class ViewModelBaseToTest : ViewModelBase
	{

		public string ChangedPropertyName { get; set; }


		public ViewModelBaseToTest()
		{
			PropertyChanged += (s, e) => { ChangedPropertyName = e.PropertyName; };
		}


	}
}
