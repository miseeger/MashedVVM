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

	public class EditableDataObject: DataObject, IEditableDataObject
	{

		private Dictionary<string, object> _memento;


		public void BeginEdit()
		{
			_memento = new Dictionary<string, object>();
			PropertyInfo[] properties = this.GetType().GetProperties();
			foreach (PropertyInfo pi in properties)
			{
				// ignore R/O properties!
				if (pi.CanWrite)
				{
					_memento.Add(pi.Name, pi.GetValue(this, null));
				}
			}
		}


		public void EndEdit()
		{
			_memento = null;
		}


		public void CancelEdit()
		{
			PropertyInfo[] properties = this.GetType().GetProperties();
			foreach (PropertyInfo pi in properties)
			{
				if (pi.CanWrite)
				{
					pi.SetValue(this, _memento[pi.Name], null);
				}
			}
			EndEdit();
		}

	}

}

