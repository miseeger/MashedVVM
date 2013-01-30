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
 
		public static string IsDirtyName = "IsDirty";
		public static string ViewName = "View";
		public static string VmTitleName = "VmTitle";
		public static string ObjectStatusName = "ObjectStatus";
		public static string IsBusyName = "IsBusy";
		public static string HasErrorsName = "HasErrors";
		public static string IsValidName = "IsValid";
		
		public static IEnumerable<string>
			PropBackupIgnoringProperties = new List<string> 
											   { 
												  ViewName, 
												  VmTitleName,
												  IsDirtyName
											   }; 
 
		public static IEnumerable<string> 
			ObjectStatusIgnoringProperties = new List<string>() 
												 { 
													 ObjectStatusName,
													 IsBusyName,
													 IsDirtyName, 
													 HasErrorsName, 
													 IsValidName, 
													 ViewName, 
													 VmTitleName 
												 }; 

	} 

} 
