using PixelCrew.Utils.Disposables;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Model.Data.Properties
{
    [Serializable]
    public abstract class PersistentProperty<T>
    {
        [SerializeField] protected T _value;
        protected T _stored;
        private T _defaultValue;

        public delegate void OnPropertyChanged(T oldValue, T newValue);
        public event OnPropertyChanged OnChanged;

        public IDisposable Subscribe(OnPropertyChanged action)
        {
            OnChanged += action;
            return new ActionDisposable(() => OnChanged -= action);
        }

        public T Value
        {
            get
            {
                return _stored;
            }
            set
            {
                var isEqual = _stored.Equals(value);
                if (isEqual) return;

                var oldValue = _stored;
                Write(value);
                _stored = _value = value;

                OnChanged?.Invoke(oldValue, value);
            }
        }

        protected PersistentProperty(T defaultValue)
        {
            _defaultValue = defaultValue;
        }

        protected void Init()
        {
            _stored = _value = Read(_defaultValue);
        }

        public void Validate()
        {
            if (!_stored.Equals(_value))
            {
                Value = _value;
            }
        }

        protected abstract void Write(T value);
        protected abstract T Read(T defaultValue);
    }
}