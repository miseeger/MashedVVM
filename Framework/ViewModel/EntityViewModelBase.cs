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
using MashedVVM.Base;
using MashedVVM.Framework.Contracts;

namespace MashedVVM.Framework.ViewModel
{

	public abstract class EntityViewModelBase : ValidatableDataObject, IViewModel
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


		protected EntityViewModelBase()
		{
			InDesign = (bool)DependencyPropertyDescriptor
				.FromProperty(DesignerProperties.IsInDesignModeProperty,
					typeof(FrameworkElement)).Metadata.DefaultValue;
		}


		protected EntityViewModelBase(IView view) : this()
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
			return string.Format("EntityViewModel {0}", GetType().Name);
		}

	}
}
