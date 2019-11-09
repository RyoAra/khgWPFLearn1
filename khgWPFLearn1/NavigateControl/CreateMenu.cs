using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using HamburgerMenu;
using Reactive.Bindings;
using Prism.Mvvm;
using Prism.Regions;

namespace khgWPFLearn1.NavigateControl
{
    /// <summary>
    /// モジュールロードとかとか
    /// </summary>
    public class NavigateMenu : BindableBase
    {


        public static List<HamburgerMenuItemAttribute> LoadModule()
        {
            List<HamburgerMenuItemAttribute> res = new List<HamburgerMenuItemAttribute>();

            // 読み取り準備
            string dir = System.Environment.CurrentDirectory + @"\Modules";
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(dir);

            // DLLかくほ～
            System.IO.FileInfo[] files = di.GetFiles("*.dll", System.IO.SearchOption.AllDirectories);
            IEnumerable<TypeInfo> tmi;
            foreach (System.IO.FileInfo a in files)
            {
                Assembly oAssembly = Assembly.LoadFrom(a.FullName);

                tmi = oAssembly.DefinedTypes;
                if (tmi.Any(t => t.IsDefined(typeof(HamburgerMenuItemAttribute))))
                {
                    // 属性かくほ～
                    res.Add(tmi.Select(t => t.GetCustomAttribute<HamburgerMenuItemAttribute>()).FirstOrDefault());
                }

            }

            return res;
        }


    }
}
