using Prism.Mvvm;
using Prism.Regions;
using Prism.Commands;
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

        private CompositeDisposable _disposables = new CompositeDisposable();

        public ReactiveCommand MenuChangeCommand { get; private set; } = new ReactiveCommand();

        public ReactiveCollection<HamburgerMenuItemAttribute> menuItemAttributes { get; set; } = new ReactiveCollection<HamburgerMenuItemAttribute>();

        public ReactiveProperty<HamburgerMenuItemAttribute> selectedMenu { get; set; } = new ReactiveProperty<HamburgerMenuItemAttribute>();

        public MainWindowViewModel(IRegionManager rm)
        {
            this.regionManager = rm;
            foreach(HamburgerMenuItemAttribute s in NavigateMenu.LoadModule())
            {
                menuItemAttributes.Add(s);
            }
            this.regionManager.RequestNavigate("ContentRegion", menuItemAttributes[0].ToControlView);
            
            MenuChangeCommand.Subscribe(() => SelectedMenuChanged()).AddTo(_disposables);
        }

        private void SelectedMenuChanged()
        {
            this.regionManager.RequestNavigate("ContentRegion", selectedMenu.Value.ToControlView);
        }
    }
}
