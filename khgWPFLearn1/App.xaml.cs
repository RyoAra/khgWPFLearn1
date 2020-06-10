﻿using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Windows;

namespace khgWPFLearn1
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App 
    {
        private ResourceDictionary dict;

        protected override Window CreateShell()
        {
            return Container.Resolve<Views.MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialogWindow<khgWPFLearn_CustomUI.Dialogs.CustomDialog>();
        }

        
        protected override IModuleCatalog CreateModuleCatalog()
        {
            //Modulesフォルダーにあるモジュールを読み込む。
            //読み込まれる先はモジュール側に書かれたRegionNameの場所
            
            DirectoryModuleCatalog a = new DirectoryModuleCatalog() { ModulePath = System.IO.Path.Combine(System.Environment.CurrentDirectory, @"Modules\") };
            a.Load();
            return a;
        }

        
        public void ChangeTheme(string themeName)
        {
            if(dict == null)
            {
                dict = new ResourceDictionary();
                Application.Current.Resources.MergedDictionaries.Add(dict);
            }
            string themeUri = string.Format(
                "pack://application:,,,/Themes/{0}.xaml", themeName);
            dict.Source = new Uri(themeUri);
        }

    }
}
