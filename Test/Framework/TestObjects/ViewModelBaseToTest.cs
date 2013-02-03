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

	public class ViewModelBaseToTest : ViewModelBase
	{

		public string ChangedPropertyName { get; set; }
		public Boolean Initialized { get; set; }

		private string _name;
		public string Name
		{
			get { return _name; }
			set
			{ 
				if(_name != value)
				{
					_name = value;
					RaisePropertyChanged(() => Name);
				}
			}	
		}


		public ViewModelBaseToTest(IView view): base(view)
		{
			PropertyChanged += (s, e) => { ChangedPropertyName = e.PropertyName; };
		}


		public override void Initialize()
		{
			Initialized = true;
		}

	}
}
