using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PixelCrew.Components.Health
{
    public class DamageComponent : MonoBehaviour
    {
        [SerializeField] int _damage;

        public void DealDamage(GameObject gameObject)
        {
            var health = gameObject.GetComponent<HealthComponent>();

            health?.DealDamage(_damage);
        }
    }
}

