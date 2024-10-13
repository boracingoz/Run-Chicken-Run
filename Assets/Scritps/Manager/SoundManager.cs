using System.Collections;
using UnityEngine;
using Abstracts.Utilities;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class SoundManager : SingletonBehavior<SoundManager>
    {
        private AudioSource[] _audioSource;
        private AudioSource _characterSound;
        private Coroutine _jumpSoundCoroutine;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            SingletonThisObject(this);
            DontDestroyOnLoad(gameObject);

            _audioSource = GetComponentsInChildren<AudioSource>();

            if (_audioSource == null || _audioSource.Length == 0)
            {
                Debug.LogError("No AudioSources found. Please add AudioSources to the SoundManager.");
            }

            _characterSound = GameObject.Find("CharacterSound")?.GetComponent<AudioSource>();
            SceneManager.activeSceneChanged += OnSceneChanged;
        }


        private void OnSceneChanged(Scene current, Scene next)
        {
            _audioSource = GetComponentsInChildren<AudioSource>();

            _characterSound = GameObject.Find("CharacterSound")?.GetComponent<AudioSource>();

            if (next.name == "Menu")
            {
                PlayMenuMusic();
            }
            else if (next.name == "Game")
            {
                PlayGameMusic();
            }
        }


        private void PlayMenuMusic()
        {
            StopSound(1); 
            PlaySound(0); 
        }

        private void PlayGameMusic()
        {
            StopSound(0); 
            PlaySound(1); 
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

        public void PlayJumpSound()
        {
            if (_characterSound != null && !_characterSound.isPlaying)
            {
                _jumpSoundCoroutine = StartCoroutine(PlayJumpSoundForDuration(1.2f));
            }
        }

        private IEnumerator PlayJumpSoundForDuration(float duration)
        {
            _characterSound.Play();
            yield return new WaitForSeconds(duration);
            _characterSound.Stop();
        }

        public void StopJumpSound()
        {
            if (_jumpSoundCoroutine != null)
            {
                StopCoroutine(_jumpSoundCoroutine);
                _characterSound.Stop();
            }
        }
    }
}
