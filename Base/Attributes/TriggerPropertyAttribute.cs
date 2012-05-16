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

namespace MashedVVM.Base.Attributes
{

	[AttributeUsage(System.AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
	public sealed class TriggerPropertyAttribute : System.Attribute 
	{ 
    
    	public string[] PropertyNames { get; private set; } 
	    public int Order { get; private set; } 


    	public TriggerPropertyAttribute(params string[] propertyNames) 
    	    : this(0, propertyNames) 
    	{ 
    	} 
 
    
    	public TriggerPropertyAttribute(int order, params string[] propertyNames) 
    	{ 
    	    this.PropertyNames = propertyNames; 
    	    this.Order = order; 
    	} 

	} 

}
