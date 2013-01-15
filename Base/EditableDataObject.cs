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
using System.Collections.Generic; 
using System.Linq; 
using MashedVVM.Base.Contracts; 
using MashedVVM.Base.Enum; 
using MashedVVM.Resources; 
 
namespace MashedVVM.Base 
{ 

	public class EditableDataObject: DataObject, IEditableDataObject 
	{

		private readonly Dictionary<string, object> _propBackup; 
		private bool _inTxn; 


		protected EditableDataObject() 
		{ 
			_propBackup = new Dictionary<string, object>(); 
		} 


		public void BeginEdit() 
		{ 
			if (!_inTxn) 
			{ 
				var properties = GetType().GetProperties(); 
				foreach (var pi in properties.Where(pi => pi.CanWrite  
					&& !Names.PropBackupIgnoringProperties.Contains(pi.Name))) 
				{ 
					try 
					{ 
						_propBackup.Add(pi.Name, pi.GetValue(this, null)); 
					} 
					catch(ArgumentException) 
					{ 
						_propBackup[pi.Name] = pi.GetValue(this, null); 
					} 
				} 
				_inTxn = true; 
			} 
		} 


		public void EndEdit() 
		{ 
			if (_inTxn) 
			{ 
				_propBackup.Clear(); 
				_inTxn = false; 
			} 
		} 


		public void CancelEdit() 
		{ 
			if (_inTxn) 
			{ 
				var properties = GetType().GetProperties(); 

				foreach (var pi in properties.Where(pi => pi.CanWrite  
					&& !Names.PropBackupIgnoringProperties.Contains(pi.Name))) 
				{ 
					pi.SetValue(this, _propBackup[pi.Name], null); 
				} 
 
				ObjectStatus = (DataObjectStatus) _propBackup["ObjectStatus"]; 
				_inTxn = false; 
			} 

		} 

	} 

}

