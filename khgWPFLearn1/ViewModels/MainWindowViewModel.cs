using Prism.Mvvm;
using Prism.Regions;
using Prism.Commands;
using Prism.Modularity;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Disposables;
using HamburgerMenu;
using khgWPFLearn1.NavigateControl;

namespace khgWPFLearn1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IRegionManager regionManager = null;
        private IModuleCatalog moduleCatalog = null;

        private CompositeDisposable _disposables = new CompositeDisposable();

        public ReactiveCommand MenuChangeCommand { get; private set; } = new ReactiveCommand();

        public ReactiveCollection<HamburgerMenuItemAttribute> menuItemAttributes { get; set; } = new ReactiveCollection<HamburgerMenuItemAttribute>();

        public ReactiveCollection<MahApps.Metro.Controls.HamburgerMenuItem> hamburgerMenus { get; set; } = new ReactiveCollection<MahApps.Metro.Controls.HamburgerMenuItem>();

        public ReactiveCollection<GrobalNavigate> grobalNavigates { get; set; } = new ReactiveCollection<GrobalNavigate>();

        public ReactiveProperty<HamburgerMenuItemAttribute> selectedMenu { get; set; } = new ReactiveProperty<HamburgerMenuItemAttribute>();

        public MainWindowViewModel(IRegionManager rm, IModuleCatalog mc)
        {
            this.regionManager = rm;
            this.moduleCatalog = mc;

            
            foreach(var v in mc.Modules)
            {
                HamburgerMenuItemAttribute s= new HamburgerMenuItemAttribute();
                s.Text = v.ModuleName;
                var dep = v.DependsOn;
                
            }
            
            foreach(HamburgerMenuItemAttribute s in NavigateMenu.LoadModule())
            {
                menuItemAttributes.Add(s);
                hamburgerMenus.Add(new MahApps.Metro.Controls.HamburgerMenuItem() {Label=s.Text,Command= MenuChangeCommand, });
            }
            this.regionManager.RequestNavigate("ContentRegion", menuItemAttributes[0].ToControlView);
            
            MenuChangeCommand.Subscribe(() => SelectedMenuChanged()).AddTo(_disposables);

            selectedMenu.Value = menuItemAttributes[0];
        }

        private void SelectedMenuChanged()
        {
            this.regionManager.RequestNavigate("ContentRegion", selectedMenu.Value.ToControlView);
        }
    }
}
