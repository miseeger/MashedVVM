/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By Michael Seeger (www.codedriven.net)                                    *
 *                                                                           *
 * Licensed under the MS-PL (http://www.opensource.org/licenses/MS-PL)       *
 * ************************************************************************* */
 
using Microsoft.Practices.Unity;
using System;


namespace MashedVVM.Prism.Extensions
{

	public static class UnityContainerExtensions
	{

		public static void RegisterTypeForNavigation<T>(this IUnityContainer container)
		{
			container.RegisterType(typeof(Object), typeof(T), typeof(T).FullName);
		}
		
		
		public static void RegisterTypeForNavigation(this IUnityContainer container, Type type)
		{
			container.RegisterType(typeof(Object), type, type.FullName);
		}

	}

}
