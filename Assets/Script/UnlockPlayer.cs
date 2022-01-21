using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockPlayer : MonoBehaviour
{
    public static UnlockPlayer instance;
    public void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }
    public  void setUnlock(enumList.Players playerToUnlock, GameObject player)
    {
        Debug.Log("bang bang bang");
        GameManagementPlayer.instance.unlockPlayers.Add(playerToUnlock);
        LoadPlayer.instance.listToLoad.Add(player);
    }
}
