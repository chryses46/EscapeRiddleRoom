using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class AudioController : MonoBehaviour
    {
        AudioSource audioSource;

        [SerializeField] AudioClip gamePlayLoop;

        private void Start()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        public void PlayGameMusic()
        {
            audioSource.clip = gamePlayLoop;
            audioSource.Play();
        }


    }
}

