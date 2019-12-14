﻿using HamburgerMenu;
using khgWPFLearn1.NavigateControl;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Collections.ObjectModel;
using System.Reactive.Disposables;

namespace khgWPFLearn1.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IRegionManager regionManager = null;
        private IModuleCatalog moduleCatalog = null;
        private GrobalNavigate _selectedMenuItem;

        private CompositeDisposable _disposables = new CompositeDisposable();
        public GrobalNavigate SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set { SetProperty(ref _selectedMenuItem, value); }
        }

        public ReactiveCommand MenuChangeCommand { get; private set; } = new ReactiveCommand();

        public ObservableCollection<GrobalNavigate> menuItemAttributes { get; set; } = new ObservableCollection<GrobalNavigate>();

        //public ReactiveProperty<HamburgerMenuItemAttribute> selectedMenu { get; set; } = new ReactiveProperty<HamburgerMenuItemAttribute>();
        public ReactiveProperty<GrobalNavigate> selectedMenu { get; set; } = new ReactiveProperty<GrobalNavigate>();

        public MainWindowViewModel(IRegionManager rm, IModuleCatalog mc)
        {
            this.regionManager = rm;
            this.moduleCatalog = mc;
 
            foreach(HamburgerMenuItemAttribute s in NavigateMenu.LoadModule())
            {
                menuItemAttributes.Add(new GrobalNavigate() { Text=s.Text,Glyph=s.Glyph,ToControlView=s.ToControlView});
                //hamburgerMenus.Add(new MahApps.Metro.Controls.HamburgerMenuItem() {Label=s.Text,Command= MenuChangeCommand, });
            }
            this.regionManager.RequestNavigate("ContentRegion", menuItemAttributes[0].ToControlView);
            
            MenuChangeCommand.Subscribe(() => SelectedMenuChanged()).AddTo(_disposables);

            SelectedMenuItem = menuItemAttributes[0];
        }

        private void SelectedMenuChanged()
        {
            this.regionManager.RequestNavigate("ContentRegion", SelectedMenuItem.ToControlView);
        }
    }
}
