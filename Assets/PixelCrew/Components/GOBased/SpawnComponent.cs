using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Components.GOBased
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _gameObject;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            var inst = Instantiate(_gameObject, _target.position, Quaternion.identity);

            inst.transform.localScale = _target.lossyScale;
        }

        internal void SetPrefab(GameObject projectile)
        {
            _gameObject = projectile;
        }
    }
}