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

using System.Collections.Generic;
 
namespace MashedVVM.Resources 
{ 
	public static class Names 
	{ 
 
		public static IEnumerable<string> 
			PropBackupIgnoringProperties = new List<string> 
											   { 
												   "View", 
												   "VmTitle" 
											   }; 
 
		public static IEnumerable<string> 
			ObjectStatusIgnoringProperties = new List<string>() 
												 { 
													 "ObjectStatus",
													 "IsBusy",
													 "IsDirty", 
													 "HasErrors", 
													 "IsValid", 
													 "View", 
													 "VmTitle" 
												 }; 

	} 

} 
