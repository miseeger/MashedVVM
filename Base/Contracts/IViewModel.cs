/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 * Date: 15.05.2012                                                          *
 *                                                                           *
 * This code is licensed under the Creative Commons Attribution 3.0 License  *
 * (http://creativecommons.org/licenses/by/3.0/de/).                         *
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
