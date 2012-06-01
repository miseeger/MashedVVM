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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

using MashedVVM.Base.Contracts;
using MashedVVM.Base.Enum;
using MashedVVM.Base.Events;

namespace MashedVVM.Base
{

	public class DataObject: NotifyableObject, IDataObject
	{

		public IEnumerable<string> ObjectStatusIgnoringProperties { get; set;}


		protected DataObject()
			: this(DataObjectStatus.Original)
		{
		}


		protected DataObject(DataObjectStatus objectStatus)
		{
			ObjectStatusIgnoringProperties = new List<string>() { "IsBusy", "IsDirty", "HasErrors", "IsValid" };
			ObjectStatus = objectStatus;
			PropertyChanged += (o, e) =>
			{
				if (ObjectStatus == DataObjectStatus.Original
					&& (!e.PropertyName.Equals(ExtractPropertyName(() => ObjectStatus))
						|| ObjectStatusIgnoringProperties.Contains(e.PropertyName)))
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
				}
			}
		}

	}

}
