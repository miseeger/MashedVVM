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

using System.Collections.Generic;
using System.ComponentModel;
using MashedVVM.Base.Enum;

namespace MashedVVM.Base.Contracts
{

	public interface IDataObject : IEditableObject, IDataErrorInfo
	{
		IEnumerable<string> ObjectStatusIgnoringProperties { get; set; }
		DataObjectStatus ObjectStatus  { get; set; }
		string Errorlist { get; }
		bool IsValid();
		void Validate();
	}

}
