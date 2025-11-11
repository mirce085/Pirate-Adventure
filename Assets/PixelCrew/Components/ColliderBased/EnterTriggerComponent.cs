using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components.Collectables
{
    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private LayerMask _layer = ~0;
        [SerializeField] private EnterEvent _unityEvent;


        private void OnTriggerEnter2D(Collider2D collider)
        {
            if(!collider.gameObject.IsInLayer(_layer)) return;

            if (!string.IsNullOrEmpty(_tag) && !collider.gameObject.CompareTag(_tag)) return;

            _unityEvent?.Invoke(collider.gameObject);
        }

        [Serializable]
        class EnterEvent : UnityEvent<GameObject> { }
    }
}

