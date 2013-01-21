/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 *                                                                           *
 * Licensed under the MS-PL (http://www.opensource.org/licenses/MS-PL)       *
 * ************************************************************************* */

using System;
using System.ComponentModel;
using System.Windows;
using MashedVVM.Framework.Contracts;
using DataObject = MashedVVM.Base.DataObject;

namespace MashedVVM.Framework.ViewModel
{

	public abstract class StatusViewModelBase : DataObject, IViewModel
	{

		private IView _view;
		public IView View { 
			get { return _view; }
			set 
			{
				_view = value;
				_view.ViewModel = this;
			}
		}


		private bool _isBusy;
		public bool IsBusy
		{
			get { return _isBusy; }
			set
			{
				if (_isBusy != value)
				{
					_isBusy = value;
					RaisePropertyChanged(() => IsBusy);
				}
			}
		}


		public Boolean InDesign { get; private set; }


		private string _vmTitle;
		public string VmTitle
		{
			get { return _vmTitle; }
			set
			{
				if(_vmTitle != value)
				{
					_vmTitle = value;
					RaisePropertyChanged(() => VmTitle);
				}
			}
		}


		public StatusViewModelBase()
		{
			InDesign = (bool)DependencyPropertyDescriptor
				.FromProperty(DesignerProperties.IsInDesignModeProperty,
					typeof(FrameworkElement)).Metadata.DefaultValue;
		}


		public StatusViewModelBase(IView view) : this()
		{
			if (view != null)
			{
				View = view;
				View.ViewModel = this;
			}
			
		}


		public virtual void Initialize()
		{
		}
		
		
		public override string ToString()
		{
			return string.Format("StatusViewModel {0}", GetType().Name);
		}

	}
}

