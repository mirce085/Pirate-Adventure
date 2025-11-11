using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace PixelCrew.Components.Collectables
{
    public class EnterCollisionComponent : MonoBehaviour
    {

        [SerializeField] private string _tag;
        [SerializeField] private EnterEvent _unityEvent;


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(_tag))
            {
                _unityEvent?.Invoke(collision.gameObject);
            }
        }

        [Serializable]
        class EnterEvent : UnityEvent<GameObject> { }
    }
}