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

namespace MashedVVM.Framework.Behavior
{

	public interface IExecutionStrategy
	{
		CommandBehaviorBinding Behavior { get; set; }
		void Execute(object parameter);
	}


	public class CommandExecutionStrategy : IExecutionStrategy
	{

		public CommandBehaviorBinding Behavior { get; set; }


		public void Execute(object parameter)
		{
			if (Behavior == null)
				throw new InvalidOperationException("Behavior property cannot be null when executing a strategy");

			if (Behavior.Command != null && Behavior.Command.CanExecute(Behavior.CommandParameter))
				Behavior.Command.Execute(Behavior.CommandParameter);
		}

	}


	public class ActionExecutionStrategy : IExecutionStrategy
	{

		public CommandBehaviorBinding Behavior { get; set; }


		public void Execute(object parameter)
		{
			Behavior.Action(parameter);
		}

	}

}
