using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PixelCrew.UI.Widgets
{
    public class ButtonSound : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private AudioClip _sound;
        private AudioSource _soundSource;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_soundSource == null) _soundSource = GameObject.FindWithTag("SfxAudioSource").GetComponent<AudioSource>();
            _soundSource.PlayOneShot(_sound);
        }
    }
}