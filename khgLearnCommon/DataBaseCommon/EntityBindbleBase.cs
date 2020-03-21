using System;

namespace khgLearnCommon.DataBaseCommon
{
    public class EntityBindbleBase : Common.KHGBindingBase, IEntityCommon
    {
        public bool IsValid{ get; set; }

        public Func<bool> Execute { get; set; }

        protected override bool SetProperty<T>(ref T storage, T value, string propertyName = null)
        {
            IsValid = true;
            return base.SetProperty(ref storage, value, propertyName);
        }

        protected override bool SetProperty<T>(ref T storage, T value, Action onChanged, string propertyName = null)
        {
            IsValid = true;
            return base.SetProperty(ref storage, value, onChanged, propertyName);
        }
    }
}
