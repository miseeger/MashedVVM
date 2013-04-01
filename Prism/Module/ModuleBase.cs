/* ************************************************************************* *
 * MashedVVM                                                                 *
 *                                                                           *
 * Created with SharpDevelop (http://www.icsharpcode.net/OpenSource/SD/)     *
 * By Michael Seeger (www.codedriven.net)                                    *
 *                                                                           *
 * Licensed under the MS-PL (http://www.opensource.org/licenses/MS-PL)       *
 * ************************************************************************* */
 
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace MashedVVM.Prism.Module
{

	public abstract class ModuleBase : IModule
    {

		protected IRegionManager RegionManager { get; private set; }
        protected IUnityContainer Container { get; private set; }


        public ModuleBase(IUnityContainer container, IRegionManager regionManager)
        {
            Container = container;
            RegionManager = regionManager;
        }


        public void Initialize()
        {
            RegisterTypes();
            InitializeModule();
        }


        protected abstract void InitializeModule();
        protected abstract void RegisterTypes();

	}

}