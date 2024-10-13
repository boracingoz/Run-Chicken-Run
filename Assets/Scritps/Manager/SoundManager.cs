using System;
using System.Collections;
using UnityEngine;
using Abstracts.Utilities;

namespace Manager
{
    public class SoundManager : SingletonBehavior<SoundManager>
    {
        private AudioSource[] _audioSource;

        private void Awake()
        {
            SingletonThisObject(this);
            DontDestroyOnLoad(gameObject);

            _audioSource = GetComponentsInChildren<AudioSource>();

            if (_audioSource == null || _audioSource.Length == 0)
            {
                Debug.LogError("No AudioSources found. Please add AudioSources to the SoundManager.");
            }
        }

        public void PlaySound(int index)
        {
            if (_audioSource != null && index < _audioSource.Length && !_audioSource[index].isPlaying)
            {
                _audioSource[index].Play();
            }
        }

        public void StopSound(int index)
        {
            if (_audioSource != null && index < _audioSource.Length && _audioSource[index].isPlaying)
            {
                _audioSource[index].Stop();
            }
        }
    }
}
