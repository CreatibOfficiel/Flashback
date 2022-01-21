using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text thankMessage;

    public bool talkWithGhostMoto = false, talkWithGhostFlirt = false, heWasInMission = false, flirtLevelComplete = false, motoLevelComplete = false;
    public int number = 0;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void setTalkWithGhost(string name)
    {
        switch (name)
        {
            case "Alban":
                talkWithGhostMoto = true;
                break;
            case "Kevin":
                talkWithGhostFlirt = true;
                break;
            default:
                break;
        }
        heWasInMission = true;
    }

    public bool getIfCanTalk()
    {
        return heWasInMission;
    }

    public bool getIfcanGoInThePaint(int iddLevel)
    {
        if(iddLevel == 5 && talkWithGhostFlirt)
        {
            return true;
        }else if(iddLevel == 4 && talkWithGhostMoto)
        {
            return true;
        }
        return false;
    }

    public void succesMission(int iddLevel)
    {
        switch (iddLevel)
        {
            case 5:
                LoadAndSaveData.instance.saveData(2);
                flirtLevelComplete = true;
                talkWithGhostFlirt = false;
                break;
            case 4:
                LoadAndSaveData.instance.saveData(1);
                motoLevelComplete = true;
                talkWithGhostMoto = false;
                break;
        }
        heWasInMission = false;
    }

    public void failedMission(int iddLevel)
    {
        heWasInMission = false;
        switch (iddLevel)
        {
            case 5:
                talkWithGhostFlirt = false;
                break;
            case 4:
                talkWithGhostMoto = false;
                break;
        }
    }
}

