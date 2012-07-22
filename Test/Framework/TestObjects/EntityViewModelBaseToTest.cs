/* ************************************************************************* *
 * MashedVVM.Test                                                            *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 *                                                                           *
 * Licensed under the MS-PL (http://www.opensource.org/licenses/MS-PL)       *
 * ************************************************************************* */

using System;
using MashedVVM.Framework.Contracts;
using MashedVVM.Framework.ViewModel;

namespace MashedVVM.Test.Framework.TestObjects
{

	public class EntityViewModelBaseToTest: EntityViewModelBase
	{

		public string ChangedPropertyName { get; set; }
		public Boolean Initialized { get; set; }


		public EntityViewModelBaseToTest(IView view): base(view)
		{
			PropertyChanged += (s, e) => { ChangedPropertyName = e.PropertyName; };
		}


		public override void Initialize()
		{
			base.Initialize();
			Initialized = true;
		}

	}

}
