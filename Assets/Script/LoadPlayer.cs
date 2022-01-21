using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour
{

    public static LoadPlayer instance;

     
    public List<GameObject> listToLoad;
    public List<GameObject> allPlayers;

    public GameObject f1;
    public GameObject f2;

    private GameObject playerLoaded;
    private GameManagementPlayer GameManagementScript;

    private GameObject defaultPlayer;

    bool lookforplayer;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    private void Start()
    {
        GameManagementScript = GameObject.FindGameObjectWithTag("GameManagerPlayer").GetComponent<GameManagementPlayer>();
        Debug.Log("monzizi");
        Debug.Log(GameManagerScene.instance._ActualScene);
        if (GameManagerScene.instance._ActualScene == enumList.Scene.Manoir)
        {
            Debug.Log("if");
            foreach (GameObject allplayer in allPlayers)
            {
                foreach (enumList.Players player in GameManagementPlayer.instance.unlockPlayers)
                {
                    playerLoaded = GameObject.FindGameObjectWithTag(player.ToString());
                    Debug.Log(playerLoaded);

                    if (allplayer == playerLoaded)
                    {
                        listToLoad.Add(playerLoaded);
                    }
                }
                allplayer.SetActive(false);
                f1.SetActive(true);
                f2.SetActive(true);

            }
        }
        
        else
        {
            listToLoad.Add(allPlayers[0]);
            foreach(GameObject allplayer in allPlayers)
            {
                allplayer.SetActive(false);
            }
        }


        foreach(GameObject playerToLoad in listToLoad)
        {
            playerToLoad.SetActive(true);
        }

       
    }
    public void LoadPlayerInWorld()
    {
        foreach(GameObject allPlayer in allPlayers)
        {

            allPlayer.SetActive(false);
        }
        allPlayers[0].SetActive(true);
    }

    public bool LookingForAPlayer(int a)
    {
        switch (a)
        {
            default: break;
            case 0: if ( listToLoad.Find(obj => obj.name == "DefaultPlayer") != null) { lookforplayer = true; }
                    else { lookforplayer = false; } break;
            case 1:
                if (listToLoad.Find(obj => obj.name == "AlbanPlayer") != null) { lookforplayer = true; }
                    else { lookforplayer = false; }
                break;
            case 2:
                if (listToLoad.Find(obj => obj.name == "ThibPlayer") != null) { lookforplayer = true; }
                    else { lookforplayer = false; }
                break;
            case 3:
                if (listToLoad.Find(obj => obj.name == "YliPlayer") != null) { lookforplayer = true; }
                    else { lookforplayer = false; }
                break;
            case 4:
                if (listToLoad.Find(obj => obj.name == "KevPlayer") != null) { lookforplayer = true; }
                    else { lookforplayer = false; }
                break;
        }
        return lookforplayer;
    }
}
