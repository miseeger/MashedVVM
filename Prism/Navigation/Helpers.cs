/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By Michael Seeger (www.codedriven.net)                                    *
 *                                                                           *
 * Licensed under the MS-PL (http://www.opensource.org/licenses/MS-PL)       *
 * ************************************************************************* */

using System;
using Microsoft.Practices.Prism;

namespace MashedVVM.Prism.Navigation
{
	
	public static class Helpers
	{
		
		
		public static string CreateNavigationPath<T>(string navKey, string navItemName)
        {

			UriQuery query = new UriQuery();
            query.Add(navKey, navItemName);

            return typeof(T).FullName + query;

		}

	}

}
