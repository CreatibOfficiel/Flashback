using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    bool heWin = false;
    [SerializeField] TextMesh text;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("tt");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("tt33");
            if (RaceManager.instance.getGameState())
            {
                Debug.Log("tt555");
                RaceManager.instance.StopGame(false);
                Debug.Log("bb");
                text.text = "Vous avez terminé la course !\nVous allez retourner dans le manoir d'ici quelques instant.";
                //UnlockPlayer.instance.setUnlock(enumList.Players.ThibPlayer, LoadPlayer.instance.allPlayers[2]) ;
                GameManager.instance.succesMission(4);
                heWin = true;
            }
        }

        if (collision.CompareTag("Enemy"))
        {
            if (RaceManager.instance.getGameState())
            {
                RaceManager.instance.StopGame(true);
            }
        }

        StartCoroutine(StopGame());
    }

    IEnumerator StopGame()
    {
        yield return new WaitForSeconds(2f);
        AudioManager.instance.stopRace();
        if (heWin)
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(2);
        }
    }
}
