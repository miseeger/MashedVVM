/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By Michael Seeger (www.codedriven.net)                                    *
 *                                                                           *
 * Licensed under the MS-PL (http://www.opensource.org/licenses/MS-PL)       *
 * ************************************************************************* */
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AvalonDock.Layout;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.Regions.Behaviors;
using System.ComponentModel;

namespace MashedVVM.Prism.AvalonDock
{

	class AvalonDockRegion : DependencyObject
    {

		public static readonly DependencyProperty NameProperty =
            DependencyProperty.RegisterAttached("Name", typeof(string), typeof(AvalonDockRegion),
                new FrameworkPropertyMetadata((string)null,
                    new PropertyChangedCallback(OnNameChanged)));


		public static string GetName(DependencyObject d)
        {
            return (string)d.GetValue(NameProperty);
        }


		public static void SetName(DependencyObject d, string value)
        {
            d.SetValue(NameProperty, value);
        }


		private static void OnNameChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            CreateRegion((LayoutAnchorable)s, (string)e.NewValue);
        }


		static void CreateRegion(LayoutAnchorable element, string regionName)
        {
            if (element == null) 
                throw new ArgumentNullException("element");

            if (Application.Current == null ||
                Application.Current.MainWindow == null)
                return;

            try
            {
                if (ServiceLocator.Current == null)
                    return;

                var mappings = ServiceLocator.Current.GetInstance<RegionAdapterMappings>();

                if (mappings == null)
                    return;

                IRegionAdapter regionAdapter = mappings.GetMapping(element.GetType());

                if (regionAdapter == null)
                    return;

                regionAdapter.Initialize(element, regionName);
            }
            catch (Exception ex)
            {
                throw new RegionCreationException(string.Format("Unable to create region {0}", regionName), ex);
            }

        }

	}

}
