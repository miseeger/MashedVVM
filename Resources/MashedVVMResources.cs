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

	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
	[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
	
	internal class MashedVVMResources
	{

		private static global::System.Resources.ResourceManager resourceMan;
		private static global::System.Globalization.CultureInfo resourceCulture;

		
		[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal MashedVVMResources()
		{
		}


		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		internal static global::System.Resources.ResourceManager ResourceManager 
		{
			get 
			{
				if (object.ReferenceEquals(resourceMan, null)) 
				{
					global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MashedVVM.Resources.MashedMVVMResources", typeof(MashedVVMResources).Assembly);
					resourceMan = temp;
				}
				return resourceMan;
			}
		}


		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		internal static global::System.Globalization.CultureInfo Culture {
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



