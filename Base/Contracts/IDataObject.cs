/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 * Date: 13.05.2012                                                          *
 *                                                                           *
 * This code is provided as is and should be used at your own risk. It comes *
 * without a warrenty of any kind.                                           *
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
