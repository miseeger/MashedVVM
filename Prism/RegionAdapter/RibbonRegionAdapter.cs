using System.Collections.Specialized;
using System.Windows;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Windows.Controls.Ribbon;

namespace MashedVVM.Prism.RegionAdapter
{

	public class RibbonRegionAdapter : RegionAdapterBase<Ribbon>
    {

		public RibbonRegionAdapter(IRegionBehaviorFactory behaviorFactory)
            : base(behaviorFactory)
        {
        }

 		protected override void Adapt(IRegion region, Ribbon regionTarget)
        {
 
 			region.Views.CollectionChanged += (sender, e) =>
            {
 
 				switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (FrameworkElement element in e.NewItems)
                        {
                            regionTarget.Items.Add(element);
                        }
                        break;

                    case NotifyCollectionChangedAction.Remove:
                        foreach (UIElement elementLoopVariable in e.OldItems)
                        {
                            var element = elementLoopVariable;
                            if (regionTarget.Items.Contains(element))
                            {
                                regionTarget.Items.Remove(element);
                            }
                        }
                        break;
                }
 			};
 		}


 		protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }

	}

}
