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
using MashedVVM.Base.Attributes;
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
				if (IgnoreObjectStatus && e.PropertyName != "IsDirty") 
				{
					IsDirty = true;	
				}
				else 
				{
					if (ObjectStatus == DataObjectStatus.Original
				    	&& (!Names.ObjectStatusIgnoringProperties.Contains(e.PropertyName)))
					{ 
						ObjectStatus = DataObjectStatus.Modified; 
					} 
				}
			};
			
			IgnoreObjectStatusAttribute[] classAttributes = (IgnoreObjectStatusAttribute[])this.GetType()
				.GetCustomAttributes(typeof(IgnoreObjectStatusAttribute), false);
			IgnoreObjectStatus = (classAttributes.Any() && classAttributes[0].IgnoreObjectStatus);
			
			ObjectStatus = IgnoreObjectStatus ? DataObjectStatus.Ignore : DataObjectStatus.Original;
		}
		
		
		public bool IgnoreObjectStatus { get; private set; }

		
		private DataObjectStatus _objectStatus = DataObjectStatus.Original;
		public DataObjectStatus ObjectStatus 
		{ 
			get { return _objectStatus; } 
			set 
			{ 
				if (IgnoreObjectStatus) 
				{
					_objectStatus = DataObjectStatus.Ignore;
				}
				else
				{
					if (
							(_objectStatus != value)
				        	&& (
								   (_objectStatus != DataObjectStatus.Added)
								   && (
									  	(_objectStatus == DataObjectStatus.Original)
							   		  	|| (_objectStatus == DataObjectStatus.Deleted && value == DataObjectStatus.Original)
				            		  	|| (_objectStatus == DataObjectStatus.Modified && value != DataObjectStatus.Added)
				            	   	)
								)
				   	)
				 	{ 
						_objectStatus = value;
						IsDirty = (_objectStatus != DataObjectStatus.Original);
						RaisePropertyChanged(() => ObjectStatus);
					}
				}
			} 
		}


		private bool _isDirty = false; 
		public bool IsDirty 
		{ 
			get { return _isDirty; } 
			set 
			{
				if (IgnoreObjectStatus) 
				{
					if (_isDirty != value)
					{
						_isDirty = value;
						RaisePropertyChanged(() => IsDirty);
					}
				}
				else
				{
					if ((ObjectStatus != DataObjectStatus.Added && _isDirty != value)
				    	|| (ObjectStatus == DataObjectStatus.Added && _isDirty != value && value))
					{	
						_isDirty = value;
						RaisePropertyChanged(() => IsDirty);
						
						if (_isDirty && ObjectStatus == DataObjectStatus.Original)
						{
							ObjectStatus = DataObjectStatus.Modified;
						}
						else
						{
							if (!_isDirty 
							    && (ObjectStatus == DataObjectStatus.Modified
							        || ObjectStatus == DataObjectStatus.Deleted))
							{
								ObjectStatus = DataObjectStatus.Original;
							}
						}
					}
				}
			}
		} 
 
 
		public void ResetStatus() 
		{ 
			ObjectStatus = DataObjectStatus.Original; 
		} 
 
	} 
 
} 
