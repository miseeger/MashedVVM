/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 * Date: 15.05.2012                                                          *
 *                                                                           *
 * This code is licensed under the Creative Commons Attribution 3.0 License  *
 * (http://creativecommons.org/licenses/by/3.0/de/).                         *
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