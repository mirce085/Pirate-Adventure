using PixelCrew.Model.Data;
using PixelCrew.Model.Definitions.Localization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrew.UI.Hud.Dialogs
{
    public class DialogBoxController : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private GameObject _container;
        [SerializeField] private Animator _animator;

        [Space]
        [SerializeField] private float _textSpeed = 0.09f;

        [Header("Sounds")]
        [SerializeField] private AudioClip _typing;
        [SerializeField] private AudioClip _open;
        [SerializeField] private AudioClip _close;

        private Coroutine _typingCoroutine;
        private DialogItem _data;
        private int _currentSentence;
        private AudioSource _sfxSource;
        private static readonly int IsOpen = Animator.StringToHash("IsOpen");

        private void Start()
        {
            _sfxSource = GameObject.FindWithTag("SfxAudioSource").GetComponent<AudioSource>();
        }

        public void ShowDialog(DialogItem data)
        {
            _data = data;
            _currentSentence = 0;
            _text.text = string.Empty;

            _container.SetActive(true);
            _sfxSource.PlayOneShot(_open);
            _animator.SetBool(IsOpen, true);
        }

        private IEnumerator TypeDialogText()
        {
            _text.text = string.Empty;
            var sentence = _data.Sentences[_currentSentence];
            var localizedSentence = LocalizationManager.I.Localize(sentence);

            foreach (var letter in localizedSentence)
            {
                _text.text += letter;
                _sfxSource?.PlayOneShot(_typing);
                yield return new WaitForSeconds(_textSpeed);
            }

            _typingCoroutine = null;
        }

        public void OnSkip()
        {
            if (_typingCoroutine == null) return;

            StopTypeAnimation();
            _text.text = _data.Sentences[_currentSentence];
        }

        private void StopTypeAnimation()
        {
            if( _typingCoroutine != null)
            {
                StopCoroutine(_typingCoroutine);
            }
            _typingCoroutine = null;
        }

        public void OnContinue()
        {
            StopTypeAnimation();
            _currentSentence++;

            if(_currentSentence >= _data.Sentences.Length)
            {
                HideDialogBox();
            }
            else
            {
                OnOpenAnimationComplete();
            }
        }

        private void HideDialogBox()
        {
            _animator.SetBool(IsOpen, false);
            _sfxSource.PlayOneShot(_close);
        }

        private void OnOpenAnimationComplete()
        {
            _typingCoroutine = StartCoroutine(TypeDialogText());
        }

        private void OnCloseAnimationComplete()
        {

        }
    }
}