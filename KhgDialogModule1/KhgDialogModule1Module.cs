using KhgDialogModule1.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace KhgDialogModule1
{
    public class KhgDialogModule1Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
 
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<ViewA>();
        }
    }
}