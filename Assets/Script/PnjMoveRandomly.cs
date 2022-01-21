using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PnjMoveRandomly : MonoBehaviour
{
    [Header("Physics")]
    [SerializeField] private float speed;

    [Header("Waypoints lists")]
    [SerializeField] private Transform[] moveSpots;

    public float waitTime;
    public int randomSpot;
    public Rigidbody2D rb;
    public SpriteRenderer sp;

    public Animator anim;
    private float curPosX;
    private float velocity;
   


    private void Start()
    {
        waitTime = Random.Range(5, 20);
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    private void Update()
    {
        if(GameManagerScene.instance._ActualScene == enumList.Scene.Manoir)
            moveAuto();
    }

    private void moveAuto()
    {
        curPosX = transform.position.x;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(moveSpots[randomSpot].position.x, transform.position.y), speed * Time.deltaTime);

        velocity = (transform.position.x - curPosX) / Time.deltaTime;
        anim.SetFloat("Speed", Mathf.Abs(velocity));
        if (transform.position.x > curPosX)
        {
            Flip(true);
        }
        else if(transform.position.x < curPosX)
        {
            Flip(false);
        }

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 1f)
        {

            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = Random.Range(2, 10);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void Flip(bool way)
    {
        if (way)
        {
            sp.flipX = false;
        }
        else if (!way)
        {
            sp.flipX = true;
        }
    }
}