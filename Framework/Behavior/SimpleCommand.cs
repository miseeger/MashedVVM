/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 * Date: 15.05.2012                                                          *
 *                                                                           *
 * Code Taken from Marlon Grech's ACB implementation (http://bit.ly/KOodVr)  *
 *                                                                           *
 * Licensed under the MS-PL (http://www.opensource.org/licenses/MS-PL)       *
 * ************************************************************************* */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MashedVVM.Framework.Behavior
{

	public class SimpleCommand : ICommand

	{
		public Predicate<object> CanExecuteDelegate { get; set; }
		public Action<object> ExecuteDelegate { get; set; }


		public bool CanExecute(object parameter)
		{
			if (CanExecuteDelegate != null)
				return CanExecuteDelegate(parameter);
			return true;
		}


		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}


		public void Execute(object parameter)
		{
			if (ExecuteDelegate != null)
				ExecuteDelegate(parameter);
		}

	}

}
