using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceoverOneSHots : MonoBehaviour
{
    public AudioSource VoiceOVerSource;
    public DayMovement nightStatus;
    public AudioClip VoiceOver;
    // Start is called before the first frame update
    void Start()
    {
        
        VoiceOVerSource.clip = VoiceOver;
        VoiceOVerSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(nightStatus.NightStarted && VoiceOVerSource.isPlaying)
        {
            VoiceOVerSource.Stop();
        }
    }
}
