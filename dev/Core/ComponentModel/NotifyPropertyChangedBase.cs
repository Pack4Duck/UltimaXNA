﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UltimaXNA.Core.ComponentModel
{
    public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityHelper.IsEqual(storage, value))
            {
                return false;
            }

            SetPropertyOverride(ref storage, value, propertyName);

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        protected virtual void SetPropertyOverride<T>(ref T storage, object value, string propertyName)
        {

        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
