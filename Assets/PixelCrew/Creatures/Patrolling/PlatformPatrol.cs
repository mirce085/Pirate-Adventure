using PixelCrew.Components.ColliderBased;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Creatures.Patrolling
{
    public class PlatformPatrol : Patrol
    {
        [SerializeField] private LayerCheck _checker;

        private Creature _creature;
        private int _direction;


        private void Awake()
        {
            _creature = GetComponent<Creature>();
        }


        public override IEnumerator DoPatrol()
        {
            while (enabled)
            {
                if (!_checker.IsTouchingLayer)
                {
                    _direction = -_direction;
                    _creature.SetDirection(new Vector2(_direction, 0));
                }
                else
                {
                    _creature.SetDirection(new Vector2(_direction, 0));
                }
            }

            yield return null;
        }
    }
}