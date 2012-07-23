/* ************************************************************************* *
 * MashedVVM.Test                                                            *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By  : Michael Seeger (www.codedriven.net)                                 *
 *                                                                           *
 * This code is distributed under the MS Public License. For more details    *
 * see http://www.opensource.org/licenses/MS-PL.                             *
 *                                                                           *
 * ************************************************************************* */

using System;
using System.Drawing;
using MashedVVM.Base.Converters;
using MashedVVM.Base.Enum;
using NUnit.Framework;

namespace MashedVVM.Test.Base
{

	[TestFixture]
	public class DataObjectStatusToImageConverterTest
	{

		[Test]
		public void ConvertOriginalTest()
		{
			var converter = new DataObjectStatusToImageConverter();
			var bitmap = converter.Convert(DataObjectStatus.Original, null, null, null);
			Assert.IsTrue(bitmap.ToString() == "System.Windows.Interop.InteropBitmap");
		}

		
		[Test]
		public void ConvertAddedTest()
		{
			var converter = new DataObjectStatusToImageConverter();
			var bitmap = converter.Convert(DataObjectStatus.Added, null, null, null);
			Assert.IsTrue(bitmap.ToString() == "System.Windows.Interop.InteropBitmap");
		}


		[Test]
		public void ConvertModifiedTest()
		{
			var converter = new DataObjectStatusToImageConverter();
			var bitmap = converter.Convert(DataObjectStatus.Modified, null, null, null);
			Assert.IsTrue(bitmap.ToString() == "System.Windows.Interop.InteropBitmap");
		}


		[Test]
		public void ConvertDeletedTest()
		{
			var converter = new DataObjectStatusToImageConverter();
			var bitmap = converter.Convert(DataObjectStatus.Deleted, null, null, null);
			Assert.IsTrue(bitmap.ToString() == "System.Windows.Interop.InteropBitmap");
		}

	}

}
