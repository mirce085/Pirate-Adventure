using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PixelCrew.Components.Interactions
{
    public class SwitchComponent : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        [SerializeField] private string _propertyName;
        [SerializeField] private bool _state;

        public void Switch()
        {
            _state = !_state;
            _animator.SetBool(_propertyName, _state);
        }
    }
}