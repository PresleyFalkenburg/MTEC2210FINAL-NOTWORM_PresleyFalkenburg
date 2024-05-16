using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSoundControl : MonoBehaviour
{
    private AudioSource audioSource;
    public bool muteBackgroundSound;
    [Range(0,1)]public float backgroundSoundVolume;
    private void Awake()
    {
        audioSource = GameObject.Find("Video Player").GetComponent<AudioSource>();

    }

    private void Update()
    {
        audioSource.mute = muteBackgroundSound;
        audioSource.volume = backgroundSoundVolume;

    }


}
