/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 *                                                                           *
 * The Code was taken from Robert MacLean's AtomicMVVM framework             *
 * (https://bitbucket.org/rmaclean/atomicmvvm)                               *
 *                                                                           *
 * This code is distributed under the MS Public License. For more details    *
 * see http://www.opensource.org/licenses/MS-PL.                             *
 *                                                                           *
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
