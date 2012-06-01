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

	public abstract class ValidatableDataObject: EditableDataObject, IValidatableDataObject
	{

		public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

		private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();


		public string Errorlist
		{
			get
			{
				PropertyInfo[] properties = GetType().GetProperties();
				StringBuilder errorList = new StringBuilder("");
				foreach (PropertyInfo pi in properties)
			{
					var error = this[pi.Name];
					if (!String.IsNullOrEmpty(error))
					{ 
						if (!String.IsNullOrEmpty(errorList.ToString()))
						{
							errorList.Append("\n");
						}
						errorList.Append(error);
					}
				}
				return errorList.ToString();
			}
		}


//		public bool IsValid()
//		{
//			PropertyInfo[] properties = GetType().GetProperties();
//			foreach (PropertyInfo pi in properties)
//			{
//				if (!String.IsNullOrWhiteSpace(this[pi.Name]))
//					return false;
//			}
//			return true;
//		}


		public bool IsValid
		{
			get 
			{
				return !this.HasErrors; 
			}
		}


		// ----- implementaion of IDataErrorInfo ------------------------------

		// never used -> always an empty string
		public virtual string Error
		{
			get { return string.Empty; }
		}


		public virtual string this[string columnName]
		{
			// INotifyDataErrorInfo version:
			get { return GetErrors(columnName).ToString(); }

			// w/o INotifyDataErrorInfo:
			// get { return string.Empty; }
		}


		// ----- implementation of INotifyDataErrorInfo -----------------------

		public IEnumerable GetErrors(string propertyName)
		{
			if (_errors.ContainsKey(propertyName))
			{
				return _errors[propertyName];
			}
			return null;
		}


		public IEnumerable GetErrors<T>(Expression<Func<T>> propertyExpression)
		{
			var propertyName = ExtractPropertyName(propertyExpression);
			return GetErrors(propertyName);
		}


		public bool HasErrors
		{
			get 
			{
				return (_errors.Count > 0);
			}
		}


		public void AddError(string propertyName, string error)
		{
			_errors[propertyName] = new List<string>() { error };
			NotifyErrorsChanged(propertyName);
		}


		public void AddError<T>(Expression<Func<T>> propertyExpression, string error)
		{
			var propertyName = ExtractPropertyName(propertyExpression);
			_errors[propertyName] = new List<string>() { error };
			NotifyErrorsChanged(propertyName);
		}


		public void RemoveError(string propertyName)
		{
			if (_errors.ContainsKey(propertyName))
			{
				_errors.Remove(propertyName);
			}
			NotifyErrorsChanged(propertyName);
		}


		public void RemoveError<T>(Expression<Func<T>> propertyExpression)
		{
			var propertyName = ExtractPropertyName(propertyExpression);
			if (_errors.ContainsKey(propertyName))
			{
				_errors.Remove(propertyName);
			}
			NotifyErrorsChanged(propertyName);
		}


		public void NotifyErrorsChanged(string propertyName)
		{
			if (this.ErrorsChanged != null)
			{
				this.ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
			}
		}


		public void NotifyErrorsChanged<T>(Expression<Func<T>> propertyExpression)
		{
			var propertyName = ExtractPropertyName(propertyExpression);
			if (ErrorsChanged != null)
			{
				ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
			}
		}

	}

}

