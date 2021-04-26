using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAudioVolume : MonoBehaviour
{
    // Start is called before the first frame update

    public bool IsMusic;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (IsMusic)
        {
            _audioSource.volume = PlayerPrefs.GetFloat("Music");
        }
        else
        {
            _audioSource.volume = PlayerPrefs.GetFloat("Effects");
        }


    }
}
