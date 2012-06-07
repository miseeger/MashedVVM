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
using MashedVVM.Base;
using MashedVVM.Base.Enum;

namespace MashedVVM.Test.Base.TestObjects
{

	public class DataObjectToTest : DataObject
	{

		public string ChangedPropertyName { get; private set; }


		public DataObjectToTest()
		{
			PropertyChanged += (s, e) => { ChangedPropertyName = e.PropertyName; };
		}


		private bool _isBusy;
		public bool IsBusy
		{
			get { return _isBusy; }
			set
			{ 
				if(_isBusy != value)
				{
					_isBusy = value;
					RaisePropertyChanged(() => IsBusy);
				}
			}	
		}


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

	}
}
