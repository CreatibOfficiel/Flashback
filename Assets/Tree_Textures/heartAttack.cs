using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartAttack : MonoBehaviour
{

    public Rigidbody2D rb;
    public SpriteRenderer SP;

    public bool stop = false;

    private int t;

    private void Awake()
    {
        t = SkillsGhost.instance._dirLook;
    }

    public void FixedUpdate()
    {
        Debug.Log(t);
        throwHeart(t);
    }

    private void throwHeart(int t)
    {
        float distance = Vector3.Distance(transform.position, playerController.instance._TransformPlayer.position);

        Debug.Log(SkillsGhost.instance.isAlreadyThrow);
        if (!SkillsGhost.instance.isAlreadyThrow)
        {
            Debug.Log(SkillsGhost.instance._dirLook);
            switch (t)
            {
                case 1:
                    Debug.Log("up");
                    rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                    break;
                case 2:
                    Debug.Log("bas");
                    rb.AddForce(-Vector2.up * 10, ForceMode2D.Impulse);
                    break;
                case 3:
                    Debug.Log("left");
                    rb.AddForce(-Vector2.right * 10, ForceMode2D.Impulse);
                    SP.flipX = true;
                    break;
                case 4:
                    Debug.Log("right");
                    rb.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                    SP.flipX = false;
                    break;
            }
            SkillsGhost.instance.isAlreadyThrow = true;
        }

        if (distance > 5f)
        {
            SkillsGhost.instance.isAlreadyThrow = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "boxKev")
        {
            SkillsGhost.instance.isAlreadyThrow = false;
            Destroy(gameObject);
            boxControl.instance._isControl = true;
        }
    }

}
