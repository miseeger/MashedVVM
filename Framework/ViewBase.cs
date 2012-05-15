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
 
using System.Windows.Controls;
using MashedVVM.Base.Contracts;

namespace MashedVVM.Framework
{
    
	public abstract class ViewBase: UserControl, IView
    {
        
        public virtual IViewModel ViewModel
        {
        	get
            {
                return (IViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }

    }
}