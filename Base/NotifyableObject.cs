/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 *                                                                           *
 * The TriggerProperty functionality was taken from Robert MacLean's         *
 * AtomicMVVM framework (https://bitbucket.org/rmaclean/atomicmvvm).         *
 *                                                                           *
 * This code is distributed under the MS Public License. For more details    *
 * see http://www.opensource.org/licenses/MS-PL.                             *
 *                                                                           *
 * ************************************************************************* */

using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using MashedVVM.Base.Attributes;

namespace MashedVVM.Base
{
	public class NotifyableObject : INotifyPropertyChanged
	{
		
		public event PropertyChangedEventHandler PropertyChanged;


		public NotifyableObject()
		{ 
			// Register Property-Triggers:
			var methods = GetType()
				.GetMethods()
				.Where(m => !m.IsSpecialName
						&& m.DeclaringType != typeof (DataObject)
						&& m.ReturnType == typeof (void))
				.ToList();

			foreach (var method in methods)
			{
				var attributes = (method.GetCustomAttributes(typeof(TriggerPropertyAttribute), false) as TriggerPropertyAttribute[])
					.OrderBy(ca => ca.Order);

				foreach (var attribute in attributes)
				{
					TriggerPropertyAttribute attributeOfMethod = attribute;
					MethodInfo methodOfObject = method;

					this.PropertyChanged += (s, e) =>
						{
							if (attributeOfMethod.PropertyNames.Contains(methodOfObject.Name))
						{
						var methodToTrigger = this.GetType().GetMethod(methodOfObject.Name, Type.EmptyTypes);
						methodToTrigger.Invoke(this, null);
						}
					};
				}
			}
		}


		protected string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
		{
			if (propertyExpression == null)
			{
				throw new ArgumentNullException("propertyExpression");
			}

			var memberExpression = propertyExpression.Body as MemberExpression;
			if (memberExpression == null)
			{
				throw new ArgumentException("The expression is not a member access expression.", "propertyExpression");
			}

			var property = memberExpression.Member as PropertyInfo;
			if (property == null)
			{
				throw new ArgumentException("The member access expression does not access a property.", "propertyExpression");
			}

			var getMethod = property.GetGetMethod(true);
			if (getMethod == null)
			{
				throw new ArgumentException("The referenced property does not have a get method.", "propertyExpression");
			}

			if (getMethod.IsStatic)
			{
				throw new ArgumentException("The referenced property is a static property.", "propertyExpression");
			}

			return memberExpression.Member.Name;
		}


		protected virtual void RaisePropertyChanged(string propertyName)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}


		protected void RaisePropertyChanged(params string[] propertyNames)
		{
			foreach (var name in propertyNames)
			{
				RaisePropertyChanged(name);
			}
		}


		protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
		{
			var propertyName = ExtractPropertyName(propertyExpression);
			RaisePropertyChanged(propertyName);
		}

	}

}