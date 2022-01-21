using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    void Awake()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                Debug.Log("LoadScene Loader");
                break;
            case 3:
                //GameManager.instance.ManualTurnOffCam();
                break;
            default:
                Debug.Log("Autres");

                //GameManager.instance.ManualTurnOn();
                //GameManager.instance.exchangePlayerSwitch();
                //LoadPlayer.instance.LoadPlayerInWorld();
                //GameManager.instance.RemoveFromDontDestroyOnLoad();
                break;
        }
    }
}
