using PixelCrew.Components;
using PixelCrew.Components.Health;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro.EditorUtilities;
using UnityEngine;

namespace PixelCrew.Creatures
{
    public class TotemTower : MonoBehaviour
    {
        [SerializeField] private List<ShootingTrapAI> _totems;
        [SerializeField] private CooldownComponent _cooldown;

        private int _currentTotem;

        private void Start()
        {
            foreach (var item in _totems)
            {
                item.enabled = false;
                var hp = item.GetComponent<HealthComponent>();
                hp._onDie.AddListener(() => OnTotemDead(item));
            }
        }

        private void OnTotemDead(ShootingTrapAI totem)
        {
            var index = _totems.IndexOf(totem);
            _totems.Remove(totem);
            if (index < _currentTotem)
            {
                _currentTotem -= 1;
            }
        }

        private void Update()
        {
            if(_totems.Count == 0)
            {
                enabled = false;
                Destroy(gameObject, 1);
            }

            var hasTarget = _totems.Any(x => x._vision.IsTouchingLayer);

            if (hasTarget)
            {
                if(_cooldown.IsReady) 
                {
                    _cooldown.Reset();
                    _totems[_currentTotem].Shoot();
                    _currentTotem = (int)Mathf.Repeat(_currentTotem + 1, _totems.Count);
                }
            }
        }
    }
}