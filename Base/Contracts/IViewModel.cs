﻿/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 * Date: 15.05.2012                                                          *
 *                                                                           *
 * This code is provided as is and should be used at your own risk. It comes *
 * without a warrenty of any kind.                                           *
 * ************************************************************************* */

using System.ComponentModel;

namespace MashedVVM.Base.Contracts
{
	
	public interface IViewModel : INotifyPropertyChanged
	{
		IView View { get; set; }
		bool IsBusy { get; set; }
		bool InDesign { get; }
		void Initialize();
	}
}