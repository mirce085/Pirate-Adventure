using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PixelCrew.Components
{
    [Serializable]
    public class CooldownComponent
    {
        [SerializeField] private float _value;
        private float _finalTime;

        public bool IsReady
        {
            get
            {
                return _finalTime <= Time.time;
            }
        }

        public void Reset()
        {
            _finalTime = Time.time + _value;
        }

    }
}