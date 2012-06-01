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

namespace MashedVVM.Test.Base
{

	public class NotifyableObjectToTest : NotifyableObject
	{

		public string ChangedPropertyName { get; set; }


		public NotifyableObjectToTest()
		{
			PropertyChanged += (s, e) => { ChangedPropertyName = e.PropertyName; };
		}


		private int _number;
		public int Number
		{
			get { return _number; }
			set
			{ 
				if(_number != value)
				{
					_number = value;
					RaisePropertyChanged("Number");
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
