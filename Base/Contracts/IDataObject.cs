/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 * Date: 13.05.2012                                                          *
 *                                                                           *
 * This code is licensed under the Creative Commons Attribution 3.0 License  *
 * (http://creativecommons.org/licenses/by/3.0/de/).                         *
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
