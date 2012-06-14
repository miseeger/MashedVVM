/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 *                                                                           *
 * The Idea of the TriggerProperty and ReevaluateProperty functionality was  *
 * taken from Robert MacLean's AtomicMVVM framework (http://bit.ly/K5yJ4L).  *
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
using System.Windows.Input;

using MashedVVM.Base.Attributes;

namespace MashedVVM.Base
{

	public class NotifyableObject : INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;


		public NotifyableObject()
		{

			var methods = GetType()
				.GetMethods()
				.Where(m => !m.IsSpecialName
						&& m.DeclaringType != typeof (DataObject)
						&& m.ReturnType == typeof (void))
				.ToList();

			var commands = GetType()
				.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.Where(c => !c.IsSpecialName
						&& typeof(ICommand).IsAssignableFrom(c.FieldType))
				.ToList();

			// Register Property-Triggers:
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
							if (attributeOfMethod.PropertyNames.Contains(e.PropertyName))
							{
								var methodToTrigger = this.GetType().GetMethod(methodOfObject.Name, Type.EmptyTypes);
								methodToTrigger.Invoke(this, null);
							}
					};
				}
			}

			// Register Reevaluations:
			foreach (var command in commands) 
			{
				var attributes = (command.GetCustomAttributes(typeof(ReevaluatePropertyAttribute), false) as ReevaluatePropertyAttribute[])
					.OrderBy(ca => ca.Order);
				
				foreach (var attribute in attributes) 
				{
					ReevaluatePropertyAttribute attributeOfField = attribute;
					FieldInfo commandOfObject = command;

					this.PropertyChanged += (s, e) =>
					{
						if (attributeOfField.PropertyNames.Contains(e.PropertyName)) 
						{
							var raiseCeChangedMethod = this.GetType().GetMethod("RaiseCanExecuteChanged", Type.EmptyTypes);
							if (raiseCeChangedMethod != null)
							{
								raiseCeChangedMethod.Invoke(this, null);
							}
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


		protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
		{
			var propertyName = ExtractPropertyName(propertyExpression);
			RaisePropertyChanged(propertyName);
		}

	}

}