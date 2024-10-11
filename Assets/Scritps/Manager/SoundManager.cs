using System;
using System.Collections;
using UnityEngine;
using Abstracts.Utilities;

namespace Manager
{
    public class SoundManager : SingletonBehavior<SoundManager>
    {
        AudioSource[] _audioSource;

        private void Awake()
        {
            SingletonThisObject(this);

            _audioSource = GetComponentsInChildren<AudioSource>();
        }

        public void PlaySound(int index)
        {
            if (!_audioSource[index].isPlaying)
            {
                _audioSource[index].Play();
            }
        }

        public void StopSound(int index)
        {
            if (_audioSource[index].isPlaying)
            {
                _audioSource[index].Stop();
            }
        }

    }
}