/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 *                                                                           *
 * This code is distributed under the MS Public License. For more details    *
 * see http://www.opensource.org/licenses/MS-PL.                             *
 *                                                                           *
 * ************************************************************************* */

using System.Linq; 
using MashedVVM.Base.Contracts; 
using MashedVVM.Base.Enum; 
using MashedVVM.Resources; 
 
namespace MashedVVM.Base 
{ 
 
	public class DataObject: NotifyableObject, IDataObject 
	{ 
 
		protected DataObject() 
		{ 
			PropertyChanged += (o, e) => 
			{ 
				if (ObjectStatus == DataObjectStatus.Original 
				    && (!Names.ObjectStatusIgnoringProperties.Contains(e.PropertyName)))
				{ 
					ObjectStatus = DataObjectStatus.Modified; 
				} 
			}; 
 
		} 
 
 
		private DataObjectStatus _objectStatus = DataObjectStatus.Original; 
		public DataObjectStatus ObjectStatus 
		{ 
			get { return _objectStatus; } 
			set 
			{ 
				if (_objectStatus != value) 
				{ 
					_objectStatus = value;
					RaisePropertyChanged(() => ObjectStatus);
					var newIsDirty = (_objectStatus != DataObjectStatus.Original);
					if (_isDirty != newIsDirty)
					{
						_isDirty = newIsDirty;
						RaisePropertyChanged(() =>  IsDirty); 
					} 
				}
			} 
		} 
 
 
		private bool _isDirty = false; 
		public bool IsDirty 
		{ 
			get { return _isDirty; } 
		} 
 
 
		public void ResetStatus() 
		{ 
			ObjectStatus = DataObjectStatus.Original; 
		} 
 
	} 
 
} 
