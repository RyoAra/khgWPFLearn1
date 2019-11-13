using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;
using khgWPFLearn1.NavigateControl;
using HamburgerMenu;
using System.Collections.Generic;
using System.Linq;

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
