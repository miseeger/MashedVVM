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

namespace MashedVVM.Base.Attributes
{

	[AttributeUsage(System.AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
	public sealed class IgnoreObjectStatusAttribute : System.Attribute
	{
		public bool IgnoreObjectStatus { get; private set; }

		public IgnoreObjectStatusAttribute(bool ignoreObjectStatus)
		{
			IgnoreObjectStatus = ignoreObjectStatus;
		}

	}

}