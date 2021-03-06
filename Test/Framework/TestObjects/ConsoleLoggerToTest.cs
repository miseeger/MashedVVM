﻿/* ************************************************************************* *
 * MashedVVM.Test                                                            *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 *                                                                           *
 * Licensed under the MS-PL (http://www.opensource.org/licenses/MS-PL)       *
 * ************************************************************************* */

using System;
using System.Diagnostics;
using MashedVVM.Framework;
using MashedVVM.Framework.Attributes;

namespace MashedVVM.Test.Framework.TestObjects
{

	[RegisterThis("ConsoleLogger")]
	public class ConsoleLoggerToTest: ILogger
	{

		public void Log (string text)
		{
			System.Console.WriteLine("Console: " + text);
		}

	}

}
