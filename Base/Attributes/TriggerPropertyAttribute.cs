﻿/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 * Date: 15.05.2012                                                          *
 *                                                                           *
 * This code is provided as is and should be used at your own risk. It comes *
 * without a warrenty of any kind.                                           *
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