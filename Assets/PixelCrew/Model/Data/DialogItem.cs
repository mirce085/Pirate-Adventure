using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Model.Data
{
    [Serializable]
    public class DialogItem
    {
        [SerializeField] private string[] _sentences;
        public string[] Sentences => _sentences;
    }
}