using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBuffer : MonoBehaviour
{
    public AudioSource TileBreak;
    public AudioSource ButtonSelector;
    public AudioSource Bomb;
    public AudioSource Flag;
    public AudioSource BackgroundMusic;

    public void PlayTileBreak()
    {
        TileBreak.Play();
    }

    public void PlayButtonSelector()
    {
        ButtonSelector.Play();
    }

    public void PlayBomb()
    {
        Bomb.Play();
    }

    public void PlayFlag()
    {
        Flag.Play();
    }

    public void PlayBackground()
    {
        BackgroundMusic.Play();
    }
}

