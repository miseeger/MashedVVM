using System;
using System.ComponentModel;

namespace MashedVVM.Base.Events
{

	public sealed class DataErrorsChangedEventArgs : EventArgs 
	{

		public string PropertyName { get; private set; }
		
		public DataErrorsChangedEventArgs (string propertyName)
		{
			this.PropertyName = propertyName;
		}

	}

}
