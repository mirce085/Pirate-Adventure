using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.UI
{
    public class AnimatedWindow : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int _hide = Animator.StringToHash("Hide"); 
        private static readonly int _show = Animator.StringToHash("Show"); 


        protected virtual void Start()
        {
            _animator = GetComponent<Animator>();

            _animator.SetTrigger(_show);
        }

        public void Close()
        {
            _animator.SetTrigger(_hide);
        }

        public virtual void OnCloseAnimationComplete()
        {
            Destroy(gameObject);
        }
    }
}