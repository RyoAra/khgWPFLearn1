using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using HamburgerMenu;



namespace khgWPFLearn_Module1
{
    [HamburgerMenuItem("KHGModule1", "KhgLearnUserControl1", ModuleType = typeof(khgWPFLearn_Module1Module) ,Glyph = "uE8A5") ]
    public class khgWPFLearn_Module1Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.KhgLearnUserControl1>("KhgLearnUserControl1");
            //containerRegistry.RegisterForNavigation("KhgLearnUserControl1");
        }
    }
}