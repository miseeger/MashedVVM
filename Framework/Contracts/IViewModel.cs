/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 *                                                                           *
 * This code is distributed under the MS Public License. For more details    *
 * see http://www.opensource.org/licenses/MS-PL.                             *
 *                                                                           *
 * ************************************************************************* */

using System.ComponentModel;

namespace MashedVVM.Framework.Contracts
{
	
	public interface IViewModel : INotifyPropertyChanged
	{
		IView View { get; set; }
		bool IsBusy { get; set; }
		bool InDesign { get; }
		void Initialize();
	}
}
