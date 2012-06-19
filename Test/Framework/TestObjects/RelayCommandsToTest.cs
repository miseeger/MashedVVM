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

		#region ----- Properties ----------------------------------------------

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

		private string _firstname;
		public string Firstname
		{
			get { return _firstname; }
			set
			{
				if(_firstname != value)
				{
					_firstname = value;
					RaisePropertyChanged(() => Firstname);
				}
			}
		}

		#endregion


		#region ----- SimpleRcmdCommand ---------------------------------------

		public bool SimpleRcmdExecuted { get; set; }

		private RelayCommand _simpleRcmdCommand;
		public RelayCommand SimpleRcmdCommand
		{
			get { return _simpleRcmdCommand ?? (_simpleRcmdCommand = new RelayCommand(SimpleRcmd)); }
		}

		private void SimpleRcmd()
		{
			SimpleRcmdExecuted = true;
		}

		#endregion


		#region ----- SimpleRcmdCeCommand -------------------------------------

		public bool SimpleRcmdCeExecuted { get; set; }
		public bool SimpleRcmdCeCanExecuteExecuted { get; set; }
		public bool SimpleRcmdCeCanExecuteChangedExecuted {get; set; }

		[ReevaluateProperty("Lastname","Firstname")]
		private RelayCommand _simpleRcmdCeCommand;
		public RelayCommand SimpleRcmdCeCommand
		{
			get
			{
				if (_simpleRcmdCeCommand == null) 
				{
					_simpleRcmdCeCommand = new RelayCommand(SimpleRcmdCe, CanExecuteSimpleRcmdCe);
					_simpleRcmdCeCommand.CanExecuteChanged += (s, e) => { SimpleRcmdCeCanExecuteChangedExecuted = true; };
				}
				return _simpleRcmdCeCommand;

				// usual way to get the SimpleRcmdCeCommand instance:
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

		#endregion


		#region ----- ParamRcmdCommand ----------------------------------------
		
		public bool RcmdWithParamExecuted { get; set; }
		public string RcmdWithParamParamValue { get; set; }

		private RelayCommand<string> _paramRcmdCommand;
		public RelayCommand<string> ParamRcmdCommand
		{
			get { return _paramRcmdCommand ?? (_paramRcmdCommand = new RelayCommand<string>(ParamRcmd)); }
		}

		private void ParamRcmd(string parameter)
		{
			RcmdWithParamExecuted = true;
			RcmdWithParamParamValue = parameter;
		}

		#endregion


		#region ----- ParamRcmdCeCommand --------------------------------------

		public bool RcmdWithParamCeExecuted { get; set; }
		public string RcmdWithParamCeParamValue { get; set; }
		public bool RcmdWithParamCeCanExecuteExecuted { get; set; }
		public string RcmdWithParamCeCanExecuteParamValue { get; set; }
		public bool RcmdWithParamCeCanExecuteChangedExecuted {get; set; }

		private RelayCommand<string> _paramRcmdCeCommand;
		public RelayCommand<string> ParamRcmdCeCommand
		{
			get
			{
				if (_paramRcmdCeCommand == null)
				{
					_paramRcmdCeCommand = new RelayCommand<string>(ParamRcmdCe, CanExecuteParamRcmdCe);
					_paramRcmdCeCommand.CanExecuteChanged += (s, e) => { RcmdWithParamCeCanExecuteChangedExecuted = true; };
				}
				return _paramRcmdCeCommand;

				// usual way to get the SimpleRcmdCeCommand instance:
				// return _paramRcmdCeCommand ?? (_paramRcmdCeCommand = new RelayCommand<string>(ParamRcmdCe, CanExecuteParamRcmdCe));
			}
		}

		private void ParamRcmdCe(string parameter)
		{
			RcmdWithParamCeExecuted = true;
			RcmdWithParamCeParamValue = parameter;
		}

		private bool CanExecuteParamRcmdCe(string parameter)
		{
			RcmdWithParamCeCanExecuteParamValue = parameter;
			RcmdWithParamCeCanExecuteExecuted = true;
			return (CanExecute);
		}

		#endregion

	}


}
