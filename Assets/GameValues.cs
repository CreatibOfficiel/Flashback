using UnityEngine;
using UnityEngine.SceneManagement;

public class GameValues : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public static GameValues instance;

    public void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Probleme instance GameValues");
            return;
        }

        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused("");
            }
        }
    }

    public void Paused(string str)
    {
        if (str == "")
        {
            pauseMenuUI.SetActive(true);
        }
        
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume()
    {
        if(gameIsPaused)
        {
            pauseMenuUI.SetActive(false);
        }

        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
