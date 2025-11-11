using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components.Health
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private UnityEvent _onTakeDamage;
        [SerializeField] public UnityEvent _onDie;
        [SerializeField] private HealthChangeEvent _onChange;

        public void DealDamage(int damage)
        {
            _health -= damage;
            _onChange?.Invoke(_health);
            Debug.Log($"Current Health : {_health}");
            if (damage > 0)
            {
                _onTakeDamage?.Invoke();
                if (_health <= 0)
                {
                    _onDie?.Invoke();
                }
            }
            
        }

        private void OnDestroy()
        {
            _onDie.RemoveAllListeners();
        }

        internal void SetHealth(int hp)
        {
            _health = hp;
        }

        [Serializable]
        public class HealthChangeEvent : UnityEvent<int>
        {

        }
    }
}