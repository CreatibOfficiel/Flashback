using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{


    public GameObject gameOverUI;

    public static GameOverScript instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Erreur GameOverScript Instance");
            return;
        }
        instance = this;
    }

    public void onPlayerLoose()
    {
        gameOverUI.SetActive(true);
        AudioManager.instance.stopRace();
        
    }

    public void RetryButton()
    {
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(4);
    }

    public void MainButton()
    {
        GameManager.instance.failedMission(4);
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(2);
    }
}
