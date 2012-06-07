/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 *                                                                           *
 * Licensed under the MS-PL (http://www.opensource.org/licenses/MS-PL)       *
 * ************************************************************************* */

using System;

namespace MashedVVM.Resources
{

	internal class MashedVVMResources
	{

		private static System.Resources.ResourceManager resourceMan;
		private static System.Globalization.CultureInfo resourceCulture;

		
		internal MashedVVMResources()
		{
		}


		internal static System.Resources.ResourceManager ResourceManager 
		{
			get 
			{
				if (object.ReferenceEquals(resourceMan, null)) 
				{
					System.Resources.ResourceManager temp = 
						new System.Resources.ResourceManager
						(
							"MashedVVM.Resources.MashedVVMResources",
							typeof(MashedVVMResources).Assembly
						);
					resourceMan = temp;
				}
				return resourceMan;
			}
		}


		internal static System.Globalization.CultureInfo Culture {
		get {
				return resourceCulture;
			}
			set {
				resourceCulture = value;
			}
		}


		internal static System.Drawing.Bitmap added
		{
			get 
			{
				object obj = ResourceManager.GetObject("added", resourceCulture);
				return ((System.Drawing.Bitmap)(obj));
			}
		}


		internal static System.Drawing.Bitmap deleted
		{
			get 
			{
				object obj = ResourceManager.GetObject("deleted", resourceCulture);
				return ((System.Drawing.Bitmap)(obj));
			}
		}


		internal static System.Drawing.Bitmap modified
		{
			get 
			{
				object obj = ResourceManager.GetObject("modified", resourceCulture);
				return ((System.Drawing.Bitmap)(obj));
			}
		}

		
		internal static System.Drawing.Bitmap original 
		{
			get 
			{
				object obj = ResourceManager.GetObject("original", resourceCulture);
				return ((System.Drawing.Bitmap)(obj));
			}
		}


	}
}



