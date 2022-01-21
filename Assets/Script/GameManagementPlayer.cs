using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class GameManagementPlayer : MonoBehaviour
{

    public static GameManagementPlayer instance;

    //[SerializeField] private enumList.Scene actualScene;
    [SerializeField] private GameObject actualPlayer;

    private GameManagementPlayer GameManagementScript;
    private PlayerSwitch PlayerSwitchScript;

    public List<enumList.Players> unlockPlayers;
    public GameObject[] allPlayer;


    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;

      // actualScene = (enumList.Scene)SceneManager.GetActiveScene().buildIndex;
        actualPlayer = _getActualPlayer;
    }

    private void Update()
    {
        actualPlayer = PlayerSwitch.instance._getActualPlayerSwitch;
        Debug.Log("Actual player: " + actualPlayer);
    }

    /*public enumList.Scene _getActualScene
    {
        get { return actualScene; }
        set { actualScene = value; }
    }*/

    public GameObject _getActualPlayer
    {
        get { return actualPlayer; }
        set { actualPlayer = value; }
    }

}



