 /* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 *                                                                           *
 * This code is taken from the Mono Moolight Project (written by Rolf Bjarne *
 * Kvinge)                                                                   *
 *                                                                           *
 * ************************************************************************* */
using System;
using System.Collections;
using System.ComponentModel;
using MashedVVM.Base.Events;

namespace MashedVVM.Base.Contracts
{

	public interface INotifyDataErrorInfo
	{
		event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
		bool HasErrors { get; }
		IEnumerable GetErrors(string propertyName);
	}
}