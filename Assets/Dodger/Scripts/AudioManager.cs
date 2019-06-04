using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource introST;
    [SerializeField]
    private AudioSource gameST;

    private float savedVolume;
    private bool muted = false;

    void Awake()
    {
        savedVolume = gameST.volume;
    }

    public void PlayIntroSoundTrack()
    {
        gameST.Stop();

        if (!introST.isPlaying)
            introST.Play();
    }

    public void PlayGameSoundTrack()
    {
        introST.Stop();

        if (!gameST.isPlaying)
            gameST.Play();
    }

    public void ToggleMute()
    {
        muted = !muted;

        if (muted)
        {
            introST.volume = 0;
            gameST.volume = 0;
        } else
        {
            introST.volume = savedVolume;
            gameST.volume = savedVolume;
        }
    }

    public bool IsMuted()
    {
        return muted;
    }

}
