using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plusieurs instance de SaveAndLoad dans la scène");
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    public void Start()
    {
        PlayerPrefs.SetInt("levelMoto", 0);
        PlayerPrefs.SetInt("levelFlirt", 0);
    }

    public bool getLevelMotoState()
    {
        if(PlayerPrefs.GetInt("levelMoto", 0) == 0)
        {
            return false;
        }else if (PlayerPrefs.GetInt("levelMoto", 0) == 1)
            return true;

        return false;
    }

    public bool getLevelFlirtState()
    {
        if (PlayerPrefs.GetInt("levelFlirt", 0) == 0)
        {
            return false;
        }
        else if (PlayerPrefs.GetInt("levelFlirt", 0) == 1)
            return true;

        return false;
    }

    public void saveData(int idd)
    {
        switch (idd)
        {
            case 1:
                PlayerPrefs.SetInt("levelMoto", 1);
                break;
            case 2:
                PlayerPrefs.SetInt("levelFlirt", 1);
                break;
            default:
                break;
        }
    }
}