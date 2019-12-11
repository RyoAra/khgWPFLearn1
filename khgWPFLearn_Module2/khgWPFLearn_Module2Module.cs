using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using HamburgerMenu;



namespace khgWPFLearn_Module2
{
    [HamburgerMenuItem("KHGModule2", "KhgLearnUserControl2", ModuleType = typeof(khgWPFLearn_Module2Module) ,Glyph = "uE8A5") ]
    public class khgWPFLearn_Module2Module : IModule
    {
        
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Views.KhgLearnUserControl2>("KhgLearnUserControl2");
        }
    }
}