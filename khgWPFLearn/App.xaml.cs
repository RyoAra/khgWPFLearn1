using khgWPFLearn.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;

namespace khgWPFLearn
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //moduleCatalog.AddModule<khgWPFLearn_Module1.khgWPFLearn_Module1Module>();
            moduleCatalog.AddModule(typeof(khgWPFLearn_Module1.khgWPFLearn_Module1Module));
        }
    }
}
