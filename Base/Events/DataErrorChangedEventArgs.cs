﻿/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 *                                                                           *
 * This code is distributed under the MS Public License. For more details    *
 * see http://www.opensource.org/licenses/MS-PL.                             *
 *                                                                           *
 * ************************************************************************* */
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