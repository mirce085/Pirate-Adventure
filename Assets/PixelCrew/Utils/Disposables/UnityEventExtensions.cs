using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Utils.Disposables
{
    public static class UnityEventExtensions
    {
        public static IDisposable Subscribe(this UnityEvent unityEvent, UnityAction action)
        {
            unityEvent.AddListener(action);
            return new ActionDisposable(() => unityEvent.RemoveListener(action));
        }

        public static IDisposable Subscribe<T>(this UnityEvent<T> unityEvent, UnityAction<T> action)
        {
            unityEvent.AddListener(action);
            return new ActionDisposable(() => unityEvent.RemoveListener(action));
        }
    }
}