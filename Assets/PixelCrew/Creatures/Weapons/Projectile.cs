using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;


namespace PixelCrew.Creatures.Weapons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private bool _invertX;

        private int _direction;
        private Rigidbody2D _rigidBody;

        private void Start ()
        {
            _direction = transform.lossyScale.x > 0 ? 1 : -1;
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var mod = _invertX ? -1 : 1;
            var position = _rigidBody.position;
            position.x += _direction * _speed * mod;
            _rigidBody.MovePosition(position);
        }
    }
}