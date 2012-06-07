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

namespace MashedVVM.Test.Base
{

	public class ValidatableDataObjectToTest : ValidatableDataObject
	{

		public string LastErrorsChangedProperty { get; private set; }


		public ValidatableDataObjectToTest()
		{
			ErrorsChanged += (s, e) => { LastErrorsChangedProperty = e.PropertyName; };
		}


		private string _firstName;
		public string FirstName
		{
			get { return _firstName; }
			set
			{
				if(_firstName != value)
				{
					if (value == "AAA")
					{
						
						AddError(() => FirstName, "AAA not allowed as firstname.");
						AddError(() => FirstName, "This is not a valid firstname.");
					}
					else
						RemoveError(() => FirstName);
					
					_firstName = value;
					RaisePropertyChanged(() => FirstName);
				}
			}
		}


		private string _lastName;
		public string LastName
		{
			get { return _lastName; }
			set
			{ 
				if(_lastName != value)
				{
					if (value.Trim() == "")
						AddError(() => LastName, "Lastname must be given.");
					else
						RemoveError(() => LastName);
					
					_lastName = value;
					RaisePropertyChanged(() => LastName);
				}
			}
		}

	}

}


