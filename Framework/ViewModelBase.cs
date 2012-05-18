/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 * Date: 15.05.2012                                                          *
 *                                                                           *
 * This code is provided as is and should be used at your own risk. It comes *
 * without a warrenty of any kind.                                           *
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
