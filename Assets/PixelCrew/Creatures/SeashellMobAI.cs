using PixelCrew.Components.ColliderBased;
using PixelCrew.Components;
using PixelCrew.Components.GOBased;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace PixelCrew.Creatures
{
    public class SeashellMobAI : MonoBehaviour
    {
        [SerializeField] private CooldownComponent _meleeCooldown;
        [SerializeField] private CooldownComponent _rangeCooldown;

        [SerializeField] private CheckCircleOverlap _meleeAttack;
        [SerializeField] private LayerCheck _meleeCanAttack;

        [SerializeField] private LayerCheck _vision;

        [SerializeField] private SpawnComponent _rangeAttack;

        private Animator _animator;
        protected static int _meleeTrigger = Animator.StringToHash("melee");
        protected static int _rangeTrigger = Animator.StringToHash("range");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (_vision.IsTouchingLayer)
            {
                if (_meleeCanAttack.IsTouchingLayer)
                {
                    if (_meleeCooldown.IsReady)
                    {
                        MeleeAttack();
                    }
                    return;
                }

                if (_rangeCooldown.IsReady)
                {
                    RangeAttack();
                }
            }
        }

        private void RangeAttack()
        {
            _rangeCooldown.Reset();
            _animator.SetTrigger(_rangeTrigger);
        }

        private void MeleeAttack()
        {
            _meleeCooldown.Reset();
            _animator.SetTrigger(_meleeTrigger);
        }

        private void FinalRangeAttack()
        {
            _rangeAttack.Spawn();
        }

        private void FinalMeleeAttack()
        {
            _meleeAttack.Check();
        }
    }
}