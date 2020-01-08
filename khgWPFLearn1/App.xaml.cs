using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace khgWPFLearn1
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App 
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Views.MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<khgWPFLearn_CustomUI.Dialogs.CustomDialog>();
        }

        
        protected override IModuleCatalog CreateModuleCatalog()
        {
            //Modulesフォルダーにあるモジュールを読み込む。
            //読み込まれる先はモジュール側に書かれたRegionNameの場所
            
            DirectoryModuleCatalog a = new DirectoryModuleCatalog() { ModulePath = System.IO.Path.Combine(System.Environment.CurrentDirectory, @"Modules\") };
            a.Load();
            return a;
        }

        
    }
}
