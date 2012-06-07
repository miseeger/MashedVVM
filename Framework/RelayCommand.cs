﻿/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 * Date: 15.05.2012                                                          *
 *                                                                           *
 * Taken from the SharpDevelop project (see link above)                      *
 *                                                                           *
 * Licensed under the MS-PL (http://www.opensource.org/licenses/MS-PL)       *
 * ************************************************************************* */

using System;
using System.Diagnostics;
using System.Windows.Input;

namespace MashedVVM.Framework
{

	public class RelayCommand<T> : System.Windows.Input.ICommand
	{

		readonly Predicate<T> _canExecute;
		readonly Action<T> _execute;


		public RelayCommand(Action<T> execute)
			: this(execute, null)
		{
		}


		public RelayCommand(Action<T> execute, Predicate<T> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("execute");
			_execute = execute;
			_canExecute = canExecute;
		}


		public event EventHandler CanExecuteChanged
		{
			add
			{
				if (_canExecute != null)
					CommandManager.RequerySuggested += value;
			}

			remove
			{
				if (_canExecute != null)
					CommandManager.RequerySuggested -= value;
			}
		}


		[DebuggerStepThrough]
		public Boolean CanExecute(Object parameter)
		{
			return _canExecute == null ? true : _canExecute((T)parameter);
		}


		public void Execute(Object parameter)
		{
			_execute((T)parameter);
		}

	}



	public class RelayCommand : System.Windows.Input.ICommand
	{

		readonly Func<Boolean> _canExecute;
		readonly Action _execute;


		public RelayCommand(Action execute)
			: this(execute, null)
		{
		}


		public RelayCommand(Action execute, Func<Boolean> canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException("execute");
			_execute = execute;
			_canExecute = canExecute;
		}


		public event EventHandler CanExecuteChanged
		{
			add
			{
				if (_canExecute != null)
					CommandManager.RequerySuggested += value;
			}

			remove
			{
				if (_canExecute != null)
					CommandManager.RequerySuggested -= value;
			}
		}


		[DebuggerStepThrough]
		public Boolean CanExecute(Object parameter)
		{
			return _canExecute == null ? true : _canExecute();
		}


		public void Execute(Object parameter)
		{
			_execute();
		}
	}

}

