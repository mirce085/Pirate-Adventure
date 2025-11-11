using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Components.Audio
{
    public class PlaySoundsComponent : MonoBehaviour
    {
        private AudioSource _source;
        [SerializeField] private AudioData[] _sounds;


        public void Play(string id)
        {
            foreach (var sound in _sounds)
            {
                if (id == sound.Id)
                {
                    if (_source == null) _source = GameObject.FindWithTag("SfxAudioSource").GetComponent<AudioSource>();

                    _source.PlayOneShot(sound.Clip);
                    break;
                }
            }
        }
    }


    [Serializable]
    public class AudioData
    {
        [SerializeField] private AudioClip _clip;
        [SerializeField] private string _id;

        public AudioClip Clip => _clip;
        public string Id => _id;
    }
}