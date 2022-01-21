using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private void Start()
    {
        foreach (GameObject allplayer in LoadPlayer.instance.listToLoad)
        {
            allplayer.transform.position = transform.position;
        }
    }
}
