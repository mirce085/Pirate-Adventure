using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


namespace PixelCrew.Components
{
    public class CheatCodeInput : MonoBehaviour
    {
        [SerializeField] private Cheat[] _cheats;
        [SerializeField] private float _cooldownDuration;
        private float _timeToReset;
        private string _currentInput;

        void Awake()
        {
            Keyboard.current.onTextInput += HandleTextInput;
        }


        void Update()
        {
            if(_timeToReset <= 0)
            {
                _currentInput = string.Empty;
            }
            else
            {
                foreach (var cheat in _cheats)
                {
                    if (_currentInput == cheat._cheatWord)
                    {
                        cheat._action?.Invoke();
                        _timeToReset = 0;
                        break;
                    }
                }

                _timeToReset -= Time.deltaTime;
            }
        }


        private void HandleTextInput(char ch)
        {
            _currentInput += ch;
            _timeToReset = _cooldownDuration;
        }
    }
}