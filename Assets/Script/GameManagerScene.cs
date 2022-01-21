using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerScene : MonoBehaviour
{
    public static GameManagerScene instance;

    [SerializeField] private enumList.Scene actualScene;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;

        actualScene = (enumList.Scene)SceneManager.GetActiveScene().buildIndex;

    }

    private void Update()
    {
        actualScene = (enumList.Scene)SceneManager.GetActiveScene().buildIndex;
    }

    public enumList.Scene _ActualScene
    {
        get { return actualScene; }
        set { actualScene = value; }
    }
}
