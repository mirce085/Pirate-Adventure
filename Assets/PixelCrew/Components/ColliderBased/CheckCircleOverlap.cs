using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;


namespace PixelCrew.Components.ColliderBased
{
    public class CheckCircleOverlap : MonoBehaviour
    {
        [SerializeField] private float _radius;
        private Collider2D[] _interactables = new Collider2D[10];
        [SerializeField] private OnOverlapEvent _onOverlapEvent;
        [SerializeField] private string[] _tags;
        [SerializeField] private LayerMask _layer;


        public void Check()
        {
            var size = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _interactables, _layer);

            for (int i = 0; i < size; i++)
            {
                var isInTag = _tags.Any(tag => _interactables[i].CompareTag(tag));
                if (isInTag)
                {
                    _onOverlapEvent?.Invoke(_interactables[i].gameObject);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Handles.DrawSolidDisc(transform.position, Vector3.forward, _radius);
        }




        [Serializable]
        public class OnOverlapEvent : UnityEvent<GameObject>
        {

        }
    }
}