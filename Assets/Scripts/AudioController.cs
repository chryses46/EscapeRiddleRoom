using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class AudioController : MonoBehaviour
    {
        AudioSource audioSource;

        [SerializeField] AudioClip gamePlayLoop;
        [SerializeField] AudioClip doorOpening;
        [SerializeField] AudioClip doorUnlock;
        [SerializeField] AudioClip dialogLoop;

        private void Start()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        public void PlayGameMusic()
        {
            audioSource.clip = gamePlayLoop;
            audioSource.Play();
        }

        public void PlayDialogMusic()
        {
            audioSource.clip = dialogLoop;
            audioSource.Play();
        }

        public void DoorOpenig()
        {
            audioSource.PlayOneShot(doorOpening);
        }

        public void DoorUnlocking()
        {
            audioSource.PlayOneShot(doorUnlock);
        }

    }
}

