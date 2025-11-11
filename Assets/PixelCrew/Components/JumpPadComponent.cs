using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Components
{
    public class JumpPadComponent : MonoBehaviour
    {
        [SerializeField] private float _jumpForce;
        [SerializeField] private GameObject _object;
        public void Jump()
        {
            var rb = _object?.GetComponent<Rigidbody2D>();

            rb.velocity = new Vector3(rb.velocity.x, _jumpForce);
        }
    }
}