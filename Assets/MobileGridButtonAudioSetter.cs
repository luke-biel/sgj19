using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class MobileGridButtonAudioSetter : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private List<AudioSource> mobileGridButtonAudioSources;
    
    private void Start()
    {
        foreach (AudioSource audioSource in mobileGridButtonAudioSources)
        {
            AudioClip clip = audioClips[Random.Range(0,audioClips.Count-1)];
            audioSource.clip = clip;
            audioClips.Remove(clip);
        }
    }
}
