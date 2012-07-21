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

namespace MashedVVM.Framework.Attributes
{

	public class RegisterThisAttribute : Attribute
	{

		public string Name { get; set; }


		public RegisterThisAttribute(string name)
		{
			Name = name;
		}

	}

}
