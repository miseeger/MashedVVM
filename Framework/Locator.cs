/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 *                                                                           *
 * Licensed under the MS-PL (http://www.opensource.org/licenses/MS-PL)       *
 * ************************************************************************* */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MashedVVM.Framework.Attributes;
using MashedVVM.Framework.Contracts;
using MashedVVM.Framework.Exceptions;
using System.Reflection;
using System.Diagnostics;

namespace MashedVVM.Framework
{

	public class Locator : ILocator
	{

		private static Locator _locatorInstance;
		private static readonly object SyncLock = new object();

		private Dictionary<string, object> container = new Dictionary<string, object>();


		public Locator()
		{
			Reload();
		}


		public static Locator Instance
		{
			get
			{
				lock (SyncLock)
				{
					return _locatorInstance ?? (_locatorInstance = new Locator());
				}
			}
		}		


		public void Register(string name, object o)
		{
			if (String.IsNullOrEmpty(name)) 
			{
				throw new ArgumentNullException("name");
			}

			if (!container.ContainsKey(name))
			{
				container.Add(name, o);
			}
			else {
				throw new AlreadyRegisteredException
					(
						String.Format("An instance named '{0}' is already registered.", name)
					);
		}
		}


		public object GetInstance(string name)
		{
			if (container.ContainsKey(name))
			{
				return container[name];
			}
			return null;
		}


		public object this[string name]
		{
			get
			{
				return GetInstance(name);
			}
		}


		public void Reload()
		{
			container.Clear();
			AutoRegisterObjects();
		}


		private void AutoRegisterObjects()
		{
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				foreach (Type candidateToRegister in assembly.GetTypes())
				{
					var attribute = 
						(candidateToRegister.GetCustomAttributes(typeof(RegisterThisAttribute), false) as RegisterThisAttribute[])
							.FirstOrDefault();

					if (attribute != default(RegisterThisAttribute) && !container.ContainsKey(attribute.Name))
					{
						container.Add(attribute.Name, (object)Activator.CreateInstance(candidateToRegister));
					}
				}
			}
		}

	}

}
