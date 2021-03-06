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
using MashedVVM.Base;
using MashedVVM.Base.Attributes;

namespace MashedVVM.Test.Base.TestObjects
{

	public class NotifyableObjectToTest : NotifyableObject
	{

		public string ChangedPropertyName { get; set; }
		public string TriggerMessage { get; set; }


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


		private string _triggerProp;
		public string TriggerProp
		{
			get { return _triggerProp; }
			set
			{ 
				if(_triggerProp != value)
				{
					_triggerProp = value;
					RaisePropertyChanged(() => TriggerProp);
				}
			}	
		}


		[TriggerProperty("TriggerProp")]
		public void TriggerMethod()
		{
			TriggerMessage = "triggered";
		}


		private string _triggerProp2;
		public string TriggerProp2
		{
			get { return _triggerProp2; }
			set
			{ 
				if(_triggerProp2 != value)
				{
					_triggerProp2 = value;
					RaisePropertyChanged(() => TriggerProp2);
				}
			}	
		}


		private string _triggerProp3;
		public string TriggerProp3
		{
			get { return _triggerProp3; }
			set
			{ 
				if(_triggerProp3 != value)
				{
					_triggerProp3 = value;
					RaisePropertyChanged(() => TriggerProp3);
				}
			}
		}
		


		[TriggerProperty("TriggerProp2","TriggerProp3")]
		public void MultipleTriggerMethod()
		{
			TriggerMessage = "multipletriggered";
		}

	}
}
