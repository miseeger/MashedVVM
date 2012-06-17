/* ************************************************************************* *
 * MashedVVM.Test                                                            *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By Michael Seeger (www.codedriven.net)                                    *
 *                                                                           *
 * This code is distributed under the MS Public License. For more details    *
 * see http://www.opensource.org/licenses/MS-PL.                             *
 *                                                                           *
 * ************************************************************************* */

using System;
using System.Windows.Input;
using MashedVVM.Base;
using MashedVVM.Base.Attributes;
using MashedVVM.Framework;

namespace MashedVVM.Test.Framework.TestObjects
{

	public class RelayCommandsToTest : NotifyableObject
	{

		public bool SimpleRcmdExecuted { get; set; }

		public bool SimpleRcmdCeExecuted { get; set; }
		public bool SimpleRcmdCeCanExecuteExecuted { get; set; }
		public bool SimpleRcmdCeCanExecuteChangedExecuted {get; set; }
		
		public bool RcmdWithParamExecuted { get; set; }
		public string RcmdWithParamParamValue { get; set; }

		public bool RcmdWithParamCeExecuted { get; set; }
		public string RcmdWithParamCeParamValue { get; set; }
		
		public bool CanExecute { get; set; }


		private string _lastname;
		public string Lastname
		{
			get { return _lastname; }
			set
			{ 
				if(_lastname != value)
				{
					_lastname = value;
					RaisePropertyChanged(() => Lastname);
				}
			}	
		}


		private RelayCommand _simpleRcmdCommand;
		public ICommand SimpleRcmdCommand
		{
			get { return _simpleRcmdCommand ?? (_simpleRcmdCommand = new RelayCommand(SimpleRcmd)); }
		}

		private void SimpleRcmd()
		{
			SimpleRcmdExecuted = true;
		}


		[ReevaluateProperty("Lastname")]
		private RelayCommand _simpleRcmdCeCommand;
		public ICommand SimpleRcmdCeCommand
		{
			get
			{
				if (_simpleRcmdCeCommand == null) 
				{
					_simpleRcmdCeCommand = new RelayCommand(SimpleRcmdCe, CanExecuteSimpleRcmdCe);
					_simpleRcmdCeCommand.CanExecuteChanged += (s, e) => { SimpleRcmdCeCanExecuteChangedExecuted = true; };
				}
				return _simpleRcmdCeCommand;
				
				// usual way:
				// return _simpleRcmdCeCommand ?? (_simpleRcmdCeCommand = new RelayCommand(SimpleRcmdCe, CanExecuteSimpleRcmdCe));
			}
		}

		private void SimpleRcmdCe()
		{
			SimpleRcmdCeExecuted = true;
		}

		private bool CanExecuteSimpleRcmdCe()
		{
			SimpleRcmdCeCanExecuteExecuted = true;
			return (CanExecute);
		}


		private RelayCommand<string> _paramRcmdCommand;
		public ICommand ParamRcmdCommand
		{
			get { return _paramRcmdCommand ?? (_paramRcmdCommand = new RelayCommand<string>(ParamRcmd)); }
		}

		private void ParamRcmd(string parameter)
		{
			RcmdWithParamExecuted = true;
			RcmdWithParamParamValue = parameter;
				
		}


		private RelayCommand<string> _paramRcmdCeCommand;
		public ICommand ParamRcmdCeCommand
		{
			get { return _paramRcmdCeCommand ?? (_paramRcmdCeCommand = new RelayCommand<string>(ParamRcmdCe, CanExecuteParamRcmdCe)); }
		}

		private void ParamRcmdCe(string parameter)
		{
			RcmdWithParamCeExecuted = true;
			RcmdWithParamCeParamValue = parameter;
			
		}

		private bool CanExecuteParamRcmdCe(string parameter)
		{
			RcmdWithParamCeCanExecuteExecuted = true;
			return (CanExecute);
		}

	}


}
