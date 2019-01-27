using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLoopMusicController : MonoBehaviour
{

    public AudioSource StartMusic;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetMusic(DayMovement.MusicInfo music)
    {
        StartMusic.volume = music.StartVolume;
        StartMusic.clip = music.Start;
        StartMusic.Play();
        transform.GetChild(0).GetComponentInChildren<AudioSource>().volume = music.LoopVolume;
        transform.GetChild(0).GetComponentInChildren<AudioSource>().clip = music.Loop;
        transform.GetChild(0).GetComponent<AudioSource>().Play();
    }

    public void DisableMusic()
    {
        StartMusic.enabled = false;
        transform.GetChild(0).GetComponentInChildren<AudioSource>().enabled = false;
    }


}
