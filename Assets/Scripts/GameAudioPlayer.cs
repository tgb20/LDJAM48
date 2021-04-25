using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioPlayer : MonoBehaviour
{

    private AudioSource _audioSource;

    public AudioClip[] MusicTracks;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_audioSource.isPlaying)
        {
            PlayRandom();
        }
    }

    private void PlayRandom()
    {
        _audioSource.clip = MusicTracks[Random.Range(0, MusicTracks.Length)];
        _audioSource.Play();
    }
}
