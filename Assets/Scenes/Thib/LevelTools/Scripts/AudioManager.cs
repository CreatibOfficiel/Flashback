using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioSource audioSound;
    [SerializeField] AudioSource audioMusic;
    [SerializeField] AudioSource audioRace;

    [SerializeField] AudioClip[] musics;
    [SerializeField] AudioClip[] sounds;
    [SerializeField] AudioClip[] race;

    public static AudioManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Problème instance AudioManager");
            return;
        }

        instance = this;
    }

    public void Start()
    {
        audioSound.clip = sounds[0];
        audioMusic.clip = musics[0];

        audioSound.Play();
        audioMusic.Play();

        audioSound.loop = true;
        audioMusic.loop = true;
    }

    public void startRace()
    {
        audioMusic.Stop();

        audioRace.clip = race[0];
        audioMusic.clip = musics[1];

        audioRace.Play();
        audioMusic.Play();

        audioMusic.loop = true;
    }

    public void stopRace()
    {
        audioMusic.clip = musics[0];
        audioMusic.Play();
        audioMusic.loop = true;
    }

    public void startNitro()
    {
        audioSound.clip = sounds[1];
        audioSound.Play();
        audioSound.clip = sounds[2];
        audioSound.Play();
        audioSound.loop = true;
    }

    public void stopNitro()
    {
        audioSound.clip = sounds[0];
        audioSound.Play();
        audioSound.loop = true;
    }
}
