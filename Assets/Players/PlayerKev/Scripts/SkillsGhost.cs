using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsGhost : MonoBehaviour
{
    public Transform heart;

    public bool isAlreadyThrow = false;

    private int directionLook;

    public static SkillsGhost instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    private void Update()
    {
        if(GameManagementPlayer.instance._getActualPlayer.tag == "KevinPlayer")
        {
            directionLook = lookDirection(directionLook);

            InputKey();
        }
    }

    private void InputKey()
    {
        if (Input.GetKeyDown(KeyCode.F) && isAlreadyThrow == false && !boxControl.instance._isControl)
        {
            trowHeart();
        }
    }

    private int lookDirection(int directionLook)
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            directionLook = 1;
            Debug.Log("je regarde en haut");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            directionLook = 2;
            Debug.Log("Je regarde en bas");
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            directionLook = 3;
            Debug.Log("je regarde a gauche");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            directionLook = 4;
            Debug.Log("Je regarde a droite");
        }
        return directionLook;
    }

    private void trowHeart()
    {
        Instantiate(heart, playerController.instance._TransformPlayer.position, playerController.instance._TransformPlayer.rotation);
    }

    public int _dirLook
    {
        get { return lookDirection(directionLook); }
    }
}
