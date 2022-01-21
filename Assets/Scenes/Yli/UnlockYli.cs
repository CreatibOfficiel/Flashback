using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockYli : MonoBehaviour
{
    // Start is called before the first frame update

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DefaultPlayer")
        {

            if (!LoadPlayer.instance.LookingForAPlayer(3))
            {
                Debug.Log("OKKKKKKKKKKKKKK");
                UnlockPlayer.instance.setUnlock(enumList.Players.YliPlayer, LoadPlayer.instance.allPlayers[3]); ;
                Debug.Log(LoadPlayer.instance.allPlayers[3]);
                Destroy(gameObject);
            }

    }   }
    
}
