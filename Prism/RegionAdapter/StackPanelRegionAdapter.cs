using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

using Microsoft.Practices.Prism.Regions;

namespace MashedVVM.Prism.RegionAdapter
{

	public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {

		public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }


		protected override void Adapt(IRegion region, StackPanel regionTarget)
        {

        	region.Views.CollectionChanged += (s, e) =>
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (FrameworkElement element in e.NewItems)
                        {
                            regionTarget.Children.Add(element);
                        }
                        break;

                    case NotifyCollectionChangedAction.Remove:
                        foreach (UIElement elementLoopVariable in e.OldItems)
                        {
                            var element = elementLoopVariable;
                            if (regionTarget.Children.Contains(element))
                            {
                                regionTarget.Children.Remove(element);
                            }
                        }
                        break;
                }
            };
            
        }


		protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }

	}

}
