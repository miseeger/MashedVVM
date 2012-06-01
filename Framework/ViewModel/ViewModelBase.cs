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
using MashedVVM.Base.Contracts;

namespace MashedVVM.Framework
{

	public abstract class ViewModelBase : NotifyableObject, IViewModel
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


		protected ViewModelBase(IView view)
		{
			if (view != null)
			{
				View = view;
			}
			
			InDesign = (bool)DependencyPropertyDescriptor.FromProperty(DesignerProperties.IsInDesignModeProperty, 
						typeof(FrameworkElement)).Metadata.DefaultValue;

			Initialize();
		}


		public virtual void Initialize()
		{
		
		}
		
		
		public override string ToString()
		{
			return string.Format("ViewModel {0}", GetType().Name);
		}
		
	}
}
