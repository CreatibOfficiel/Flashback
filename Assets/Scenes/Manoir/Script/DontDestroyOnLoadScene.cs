using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject gameManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameManager);
    }
}
