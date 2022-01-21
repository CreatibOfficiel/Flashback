using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimYli : MonoBehaviour
{

    public Animator anim;
    public Rigidbody2D rb;


    // Update is called once per frame
    private void Update()
    {
        if (GameManagementPlayer.instance._getActualPlayer.tag == "YliPlayer")
        {
            anim.SetFloat("Speed", Mathf.Abs(playerController.instance._rb.velocity.x));
            anim.SetBool("Objection", skillYli.instance._skill);
        }

    }
}
