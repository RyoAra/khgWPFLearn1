using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace khgWPFLearn_Module1
{
    public class khgWPFLearn_Module1Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionMan = containerProvider.Resolve<IRegionManager>();
            regionMan.RegisterViewWithRegion("ContentRegion", typeof(Views.KhgLearnUserControl1));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}