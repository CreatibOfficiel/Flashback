using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimGhost : MonoBehaviour
{
    private void Update()
    {
        if (GameManagementPlayer.instance._getActualPlayer.tag == "KevinPlayer")
        {
            float characterVelocity = Mathf.Abs(playerController.instance.rb.velocity.x);
            playerController.instance._Animator.SetFloat("Speed", Mathf.Abs(playerController.instance._rb.velocity.x));
            playerController.instance._Animator.SetFloat("TimeIdle", playerController.instance._TimeIdle);
        }
    }
}
