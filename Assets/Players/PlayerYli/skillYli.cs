using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillYli : MonoBehaviour
{

    private bool skill = false;
    public static skillYli instance;


    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
    }
    void InputKey()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _skill = true;
            //fonction
        }
    }

    public bool _skill
    {
        get { return skill; }
        set { skill = value; }

    }
}
