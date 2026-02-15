using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _gameMusic;
    [SerializeField] private AudioClip _victoryMusic;
    [SerializeField] private AudioClip _gameOverMusic;

    private AudioSource _audioSource;

    private void Awake()
    {
        if (_audioSource == null)
            _audioSource = GetComponent<AudioSource>();
    }

    public void PlayGameMusic()
    {
        PlayMusic(_gameMusic, true);
    }

    public void PlayVictoryMusic()
    {
        PlayMusic(_victoryMusic, false);
    }

    public void PlayGameOverMusic()
    {
        PlayMusic(_gameOverMusic, false);
    }

    private void PlayMusic(AudioClip clip, bool loop)
    {
        if (_audioSource.clip == clip) return;

        _audioSource.Stop();
        _audioSource.loop = loop;
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
