using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrew.Creatures;

namespace PixelCrew.Components
{
    public class SpeedBoostComponent : MonoBehaviour
    {
        [SerializeField] private MyHero _hero;
        [SerializeField] private float _speed;
        [SerializeField] private float _duration;


        IEnumerator SpeedBoostCoroutine()
        {
            var tempSpeed = _hero.Speed;
            _hero.Speed = _speed;
            yield return new WaitForSeconds(_duration);
            _hero.Speed = tempSpeed;
            Destroy(this);
        }

        public void Boost()
        {
            if(_hero != null)
            {
                StartCoroutine(SpeedBoostCoroutine());
            }
        }
    }
}