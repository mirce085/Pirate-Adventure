using PixelCrew.Animations;
using PixelCrew.Components.ColliderBased;
using PixelCrew.Components;
using PixelCrew.Components.GOBased;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;


namespace PixelCrew.Creatures
{
    public class ShootingTrapAI : MonoBehaviour
    {
        [SerializeField] private CooldownComponent _rangeCooldown;
        [SerializeField] public LayerCheck _vision;
        [SerializeField] private SpriteAnimation _animation;

        private void Update()
        {
            if (_vision.IsTouchingLayer && _rangeCooldown.IsReady)
            {
                Shoot();
            }
        }

        public void Shoot()
        {
            _rangeCooldown.Reset();
            _animation.SetClip("start-attack");
        }
    }
}