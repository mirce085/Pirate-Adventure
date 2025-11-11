using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components
{
    public class Cheat : MonoBehaviour
    {
        [SerializeField] public string _cheatWord;
        [SerializeField] public UnityEvent _action;
    }
}