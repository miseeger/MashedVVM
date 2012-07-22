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
using System.Drawing;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using MashedVVM.Base.Enum;
using MashedVVM.Resources;

namespace MashedVVM.Base.Converters
{

	[ValueConversion(typeof (DataObjectStatus), typeof (BitmapSource))]
	public class DataObjectStatusToImageConverter : IValueConverter
	{

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{

			DataObjectStatus dataObjectStatus = (DataObjectStatus) value;
			Bitmap bmpToConvert = MashedVVMResources.original;

			BitmapSource result = null;

			switch (dataObjectStatus)
			{
				case DataObjectStatus.Modified:
					bmpToConvert = MashedVVMResources.modified;
					break;
				case DataObjectStatus.Deleted:
					bmpToConvert = MashedVVMResources.deleted;
					break;
				case DataObjectStatus.Added:
					bmpToConvert = MashedVVMResources.added;
					break;
			}

			IntPtr hBitmap = bmpToConvert.GetHbitmap();
			BitmapSizeOptions sizeOptions = BitmapSizeOptions.FromEmptyOptions();
			result = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, sizeOptions);
			result.Freeze();

			return result; 
		}


		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DataObjectStatus.Original;
		}
	}

}
