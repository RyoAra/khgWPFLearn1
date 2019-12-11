using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using HamburgerMenu;



namespace khgWPFLearn_Module2
{
    [HamburgerMenuItem("KHGModule2", "KhgLearnUserControl2", ModuleType = typeof(khgWPFLearn_Module2Module) ,Glyph = "uE8A5") ]
    //[assembly:HamburgerMenuItem("KHGModule1", "KhgLearnUserControl1",ModuleType =typeof(khgWPFLearn_Module1Module))]
    public class khgWPFLearn_Module2Module : IModule
    {
        
        //[HamburgerMenuItem("KHGModule1", "KhgLearnUserControl1",ModuleType = typeof(khgWPFLearn_Module1Module))]
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionMan = containerProvider.Resolve<IRegionManager>();
            regionMan.RegisterViewWithRegion("ContentRegion", typeof(Views.KhgLearnUserControl2));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation("KhgLearnUserControl1");
        }
    }
}