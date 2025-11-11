using PixelCrew.Components;
using PixelCrew.Components.Audio;
using PixelCrew.Components.GOBased;
using PixelCrew.Components.Health;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PixelCrew.Creatures
{
    public class BombMobExplosion : MonoBehaviour
    {
        [SerializeField] ParticleSystem _particleSystem;
        [SerializeField] AudioSource _sound;
        [SerializeField] float _explosionForce;

        private DamageComponent _damageComponent;
        private DestroyObjectComponent _destroyObjectComponent;

        private void Awake()
        {
            _damageComponent = GetComponent<DamageComponent>();
            _destroyObjectComponent = GetComponent<DestroyObjectComponent>();
        }

        public void Explode(GameObject gameObject)
        {
            ExplosionVFX();

            var rb = gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                _damageComponent.DealDamage(gameObject);
                rb.AddForce((gameObject.transform.position - transform.position) * _explosionForce, ForceMode2D.Impulse);
            }
            
        }

        public void ExplosionVFX()
        {
            StartCoroutine(ExplosionVFXCoroutine());
        }

        private IEnumerator ExplosionVFXCoroutine()
        {
            _sound.Play();
            _particleSystem.Play();
            yield return new WaitForSeconds(1f);
            _destroyObjectComponent.Destroy();
        }
    }
}