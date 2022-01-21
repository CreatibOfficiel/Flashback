using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerManoir : MonoBehaviour
{

    [SerializeField] AudioSource audioMusic;

    [SerializeField] AudioClip[] musics;

    public static AudioManagerManoir instance;
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
        audioMusic.clip = musics[0];
        audioMusic.Play();
        audioMusic.loop = true;
    }
}
