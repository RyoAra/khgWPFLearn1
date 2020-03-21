using System;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;

namespace khgLearnCommon.DataBaseCommon
{
    public class EntityModelCommon:khgLearnCommon.Common.KHGBindingBase
    {
        public void _orderlist_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (var item in e.OldItems)
                    (item as INotifyPropertyChanged).PropertyChanged -= MyType_PropertyChanged;
                foreach (var item in e.NewItems)
                    (item as INotifyPropertyChanged).PropertyChanged += MyType_PropertyChanged;
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                    (item as INotifyPropertyChanged).PropertyChanged += MyType_PropertyChanged;
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                    (item as INotifyPropertyChanged).PropertyChanged -= MyType_PropertyChanged;
            }

        }
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //change event hook here
        }
    }
}
