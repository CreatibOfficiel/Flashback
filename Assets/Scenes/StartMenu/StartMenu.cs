using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;
    public AudioSource gogo;
    public Text play;
    bool letsgo = false;
    double cooldown = 1;
    void go()
    {
        letsgo = true;

    }
    void Start()
    {
        button.onClick.AddListener(go);
    }

    // Update is called once per frame
    void Update()
    {
        if (letsgo)
        {
            cooldown -= Time.deltaTime;

            if (!gogo.isPlaying)
            {
                gogo.Play();
                play.enabled = false;
            }
        }
        if(cooldown < 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
