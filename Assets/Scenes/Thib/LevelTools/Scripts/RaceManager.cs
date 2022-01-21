using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    TextMesh text;
    [SerializeField] Animator fireAnimator;
    bool raceIsLunch = false;
    bool decompteHasStart = false;

    public static RaceManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Instance déjà existante sur RaceManager");
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMesh>();
        text.text = "Space To Start";
        StopGame(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Decompte());
        }
    }

    IEnumerator Decompte()
    {
        if (!raceIsLunch && !decompteHasStart)
        {
            text.GetComponent<Animator>().enabled = false;
            text.GetComponent<MeshRenderer>().enabled = true;
            decompteHasStart = true;
            AudioManager.instance.startRace();
            for (int i = 3; i >= 0; i--)
            {
                yield return new WaitForSeconds(1);
                fireAnimator.SetInteger("Color", i);
                text.text = "" + i;
                //GetComponent<AudioSource>().PlayOneShot(soundBeforeStart);
            }

            text.text = "GO !";
            StartGame();
            yield return new WaitForSeconds(2);
            text.text = "";
        }
    }

    void StartGame()
    {
        raceIsLunch = true;
    }

    public void StopGame(bool playerLost)
    {
        if (playerLost)
        {
            GameOverScript.instance.onPlayerLoose();
        }
        raceIsLunch = false;
    }

    public bool getGameState()
    {
        return raceIsLunch;
    }

}
