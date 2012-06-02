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

	public class EditableDataObjectToTest : EditableDataObject
	{
		

		private string _firstName;
		public string FirstName
		{
			get { return _firstName; }
			set
			{
				if(_firstName != value)
				{
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
					_lastName = value;
					RaisePropertyChanged(() => LastName);
				}
			}	
		}


		public string FullName
		{
			get
			{
				return string.Format("{0} {1}", _firstName, _lastName);
			}
		}


		private DateTime _birthdate;
		public DateTime Birthdate
		{
			get { return _birthdate; }
			set
			{ 
				if(_birthdate != value)
				{
					_birthdate = value;
					RaisePropertyChanged(() => Birthdate);
				}
			}
		}

	}

}

