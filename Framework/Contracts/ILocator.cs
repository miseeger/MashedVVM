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

namespace MashedVVM.Framework.Contracts
{

	public interface ILocator
	{

		void Register(string name, object o);
		void Reload();
		object Resolve(string name);
		object this[string name] { get; }

	}

}
