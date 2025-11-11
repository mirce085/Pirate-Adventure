using PixelCrew.Utils.Disposables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Model.Data.Properties
{
    public class ObservableProperty<T>
    {
        [SerializeField] private T _value;

        public delegate void OnPropertyChanged(T oldValue, T newValue);
        public event OnPropertyChanged OnChanged;

        public T Value
        {
            get => _value;

            set
            {
                var isEqual = _value.Equals(value);
                if (isEqual) return;

                var oldValue = _value;
                _value = value;

                OnChanged?.Invoke(oldValue, _value);
            }
        }

        public IDisposable Subscribe(OnPropertyChanged action)
        {
            OnChanged += action;
            return new ActionDisposable(() => OnChanged -= action);
        }
        
        public IDisposable SubscribeAndInvoke(OnPropertyChanged action)
        {
            OnChanged += action;
            action(_value, _value);
            return new ActionDisposable(() => OnChanged -= action);
        }
    }
}