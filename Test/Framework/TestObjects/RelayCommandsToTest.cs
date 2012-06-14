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
		
		public bool RcmdWithParamExecuted { get; set; }
		public string RcmdWithParamParamValue { get; set; }

		public bool RcmdWithParamCeExecuted { get; set; }
		public bool RcmdWithParamCeCanExecuteExecuted { get; set; }
		public string RcmdWithParamCeParamValue { get; set; }
		
		public bool CanExecute { get; set; }


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
		private RelayCommand _simpleRmcdCeCommand;
		public ICommand SimpleRmcdCeCommand
		{
			get { return _simpleRmcdCeCommand ?? (_simpleRmcdCeCommand = new RelayCommand(SimpleRmcdCe, CanExecuteSimpleRmcdCe)); }
		}

		private void SimpleRmcdCe()
		{
			SimpleRcmdCeExecuted = true;
		}

		private bool CanExecuteSimpleRmcdCe()
		{
			SimpleRcmdCeCanExecuteExecuted = true;
			return (CanExecute);
		}


		[ReevaluateProperty("Lastname")]
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
